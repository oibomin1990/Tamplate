namespace MFU.Models
{
    public class RequestFee : EntityBase
    {
        //Table: STUDENT_DOC_FEE
        public RequestType RequestType { get; set; }
        public decimal FeeID { get; set; }
        public string FeeName { get; set; }
        public string FeeNameEng { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public decimal Balance { get; set; }

    }
}