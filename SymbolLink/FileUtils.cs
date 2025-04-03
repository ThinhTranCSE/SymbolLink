using System.Runtime.InteropServices;

public class FileUtils
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public uint wFunc;
        public string pFrom;
        public string pTo;
        public ushort fFlags;
        public bool fAnyOperationsAborted;
        public IntPtr hNameMappings;
        public string lpszProgressTitle;
    }

    private const uint FO_COPY = 0x0002;
    private const ushort FOF_ALLOWUNDO = 0x0040;
    private const ushort FOF_NOCONFIRMMKDIR = 0x0200;

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

    public static void CopyFilesWithWindowsDialog(string sourceDir, string destDir)
    {
        if (string.IsNullOrWhiteSpace(sourceDir) || string.IsNullOrWhiteSpace(destDir))
        {
            MessageBox.Show("Đường dẫn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Đảm bảo đường dẫn kết thúc bằng ký tự null (bắt buộc đối với Windows API)
        string from = sourceDir + '\0';
        string to = destDir + '\0';

        SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT
        {
            wFunc = FO_COPY,      // Copy file
            pFrom = from,         // Đường dẫn nguồn
            pTo = to,             // Đường dẫn đích
            fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMMKDIR,
            hwnd = IntPtr.Zero
        };

        int result = SHFileOperation(ref fileOp);

        if (result != 0)
        {
            MessageBox.Show($"Lỗi khi sao chép file! Mã lỗi: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
