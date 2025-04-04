using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SymbolLink;
public class DriveUtilities
{
    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource,
        string lpPassword, string lpUsername, int dwFlags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);

    [StructLayout(LayoutKind.Sequential)]
    private struct NETRESOURCE
    {
        public int dwScope;
        public int dwType;
        public int dwDisplayType;
        public int dwUsage;
        public string lpLocalName;
        public string lpRemoteName;
        public string lpComment;
        public string lpProvider;
    }

    public static bool MapNetworkDrive(string driveLetter, string remotePath, string username, string password)
    {
        NETRESOURCE nr = new NETRESOURCE
        {
            dwType = 1, // RESOURCETYPE_DISK
            lpLocalName = driveLetter,
            lpRemoteName = remotePath
        };

        int result = WNetAddConnection2(ref nr, password, username, 0);

        if (result != 0)
        {
            MessageBox.Show($"Lỗi kết nối tới ổ mạng: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    public static bool DisconnectNetworkDrive(string driveLetter)
    {
        int result = WNetCancelConnection2(driveLetter, 0, true);

        if (result != 0)
        {
            MessageBox.Show($"Không thể ngắt kết nối ổ mạng: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    public static void AllowInsecureGuestLogin()
    {
        try
        {
            // Cấu hình Process để chạy command với quyền admin
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // Sử dụng cmd.exe
                Arguments = "/c reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation\\Parameters\" /v AllowInsecureGuestAuth /t REG_DWORD /d 1 /f", // Lệnh reg add
                Verb = "runas", // Chạy dưới quyền Administrator
                UseShellExecute = true // Đảm bảo dùng shell để thực thi
            };

            // Chạy command
            Process.Start(processStartInfo);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể chỉnh sửa registry để cho phép đăng nhập NAS không bảo mật:\n" + ex.Message,
                            "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }


    public static string[] GetAvailableDriveLetters()
    {
        var allLetters = Enumerable.Range('D', 23)  // D -> Z
            .Select(c => ((char)c) + ":")
            .ToList();

        var usedDrives = DriveInfo.GetDrives().Select(d => d.Name.Substring(0, 2)).ToHashSet();

        return allLetters.Where(letter => !usedDrives.Contains(letter)).Reverse().ToArray();
    }
}
