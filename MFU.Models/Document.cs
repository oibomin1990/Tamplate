using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models
{
    public class Document : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
