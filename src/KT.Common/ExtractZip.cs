using System.Diagnostics;
using System.IO.Compression;

namespace KT.Common;

public partial class ExtractZip : IDisposable
{
    public ExtractOptions Options { get; private set; } = new ExtractOptions();

    public string DescPath { get; }

    public string ZipFilePath { get; private set; }

    public List<ExtractItem> ExtractItems { get; } = new List<ExtractItem>();

    public Exception ExtractException { get; private set; }

    public ExtractZip(string descPath, Stream stream, string extension = ".zip", ExtractOptions options = null)
    {
        DescPath = descPath;
        if (options != null) Options = options;

        CreateZipFile(stream, extension);
    }

    public ExtractZip(string descPath, string zipFilePath, ExtractOptions options = null)
    {
        DescPath = descPath;
        if (options != null) Options = options;

        ZipFilePath = zipFilePath;
    }

    public void Extract(Func<ExtractItem, bool> filter = null)
    {
        CreateDescFolder(throwIfError: true);

        ExtractItems.Clear();

        try
        {
            if (ZipFilePath.EndsWith("zip", StringComparison.OrdinalIgnoreCase))
            {
                ProcessExtractZip(filter);
            }
            else if (ZipFilePath.EndsWith("rar", StringComparison.OrdinalIgnoreCase))
            {
                ProcessExtractRar(filter);
            }
        }
        catch (Exception ex)
        {
            if (Options.ThrowIfError)
            {
                throw;
            }

            ExtractException = ex;
        }
    }

    private void ProcessExtractZip(Func<ExtractItem, bool> filter = null)
    {
        using var archive = ZipFile.OpenRead(ZipFilePath);

        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            var extractItem = new ExtractItem
            {
                Name = entry.Name,
                Path = Path.Combine(DescPath, entry.FullName.TrimEnd('/').Replace("/", "\\")),
            };

            if (entry.Length == 0 && string.IsNullOrWhiteSpace(entry.Name)) // directory
            {
                extractItem.IsFolder = true;
                extractItem.Name = Path.GetFileName(extractItem.Path);
            }

            if (filter != null && !filter(extractItem))
            {
                continue;
            }

            if (Options == null || !Options.NoExtractOnlyFetchFileInfos)
            {
                if (extractItem.IsFolder)
                {
                    extractItem.Exception = CreateFolder(extractItem.Path);
                }
                else
                {
                    try
                    {
                        entry.ExtractToFile(extractItem.Path, overwrite: true);
                    }
                    catch (Exception ex)
                    {
                        extractItem.Exception = ex;
                    }
                }
            }

            ExtractItems.Add(extractItem);
        }
    }

    const string _rarPath = @"C:\Program Files\WinRAR\rar.exe";

    private void ProcessExtractRar(Func<ExtractItem, bool> filter = null)
    {
        if (!File.Exists(_rarPath))
        {
            return;
        }

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = _rarPath,
                Arguments = " x " + " " + ZipFilePath + " " + " " + DescPath,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = DescPath + "\\"
            }
        };

        process.Start();
        process.WaitForExit(60 * 1000);

        // directories
        foreach (var folderPath in Directory.EnumerateDirectories(DescPath, "*", SearchOption.AllDirectories))
        {
            var item = new ExtractItem { IsFolder = true, Name = Path.GetFileName(folderPath), Path = folderPath };
            if (filter?.Invoke(item) ?? true)
            {
                ExtractItems.Add(item);
            }
        }

        // files
        foreach (var filePath in Directory.EnumerateFiles(DescPath, "*", SearchOption.AllDirectories))
        {
            //ignore temp rar
            var fileName = Path.GetFileName(filePath);
            if (ZipFilePath.EndsWith(fileName, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var item = new ExtractItem { Name = fileName, Path = filePath };
            if (filter?.Invoke(item) ?? true)
            {
                ExtractItems.Add(item);
            }
        }
    }

    private void CreateZipFile(Stream fileStream, string fileExtension)
    {
        try
        {
            CreateDescFolder(throwIfError: true);

            ZipFilePath = Path.Combine(DescPath, $"{Guid.NewGuid():N}.{fileExtension.TrimStart('.')}");

            using var output = new FileStream(ZipFilePath, FileMode.Create);
            fileStream.CopyTo(output);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void CreateDescFolder(bool throwIfError = false)
    {
        var ex = CreateFolder(DescPath);

        if (ex != null && throwIfError)
        {
            throw ex;
        }
    }

    private Exception CreateFolder(string path)
    {
        try
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}

public partial class ExtractZip
{
    private bool disposed = false;

    ~ExtractZip() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            if (Options.DeleteDescFiles)
            {
                // files
                foreach (var item in ExtractItems.Where(a => !a.IsFolder))
                {
                    try { if (File.Exists(item.Path)) File.Delete(item.Path); } catch { }
                }

                // folders
                foreach (var item in ExtractItems.Where(a => a.IsFolder))
                {
                    try { if (Directory.Exists(item.Path)) Directory.Delete(item.Path, true); } catch { }
                }
            }

            if (Options.DeleteDescFolder)
            {
                try { if (Directory.Exists(DescPath)) Directory.Delete(DescPath, true); } catch { }
            }

            if (Options.DeleteZipFile)
            {
                try { if (File.Exists(ZipFilePath)) File.Delete(ZipFilePath); } catch { }
            }
        }

        disposed = true;
    }
}

public partial class ExtractZip
{
    public class ExtractItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsFolder { get; set; }

        public Exception Exception { get; set; }
    }

    public class ExtractOptions
    {
        public bool NoExtractOnlyFetchFileInfos { get; set; }

        public bool ThrowIfError { get; set; }

        public bool DeleteDescFiles { get; set; }

        public bool DeleteDescFolder { get; set; }

        public bool DeleteZipFile { get; set; }
    }
}