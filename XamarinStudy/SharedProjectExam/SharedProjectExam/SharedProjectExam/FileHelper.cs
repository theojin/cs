using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProjectExam
{
    public class FileHelper
    {
        public static string FilePath
        {
            get
            {
                string path = string.Empty;
#if __IOS__
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                path = System.IO.Path.Combine(docFolder, "..", "Library");
#elif __ANDROID__
                path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#elif WINDOWS_UWP
                path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
#endif
                return path;
            }
            set
            {

            }
        }
    }
}
