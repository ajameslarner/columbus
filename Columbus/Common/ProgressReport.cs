using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.Common
{
    public class ProgressReport
    {
        public string Text { get; set; }
        public int Progress { get; set; }
        public ProgressReport(string text, int progress = 0)
        {
            Text = text;
            Progress = progress;
        }
    }
}
