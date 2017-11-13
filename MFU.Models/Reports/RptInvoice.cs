using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models.Reports
{
    public class RptInvoice : EntityBase
    {
        //VIEW_RPTINV_DOC_REQUEST
        public string RequestTypeName { get; set; }
        public string RequestTypeNameEng { get; set; }
        public string FeeName { get; set; }
        public string FeeNameEng { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Moo { get; set; }
        public string Village { get; set; }
        public string Lane { get; set; }
        public string Road { get; set; }
        public string CountryNameEng { get; set; }
        public string ProvinceNameEng { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }

    }
}