namespace MFU.Models
{
    public class Address : EntityBase
    {
        //Table: STUDENT_DOC_ADDRESS
        public string ReceiveName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public decimal ProvinceID { get; set; }
        public decimal CountryID { get; set; }
        public decimal DistrictID { get; set; }
        public decimal SubDistrictID { get; set; }
        public decimal ZipCode { get; set; }
        public decimal TelephoneNumber { get; set; }
        public decimal MailingServiceType { get; set; }
    }
}
