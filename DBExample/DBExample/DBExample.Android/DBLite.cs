using DBExample.Droid;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(DBLite))]
namespace DBExample.Droid
{
    public class DBLite : IDBLite
    {
        public string DatabasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DB3.DATABASE_NAME);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}