using MFU.Models.Enums;

namespace MFU.Models
{
    public class RequestDetail : EntityBase
    {
        //Table: REQUEST
        public RequestType RequestType { get; set; }
        public ServiceType ServiceType { get; set; }
        public decimal Amount
        {
            get
            {
                if (RequestType != null)
                    return Quantity * RequestType.Price;
                return 0;

            }
        }
        public decimal Quantity { get; set; }
        public string FileAttachName { get; set; }
        public decimal OutNumStatus { get; set; }
        public decimal RefOut { get; set; }
    }
}
