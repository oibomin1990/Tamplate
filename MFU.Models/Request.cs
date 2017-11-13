using MFU.Models.Enums;
using System;
using System.Collections.Generic;
namespace MFU.Models
{
    public class Request : EntityBase
    {
        //Table: STUDENT_DOC_REQUEST_HD
        public List<RequestDetail> RequestDetail { get; set; }
        public decimal RequestStatus { get; set; }
        public DateTime PrintDate { get; set; }
        public DateTime RequestDatetimePay { get; set; }
        public decimal ReceiveNumber { get; set; }
        public string GraduateRequest { get; set; }
        public string TrackingNumber { get; set; }
        public ReceiveType ReceiveType { get; set; }
        public RequestType RequestType { get; set; }
    }
}
