using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models
{
    public class RequestType : EntityBase
    {
        public decimal RequestTypeID { get; set; }
        public string RequestTypeName { get; set; }
        public string RequestTypeNameEng { get; set; }
        public decimal FeeID { get; set; }
        public decimal Price { get; set; }
    }
}
