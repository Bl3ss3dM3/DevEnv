using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Service.ViewModel
{
    public class TableDataVM
    {
        public string name { get; set; }
        public List<string> headers { get; set; }
        public List<Dictionary<string, string>> data { get; set; }
    }
}