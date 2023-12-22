namespace KT.Utils.ShareFile;

public class ShareFileImp : IShareFile
{
    private readonly IFileProvider _provider;

    public ShareFileImp(IAppSetting appSetting, ILog log)
    {
        // if have many providers -> use app-setting to switch
        _provider = new LocalFileProvider(appSetting, log);
    }

    public bool Copy(string folderName, string sourceFileName, string destFileName, bool overwrite = true)
        => _provider.Copy(folderName, sourceFileName, destFileName, overwrite);

    public ShareFileHandle Create()
         => _provider.Create();

    public bool CreateFolder(string folderName)
        => _provider.CreateFolder(folderName);

    public bool Delete(string folderName, string fileName)
        => _provider.Delete(folderName, fileName);

    public bool DeleteFiles(string folderName, params string[] fileNames)
        => _provider.DeleteFiles(folderName, fileNames);

    public bool DeleteFolder(string folderName, bool recursive = false)
        => _provider.DeleteFolder(folderName, recursive);

    public ShareFileHandle Get(string folderName, string fileName)
        => _provider.Get(folderName, fileName);

    public Dictionary<string, ShareFileHandle> Gets(string folderName, params string[] fileNames)
        => _provider.Gets(folderName, fileNames);

    public List<ShareFileInfo> Gets(string folderName, string searchPattern, SearchOption searchOption)
        => _provider.Gets(folderName, searchPattern, searchOption);

    public MemoryStream GetStream(string folderName, string fileName)
        => _provider.GetStream(folderName, fileName);

    public bool IsExists(string folderName, string fileName)
        => _provider.IsExists(folderName, fileName);

    public bool IsExistsFolder(string folderName)
        => _provider.IsExistsFolder(folderName);

    public bool Move(string folderName, string sourceFileName, string destFileName, bool overwrite = true)
        => _provider.Move(folderName, sourceFileName, destFileName, overwrite);

    public bool RenameFolder(string oldFolderName, string newFolderName)
        => _provider.RenameFolder(oldFolderName, newFolderName);

    public bool Save(string folderName, string fileName, MemoryStream stream, bool createFolderIfNotFound = true)
        => _provider.Save(folderName, fileName, stream, createFolderIfNotFound);

    public bool Save(string folderName, string fileName, ShareFileHandle fileHandle, bool overwrite = true, bool createFolderIfNotFound = true)
        => _provider.Save(folderName, fileName, fileHandle, overwrite, createFolderIfNotFound);
}
