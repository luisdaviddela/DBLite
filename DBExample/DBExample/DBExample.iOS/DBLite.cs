using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System;
using System.IO;
using DBExample.iOS;
[assembly: Xamarin.Forms.Dependency(typeof(DBLite))]
namespace DBExample.iOS
{
    public class DBLite : IDBLite
    {
        public string DatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, DB3.DATABASE_NAME);
        }
    }
}