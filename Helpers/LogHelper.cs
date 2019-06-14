﻿using SRSAutoFramework.Config;
using System;
using System.IO;

using SRSAutoFramework.Exceptions;

namespace SRSAutoFramework.Helpers
{
    public class LogHelper
    {
        //Global Declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //Create a file which can store the log information
        public static void CreateLogFile(String TestName)
        {
            if(Settings.LogPath == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            string dir = Settings.LogPath;
            //string dir = @"C:\Users\ntyagi\source\repos\MLUI\MAIN\Test\MLAnyWhereAutoTest\Logs\";
            // string dir = @"C:\SRSUI\MAIN\Test\SRSAnywhereAutoTest\Logs\";
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + TestName + "_" + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + TestName + "_" + _logFileName + ".log");
            }
        }



        //Create a method which can write the text in the log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }

        public static void LogException(Exception exception)
        {
            ExceptionLogType exceptionLogType;
            //SRSException srsException = new SRSException("AutomationException:" + exception.Message, exception);
            Enum.TryParse<ExceptionLogType>(Settings.ExceptionDestinationType.ToString(), out exceptionLogType);
            switch (Convert.ToInt16(Settings.ExceptionDestinationType))//
            {
                case 1:
                    new ExceptionLogger().WriteExceptionToFile(Settings.ExceptionFilePath, exception);
                    break;
                case 0:
                default:
                    //EventLog.WriteErrorEntry(exception);
                    break;

            }
        }
    }
}
