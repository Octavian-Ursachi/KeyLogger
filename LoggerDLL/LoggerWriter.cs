﻿/*
* Author: Ursachi Octavian
* Date: 26.05.2024
* Functionality: This class library provides functionality for logging keystrokes and handling different strategies for logging.
*/


using System;
using System.Windows.Forms;
using static VirtualKeyCodes;

namespace LoggerDLL
{
    public class LoggerWriter
    {
        private static ILoggerWriter _writer = new VKCodeStrategy();

        public void SetStrategy(ILoggerWriter strategy)
        {
            _writer = strategy;
        }
        public void HandleVK(int vkCode, String path, TextBox text)
        {
            _writer.WriteToLog(vkCode, path, text);
        }
    }

    public class VKCodeStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TextBox form)
        {
            Console.WriteLine(vkCode);
            form.AppendText("0x"+vkCode.ToString("X")+" ");
            

        }
    }

    public class ToStringStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TextBox form)
        {
            Console.WriteLine((Keys)vkCode);
            form.AppendText((Keys)vkCode + "");
        }
    }

    public class ToCharStrategy : ILoggerWriter
    {
        public void WriteToLog(int vkCode, string path, TextBox form)
        {
            Console.WriteLine((char)vkCode);
            form.AppendText((char)vkCode + "");
        }
    }

    public class SmartStrategy : ILoggerWriter
    {
        static bool isShift;
        static bool isCapital;
        public void WriteToLog(int vkCode, string path, TextBox text)
        {
            switch (vkCode)
            {
                case VK_BACK:
                    {
                        if (text.Text.Length > 0)
                        {
                            text.Text = text.Text.Remove(text.Text.Length - 1);
                        }
                        break;
                    }
                case VK_RETURN:
                    {
                        text.AppendText("\r\n");
                        break;
                    }
                case VK_CAPITAL:
                    {
                        isCapital = !isCapital;
                        break;
                    }
                case VK_LSHIFT:
                    { 
                    isShift = !isShift;
                    break;
                    }
                case VK_RSHIFT: {
                    isShift = !isShift;
                    break; }
                case VK_0:
                    {
                        if (isShift)
                            text.AppendText(")");
                        else
                            text.AppendText("0");
                        break;
                    }
                case VK_1:
                    {
                        if (isShift)
                            text.AppendText("!");
                        else
                            text.AppendText("1");
                        break;
                    }
                case VK_2:
                    {
                        if (isShift)
                            text.AppendText("@");
                        else
                            text.AppendText("2");
                        break;
                    }
                case VK_3:
                    {
                        if (isShift)
                            text.AppendText("#");
                        else
                            text.AppendText("3");
                        break;
                    }
                case VK_4:
                    {
                        if (isShift)
                            text.AppendText("$");
                        else
                            text.AppendText("4");
                        break;
                    }
                case VK_5:
                    {
                        if (isShift)
                            text.AppendText("%");
                        else
                            text.AppendText("5");
                        break;
                    }
                case VK_6:
                    {
                        if (isShift)
                            text.AppendText("^");
                        else
                            text.AppendText("6");
                        break;
                    }
                case VK_7:
                    {
                        if (isShift)
                            text.AppendText("&");
                        else
                            text.AppendText("7");
                        break;
                    }
                case VK_8:
                    {
                        if (isShift)
                            text.AppendText("*");
                        else
                            text.AppendText("8");
                        break;
                    }
                case VK_9:
                    {
                        if (isShift)
                            text.AppendText("(");
                        else
                            text.AppendText("9");
                        break;
                    }
                case VK_OEM_1:
                    {
                        if (isShift)
                            text.AppendText(":");
                        else
                            text.AppendText(";");
                        break; 
                    }
                case VK_OEM_2:
                    {
                        if (isShift)
                            text.AppendText("?");
                        else
                            text.AppendText("/");
                        break;
                    }
                case VK_OEM_3:
                    {
                        if (isShift)
                            text.AppendText("~");
                        else
                            text.AppendText("`");
                        break;
                    }
                case VK_OEM_4:
                    {
                        if (    isShift )
                            text.AppendText("{");
                        else
                            text.AppendText("[");
                        break;
                    }
                case VK_OEM_5:
                    {
                        if (isShift)
                            text.AppendText(@"\");
                        else
                            text.AppendText("|");
                        break;
                    }
                case VK_OEM_6:
                    {
                        if (isShift)
                            text.AppendText("}");
                        else
                            text.AppendText("]");
                        break;
                    }
                case VK_OEM_7:
                    {
                        if (isShift)
                            text.AppendText(@"""");
                        else
                            text.AppendText("'");
                        break;
                    }
                case VK_OEM_PERIOD:
                    {
                        if (isShift)
                            text.AppendText(">");

                        else
                            text.AppendText(".");
                        break;
                    }
                case VK_OEM_COMMA:
                    {
                        if (isShift)
                            text.AppendText("<");
                        else
                            text.AppendText(",");
                        break;
                    }
                case VK_OEM_PLUS:
                    {
                        if (isShift)
                            text.AppendText("+");
                        else
                            text.AppendText("=");
                        break;
                    }
                case VK_OEM_MINUS:
                    {
                        if (isShift)
                            text.AppendText("_");
                        else
                            text.AppendText("-");
                        break;
                    }
                default:
                    {                         
                        if ((isShift || isCapital) && vkCode >= VK_A && vkCode <= VK_Z)
                        {
                            text.AppendText((char)(vkCode) + "");
                        }
                        else if (!isCapital && vkCode >= VK_A && vkCode <= VK_Z)
                        {
                            text.AppendText((char)(vkCode + 32) + "");
                        }
                        else
                            text.AppendText((char)vkCode + "");
                        Console.WriteLine((Keys)vkCode);
                        break;
                    }

            }
        }

    }
}

