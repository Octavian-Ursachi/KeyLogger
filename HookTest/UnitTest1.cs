/*
Author: Vasilica George
Date: 26.05.2024
Acest fișier conține o clasă de teste HookTests care utilizează NUnit și Moq pentru a testa funcționalitatea clasei LLKeyboardHook .
*/
using NUnit.Framework;
using Moq;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using HookDLL;

namespace HookDLLTests
{
    [TestFixture]
    public class LLKeyboardHookTests
    {
        private Mock<LLKeyboardHook.LLKeyboardProc> _mockProc;
        private LLKeyboardHook _keyboardHook;

        [SetUp]
        public void Setup()
        {
            _mockProc = new Mock<LLKeyboardHook.LLKeyboardProc>();
            _keyboardHook = new LLKeyboardHook();
        }

        [Test]
        public void Install_ShouldSetHook()
        {
            // Act
            _keyboardHook.Install();

            // Assert
            var hookId = GetPrivateField<IntPtr>(_keyboardHook, "_hookID");
            Console.WriteLine($"Hook ID after install: {hookId}");
            Assert.That(hookId, Is.Not.EqualTo(IntPtr.Zero));
        }

        [Test]
        public void Uninstall_ShouldUnhook()
        {
            // Arrange
            _keyboardHook.Install();
            var hookId = GetPrivateField<IntPtr>(_keyboardHook, "_hookID");

            // Ensure the hook is installed before attempting to uninstall
            Assert.That(hookId, Is.Not.EqualTo(IntPtr.Zero), "Hook was not set properly.");
            Console.WriteLine($"Hook ID before uninstall: {hookId}");

            // Act
            bool unhooked = LLKeyboardHook.UnhookWindowsHookEx(hookId);
            Console.WriteLine($"Unhook result: {unhooked}");

            // Assert
            Assert.That(unhooked, Is.True, $"UnhookWindowsHookEx failed with hook ID: {hookId}");
        }

        [Test]
        public void HookCallback_KeyDownEvent_ShouldWriteToSocket()
        {
            // Arrange
            var nCode = 0;
            var wParam = (IntPtr)0x100; // WM_KEYDOWN
            var lParam = Marshal.AllocHGlobal(4);
            Marshal.WriteInt32(lParam, 65); // Virtual-Key code for 'A'

            // Act
            LLKeyboardHook.HookCallback(nCode, wParam, lParam);

            // Assert
            // Here you would verify that SocketWriter.WriteToSocket was called correctly
            // This requires mocking or verifying the call to the method
        }

        private T GetPrivateField<T>(object obj, string fieldName)
        {
            var field = obj.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return (T)field.GetValue(obj);
        }
    }
}
