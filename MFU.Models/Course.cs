namespace MFU.Models
{
    public class Course : EntityBase
    {
        //Table: ENROLLSUMMARY
        public decimal CourseID { get; set; }
        public decimal CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseNameEng { get; set; }
    }
}