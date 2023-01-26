using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Service.ViewModel
{
    public class RequestPDFVM
    {
        public Guid TemplateId { get; set; }
        public List<Dictionary<string, string>> OneToOneData { get; set; }
        public List<TableDataVM> TableData { get; set; }
    }
}