using System.Diagnostics;
using System.Text.Json;

namespace SymbolLink;

public sealed class Utilities : IDisposable
{
    private static Utilities? _instance;
    public static Utilities Instance
    {
        get
        {
            _instance ??= new Utilities();
            return _instance;
        }
    }
    private const string SYMBOL_LINK_FILE = "symbol_link.json";
    public readonly Dictionary<string, SymbolicLink> SymbolLinks = []; // key là source


    private readonly static JsonSerializerOptions JSON_SERIALIZER_OPTIONS = new() { WriteIndented = false };
    private readonly FolderBrowserDialog _browserDialog = new();
    public event Action<IEnumerable<SymbolicLink>> OnSymbolicLinksChanged;

    private Utilities()
    {

        OnSymbolicLinksChanged += (links) => SaveSymbolLinks();

        AppDomain.CurrentDomain.ProcessExit += (sender, e) => SaveSymbolLinks();

        AppDomain.CurrentDomain.UnhandledException += (sender, e) => SaveSymbolLinks();

        AppDomain.CurrentDomain.DomainUnload += (sender, e) => SaveSymbolLinks();

        if (File.Exists(SYMBOL_LINK_FILE))
        {
            LoadSymbolLinks();
        }
    }

    /// <summary>
    /// mở hộp thoại chọn thư mục
    /// </summary>
    /// <returns>đường dẫn được chọn</returns>
    public string BrowseFolder()
    {
        _browserDialog.Description = "Select a folder";
        _browserDialog.ShowNewFolderButton = false;
        _browserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
        _browserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        if (_browserDialog.ShowDialog() == DialogResult.OK)
        {
            return _browserDialog.SelectedPath;
        }
        return string.Empty;
    }

    /// <summary>
    /// chỉ add vô list chứ chưa tạo link thực tế
    /// </summary>
    /// <param name="source">đường dẫn tới source</param>
    /// <param name="destination">đường dẫn tới destination</param>
    /// <returns>thành công hay thất bại</returns>
    public bool AddSymbolLinkToList(string source, string destination)
    {
        if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination))
        {
            return false;
        }

        if (!Directory.Exists(source))
        {
            return false;
        }

        if (SymbolLinks.TryGetValue(source, out var link))
        {
            return false;
        }

        SymbolLinks[source] = new SymbolicLink { Source = source, Destination = destination, IsUnsymbol = true };

        OnSymbolicLinksChanged?.Invoke(SymbolLinks.Values);

        return true;

    }

    public bool CopyFiles(string source, string destination)
    {
        if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination))
        {
            return false;
        }

        if (!Directory.Exists(source))
        {
            return false;
        }

        try
        {
            FileUtils.CopyFilesWithWindowsDialog(@$"{source}\*", destination);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

    }

    /// <summary>
    /// tạo symbol link
    /// </summary>
    /// <param name="source">đường dẫn tới source</param>
    /// <param name="destination">đường dẫn tới destination</param>
    /// <returns>thành công hay thất bại</returns>
    public bool CreateSymbolicLink(string source, string destination)
    {
        if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(destination))
        {
            return false;
        }
        string sourceBackup = source + "_tool_backup";
        if (Directory.Exists(destination))
        {
            try
            {
                if (Directory.Exists(source))
                {
                    Directory.Move(source, sourceBackup);
                }

                bool result = RunCommandCreateSymbolicLink(source, destination);

                if (result)
                {
                    if (SymbolLinks.TryGetValue(source, out var link))
                    {
                        link.Destination = destination;
                        link.IsUnsymbol = false;
                    }
                    else
                    {
                        SymbolLinks[source] = new SymbolicLink { Source = source, Destination = destination, IsUnsymbol = false };
                    }

                    OnSymbolicLinksChanged?.Invoke(SymbolLinks.Values);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// xoá symbol link (nhưng không loại bỏ khỏi list đã lưu)
    /// </summary>
    /// <param name="source">đường dẫn tới source</param>
    /// <returns>thành công hay thất bại</returns>
    public bool UnsymbolLink(string source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return false;
        }
        string sourceBackup = source + "_tool_backup";
        try
        {
            if (Directory.Exists(source) && (File.GetAttributes(source) & FileAttributes.ReparsePoint) != 0)  // Kiểm tra nếu là symbolic link thư mục
            {
                Directory.Delete(source);  // Xóa symbolic link cho thư mục
                Directory.Move(sourceBackup, source);

                if (SymbolLinks.TryGetValue(source, out var link))
                {
                    link.IsUnsymbol = true;
                }

                OnSymbolicLinksChanged?.Invoke(SymbolLinks.Values);

                return true;
            }

            return false;  // Nếu không phải symbolic link
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


    public bool DeleteSymbolLink(string source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return false;
        }

        try
        {
            if (SymbolLinks.TryGetValue(source, out var link))
            {
                if (!link.IsUnsymbol)
                {
                    UnsymbolLink(source);
                }

                SymbolLinks.Remove(source);
                OnSymbolicLinksChanged?.Invoke(SymbolLinks.Values);
                return true;
            }


            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


    /// <summary>
    /// lưu symbol links vào file
    /// </summary>
    public void SaveSymbolLinks()
    {
        // serialize JSON directly to a file

        using FileStream fileStream = new(SYMBOL_LINK_FILE, FileMode.Create, FileAccess.Write);
        var values = SymbolLinks.Values;
        JsonSerializer.Serialize(fileStream, values, values.GetType(), JSON_SERIALIZER_OPTIONS);
    }

    /// <summary>
    /// load symbol links từ file
    /// </summary>
    public void LoadSymbolLinks()
    {
        if (!File.Exists(SYMBOL_LINK_FILE))
        {
            return;
        }

        using FileStream fileStream = new(SYMBOL_LINK_FILE, FileMode.Open, FileAccess.Read);
        SymbolLinks.Clear();
        SymbolicLink[]? values = JsonSerializer.DeserializeAsync<SymbolicLink[]>(fileStream, JSON_SERIALIZER_OPTIONS).Result;

        if (values is null)
        {
            return;
        }

        foreach (var value in values)
        {
            SymbolLinks[value.Source] = value;
        }
    }

    public void Dispose()
    {
        _browserDialog.Dispose();
    }

    private bool RunCommandCreateSymbolicLink(string source, string destination)
    {
        ProcessStartInfo psi = new()
        {
            FileName = "cmd.exe",
            Arguments = $"/c mklink /D \"{source}\" \"{destination}\"",
            Verb = "runas", // Mở với quyền Admin (hiện bảng xác nhận UAC)
            UseShellExecute = true, // Đảm bảo là chạy với shell
            CreateNoWindow = false, // Hiển thị cửa sổ cmd khi chạy
        };

        try
        {
            Process.Start(psi);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    public bool ConnectNetworkDrive(string driveLetter, string remotePath, string username, string password)
    {
        return DriveUtilities.MapNetworkDrive(driveLetter, remotePath, username, password);
    }
}

public class SymbolicLink
{
    public string Source { get; set; }
    public string Destination { get; set; }
    public bool IsUnsymbol { get; set; }
}