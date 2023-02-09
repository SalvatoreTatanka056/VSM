﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUsage
{
    public static class MouseHook

    {

        public static event EventHandler MouseAction = delegate {};

        public static void Start()
        {
            _hookID = SetHook(_proc);


        }
        public static void stop()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
                if (hook == IntPtr.Zero) throw new System.ComponentModel.Win32Exception();
                return hook;
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static void sendCallback(IntPtr lParam, String s)
        {
           
            MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            
            hookStruct.MouseAction = s;
            MouseAction(hookStruct, new EventArgs());
        }

        private static IntPtr HookCallback(
          int nCode, IntPtr wParam, IntPtr lParam)
        {
            
            if (nCode >= 0)
            {
                if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    sendCallback(lParam, "WM_LBUTTONDOWN");
                   
                }
                else if (MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
                {
                    sendCallback(lParam, "WM_LBUTTONUP");
                }
                else if (MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
                {
                    // move outcommented
                    //sendCallback(lParam, "WM_MOUSEMOVE");
                }
                else if (MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam)
                {
                  //  Console.WriteLine(" " + wParam + " " + lParam);

                    MSLLHOOKSTRUCT hookStruct = new MSLLHOOKSTRUCT();

                    hookStruct.MouseAction = "WM_MOUSEWHEEL";
                    MouseAction(hookStruct, new EventArgs());
                }
                else if (MouseMessages.WM_MOUSEWHEELDOWN == (MouseMessages)wParam)
                {
                      sendCallback(lParam, "WM_MOUSEWHEELDOWN");
                }
                else if (MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
                {
                    sendCallback(lParam, "WM_RBUTTONDOWN");
                }
                else if (MouseMessages.WM_RBUTTONUP == (MouseMessages)wParam)
                {
                    sendCallback(lParam, "WM_RBUTTONUP");
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEWHEELDOWN = 0x0207,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public string MouseAction;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

      

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


    }
}
