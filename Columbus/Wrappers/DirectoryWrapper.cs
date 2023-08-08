using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.Wrappers
{
    interface IDirectoryWrapper
    {
        IEnumerable<string> EnumerateFiles(string path);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption option);
    }
    internal class DirectoryWrapper : IDirectoryWrapper
    {
        public IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption option)
        {
            try
            {
                return Directory.EnumerateFiles(path, searchPattern, option);
            }
            catch (UnauthorizedAccessException ex)
            { 
                return Enumerable.Empty<string>();
            }
        }
    }
}
