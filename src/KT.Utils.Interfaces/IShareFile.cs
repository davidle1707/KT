namespace KT.Utils.Interfaces;

public interface IShareFile
{
    bool Copy(string folderName, string sourceFileName, string destFileName, bool overwrite = true);

    ShareFileHandle Create();

    bool CreateFolder(string folderName);

    bool Delete(string folderName, string fileName);

    bool DeleteFiles(string folderName, params string[] fileNames);

    bool DeleteFolder(string folderName, bool recursive = false);

    ShareFileHandle Get(string folderName, string fileName);

    Dictionary<string, ShareFileHandle> Gets(string folderName, params string[] fileNames);

    List<ShareFileInfo> Gets(string folderName, string searchPattern, SearchOption searchOption);

    MemoryStream GetStream(string folderName, string fileName);

    bool IsExists(string folderName, string fileName);

    bool IsExistsFolder(string folderName);

    bool Move(string folderName, string sourceFileName, string destFileName, bool overwrite = true);

    bool RenameFolder(string oldFolderName, string newFolderName);

    bool Save(string folderName, string fileName, MemoryStream stream, bool createFolderIfNotFound = true);

    bool Save(string folderName, string fileName, ShareFileHandle fileHandle, bool overwrite = true, bool createFolderIfNotFound = true);
}

#region Models

[Serializable]
public class ShareFileInfo
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    public ShareFileHandle Handle { get; set; }
}

public class ShareFileHandle : IDisposable
{
    public string LocalFilePath { get; private set; }

    public bool LogDebug { get; set; }

    public ShareFileHandle(string localFilePath, bool logDebug = false)
    {
        LocalFilePath = localFilePath;
        LogDebug = logDebug;
    }

    #region Disposable

    private bool _disposed;

    ~ShareFileHandle()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                try
                {
                    //if (LogDebug) ShareFileManager._log.Debug($"Remove FileDB temp file: {LocalFilePath}");

                    if (File.Exists(LocalFilePath))
                    {
                        File.Delete(LocalFilePath);
                    }
                }
                catch //(Exception ex)
                {
                    //ShareFileManager._log.Error($"Error removing FileDB temp file '{LocalFilePath}': {ex.Message}", ex);
                }
            }

            _disposed = true;
        }
    }

    #endregion
}

    #endregion
