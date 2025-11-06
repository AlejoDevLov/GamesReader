using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesReader.Services
{
    public class FileSystemService
    {
        private readonly string _basePath = "Data";

        public string GetData(string filename)
        {
            filename = filename.ToLower();
            string fullPath = Path.Combine(_basePath, filename);
            string data = File.ReadAllText(fullPath);
            return data;
        }
    }
}
