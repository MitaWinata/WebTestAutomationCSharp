using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;

namespace SupportLibraries
{
    public static class Helpers
    {
        public static void ClearTestResults()
        {
            DirectoryInfo di = new DirectoryInfo(GetTestResultFolder());
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete(); 
            }
        }
        public static int ClearChromeLocalData()
        {
            string path = Path.Combine(
                GetTestBinaryAbsolutePath() +
                @"/../../../../SupportLibraries/scripts",
                "clearChromeLocalData.bat"
            );

            ProcessStartInfo info = new ProcessStartInfo(
                                          path
                                        );
            info.WindowStyle = ProcessWindowStyle.Hidden;
            //info.Arguments = serverAddress + " " +
            //    serverPort + " " +
            //    boostrapPort + " " +
            //    phoneUUID + " " +
            //    appiumLogPath;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            System.Threading.Thread.Sleep(5000);
            return p.Id;
        }
        public static void KillProcess(string processName)
        {
            var process = Process.GetProcessesByName(processName);
            foreach (Process nextProcess in process)
            {
                nextProcess.Kill();
            }
        }
        public static void TakeScreenshot(IWebDriver driver, string filename)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filename, ImageFormat.Png);
        }
        public static string GetTestResultFolder()
        {
            return Path.Combine(
                   GetTestBinaryAbsolutePath() +
                   @"/../../../../TestResults/"
               );
        }
        public static string GetBinaryPath()
        {
            string binaryName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(
                GetTestBinaryAbsolutePath() + @"\..\" + binaryName
            );
        }
        public static string GetTestBinaryAbsolutePath()
        {
            return ((new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
        }
    }
}