using System.Runtime.CompilerServices;

namespace KT.Utils.ShareFile;

internal class LocalFileProvider : IFileProvider
{
    private readonly ILog _log;

    private readonly string _shareTempPath;
    private readonly bool _shareLogDebug;

    private readonly string _localRootPath;
    private readonly bool _localIgnoreImpersonate;
    private readonly WindowsImpersonationHelper _localImpersonationHelper;

    public LocalFileProvider(IAppSetting appSetting, ILog log)
    {
        _shareTempPath = appSetting["ShareFile:TempPath"];
        _shareLogDebug = appSetting.AsBool("ShareFile:LogDebug");

        _localRootPath = appSetting["ShareFile:Local:RootPath"];
        _localIgnoreImpersonate = appSetting.AsBool("ShareFile:Local:IgnoreImpersonate");

        if (!_localIgnoreImpersonate)
        {
            _localImpersonationHelper = new WindowsImpersonationHelper(appSetting["ShareFile:Local:ImpersonateDomain"], appSetting["ShareFile:Local:ImpersonateUserName"], appSetting["ShareFile:Local:ImpersonatePassword"]);
        }

        _log = log;
    }

    public bool CreateFolder(string folderName)
    {
        return Execute(() =>
        {
            var path = LocalPath(folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return true;
        });
    }

    /// <summary>
    /// Delete empty folder
    /// </summary>
    public bool DeleteFolder(string folderName, bool recursive = false)
    {
        return Execute(() =>
        {
            var path = LocalPath(folderName);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive);
                return true;
            }

            return false;
        });
    }

    public bool RenameFolder(string oldFolderName, string newFolderName)
    {
        return Execute(() =>
        {
            var oldPath = LocalPath(oldFolderName);
            var newPath = LocalPath(newFolderName);

            if (Directory.Exists(oldPath) && !Directory.Exists(newFolderName))
            {
                Directory.Move(oldPath, newPath);
                return true;
            }

            return false;
        });
    }

    public bool IsExistsFolder(string folderName)
    {
        return Execute(() => Directory.Exists(LocalPath(folderName)));
    }

    public ShareFileHandle Create()
    {
        return new ShareFileHandle(Path.Combine(_shareTempPath, Guid.NewGuid().ToString().Replace("-", "")), _shareLogDebug);
    }

    public bool Save(string folderName, string fileName, ShareFileHandle fileHandle, bool overwrite = true, bool createFolderIfNotFound = true)
    {
        return Execute(() =>
        {
            var filePath = LocalPath(folderName, fileName);

            var start = DateTime.Now;
            Log("Start put file processing: " + filePath);

            if (createFolderIfNotFound)
            {
                var folderPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }

            File.Copy(fileHandle.LocalFilePath, filePath, overwrite);

            var end = DateTime.Now - start;
            Log($"Total put file ({filePath}): {end}");

            return true;
        });
    }

    public bool Save(string folderName, string fileName, MemoryStream stream, bool createFolderIfNotFound = true)
    {
        return Execute(() =>
        {
            var filePath = LocalPath(folderName, fileName);

            var start = DateTime.Now;
            Log("Start put file processing: " + filePath);

            if (createFolderIfNotFound)
            {
                var folderPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }

            using (var writer = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var data = stream.ToArray();
                writer.Write(data, 0, data.Length);
            }

            var end = DateTime.Now - start;
            Log($"Total put file ({filePath}): {end} ");

            return true;
        });
    }

    public bool Delete(string folderName, string fileName)
    {
        return Execute(() =>
        {
            var filePath = LocalPath(folderName, fileName);
            if (File.Exists(filePath))
            {
                Log("Delete File: " + filePath);
                File.Delete(filePath);
                return true;
            }

            return false;
        });
    }

    public MemoryStream GetStream(string folderName, string fileName)
    {
        return Execute(() =>
        {
            var filePath = LocalPath(folderName, fileName);
            if (File.Exists(filePath))
            {
                Log("Get File: " + filePath);
                return new MemoryStream(File.ReadAllBytes(filePath));
            }

            return new MemoryStream();
        });
    }

    public ShareFileHandle Get(string folderName, string fileName)
    {
        return Execute(() =>
        {
            ShareFileHandle handle = null;
            var filePath = LocalPath(folderName, fileName);

            if (File.Exists(filePath))
            {
                handle = Create();

                Log("Get File: " + filePath);
                File.Copy(filePath, handle.LocalFilePath);
            }

            return handle;
        });
    }

    public bool IsExists(string folderName, string fileName)
    {
        return Execute(() =>
        {
            var filePath = LocalPath(folderName, fileName);
            return File.Exists(filePath);
        });
    }

    public Dictionary<string, ShareFileHandle> Gets(string folderName, params string[] fileNames)
    {
        return Execute(() =>
        {
            var handles = new Dictionary<string, ShareFileHandle>();
            var sharePath = Path.Combine(_localRootPath, folderName);

            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(sharePath, fileName);

                if (!handles.ContainsKey(filePath) && File.Exists(filePath))
                {
                    var handle = Create();

                    Log("Get File: " + filePath);
                    File.Copy(filePath, handle.LocalFilePath);

                    handles.Add(fileName, handle);
                }
            }

            return handles;
        });
    }

    public List<ShareFileInfo> Gets(string folderName, string searchPattern, SearchOption searchOption)
    {
        return Execute(() =>
        {
            var fileInfos = new List<ShareFileInfo>();
            var sharePath = Path.Combine(_localRootPath, folderName);
            var filePaths = !string.IsNullOrWhiteSpace(searchPattern) ? Directory.GetFiles(sharePath, searchPattern, searchOption) : Directory.GetFiles(sharePath);

            foreach (var filePath in filePaths)
            {
                var handle = Create();

                Log("Get File: " + filePath);
                File.Copy(filePath, handle.LocalFilePath);

                fileInfos.Add(new ShareFileInfo
                {
                    FileName = Path.GetFileName(filePath),
                    FilePath = filePath,
                    Handle = handle
                });
            }

            return fileInfos;
        });
    }

    public bool DeleteFiles(string folderName, params string[] fileNames)
    {
        return Execute(() =>
        {
            var sharePath = Path.Combine(_localRootPath, folderName);

            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(sharePath, fileName);
                if (File.Exists(filePath))
                {
                    Log("Delete File: " + filePath);
                    File.Delete(filePath);
                }
            }

            return true;
        });
    }

    public bool Copy(string folderName, string sourceFileName, string destFileName, bool overwrite = true)
    {
        return Execute(() =>
        {
            var sourceFilePath = LocalPath(folderName, sourceFileName);
            if (!File.Exists(sourceFilePath))
            {
                return false;
            }

            var destFilePath = LocalPath(folderName, destFileName);
            var destfolderPath = Path.GetDirectoryName(destFilePath);
            if (!Directory.Exists(destfolderPath))
            {
                Directory.CreateDirectory(destfolderPath);
            }

            File.Copy(sourceFilePath, destFilePath, overwrite);
            return true;
        });
    }

    public bool Move(string folderName, string sourceFileName, string destFileName, bool overwrite = true)
    {
        if (sourceFileName.Equals(destFileName, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return Execute(() =>
        {
            var sourceFilePath = LocalPath(folderName, sourceFileName);
            if (!File.Exists(sourceFilePath))
            {
                return false;
            }

            var destFilePath = LocalPath(folderName, destFileName);
            var destfolderPath = Path.GetDirectoryName(destFilePath);
            if (!Directory.Exists(destfolderPath))
            {
                Directory.CreateDirectory(destfolderPath);
            }

            File.Move(sourceFilePath, destFilePath);
            return true;
        });
    }

    #region Processing funcs

    private TResult Execute<TResult>(Func<TResult> action, [CallerMemberName] string callerMemberName = "")
    {
        if (!_localIgnoreImpersonate && _localImpersonationHelper == null)
        {
            throw new Exception("ShareFile setting is not yet configured. Please call SetSetting function");
        }

        try
        {
            if (_localIgnoreImpersonate)
            {
                return action();
            }

            var result = default(TResult);
            var response = _localImpersonationHelper.Impersonate(() =>
            {
                result = action();
            });

            if (!response.Success)
            {
                _log.Error(response.Error);
                return result;
            }

            return result;
        }
        catch (Exception ex)
        {
            _log.Error(ex, $"{callerMemberName}: {ex.Message}");
            return default;
        }
    }

    private string LocalPath(params string[] paths)
    {
        var temp = new List<string> { _localRootPath };
        temp.AddRange(paths);

        return Path.Combine(temp.ToArray());
    }

    private void Log(string message)
    {
        if (_shareLogDebug)
        {
            _log.Debug(message);
        }
    }

    #endregion
}
