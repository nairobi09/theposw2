using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace thepos2
{
    internal class ClsWin32Api
    {
        // =====================================================
        // 윈도우 메시지 정의
        // =====================================================
        public const int WM_CLOSE = 0x0010;

        public const int WM_COPYDATA = 0x4A;
        public struct ST_COPYDATA
        {
            public IntPtr dwData;
            public int cdData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        [DllImport("user32.dll", EntryPoint = "RegisterWindowMessage", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int RegisterWindowsMessage(string lpString);

        [DllImport("user32.dll", EntryPoint = "SendMessage", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, int wParam, ref ST_COPYDATA lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageTimeout", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short SendMessageTimeout(int hwnd, int wMsg, int wParam, int lParam,
                                                     [MarshalAs(UnmanagedType.U4)] int fuFlags, [MarshalAs(UnmanagedType.U4)] int uTimeout,
                                                     [MarshalAs(UnmanagedType.U4)] ref int lpdwResult);

        [DllImport("user32.dll", EntryPoint = "PostMessage", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessage", ExactSpelling = false, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, int wParam, ref ST_COPYDATA lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(long hWnd);

        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpClassName, string lpCaptionName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(HandleRef handle, out RECT rct);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 GetWindowsDirectory(string Buffer, Int32 BufferLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern long GetVolumeInformation
        (
            string driveLetter,
            StringBuilder volumeNameStringBuilder,
            uint volumeNameSize,
            ref uint volumeSerialNumber,
            ref uint maximumComponentLength,
            ref uint fileSystemFlag,
            StringBuilder fileSystemNameStringBuilder,
            uint fileSystemNameSize
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetGuiResources(IntPtr hProcess, int uiFlags);


        #region " 키보드입력제어"

        [DllImport("imm32.dll")]
        public extern static IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32.dll")]
        public extern static bool ImmGetConversionStatus(IntPtr hImc, out int lpdw, out int lpdw2);

        [DllImport("imm32.dll")]
        public static extern int ImmSetConversionStatus(IntPtr hImc, int dw1, int dw2);

        [DllImport("imm32.dll")]
        public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hImc);

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hImc);

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
