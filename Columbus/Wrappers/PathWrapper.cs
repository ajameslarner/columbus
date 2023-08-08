using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.Wrappers
{
    interface IPathWrapper
    {
        string GetFileName(string path);
    }
    internal class PathWrapper : IPathWrapper
    {
        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
