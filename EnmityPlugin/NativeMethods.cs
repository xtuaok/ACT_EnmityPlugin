using System;
using System.Runtime.InteropServices;

namespace Tamagawa.EnmityPlugin
{
    static class NativeMethods
    {
        // ReadProcessMemory
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, ref IntPtr lpNumberOfBytesRead);
    }
}
