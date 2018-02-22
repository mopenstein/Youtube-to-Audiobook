using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ini
{
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string dapath)
        {
            path = dapath;
        }

        public void IniWriteValue(string sec, string key, string val)
        {
            WritePrivateProfileString(sec, key, val, this.path);
        }

        public string IniReadValue(string sec, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(sec, key, "", temp, 255, this.path);
            return temp.ToString();

        }
    }
}