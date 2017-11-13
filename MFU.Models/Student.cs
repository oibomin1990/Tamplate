using System;

namespace MFU.Models
{
    public class Student
    {
        //Table: STUDENTMASTER
        public decimal StudentId { get; set; }
        public decimal StudentCode { get; set; }
        public string StudentName { get; set; }
        public string prefixname { get; set; }
        public string prefixnameeng { get; set; }
        public string StudentSurname { get; set; }
        public string StudentNameEng { get; set; }
        public string StudentSurnameEng { get; set; }
        public string CitizenID { get; set; }
        public string FacultyNameEng { get; set; }
        public string DepartmentNameEng { get; set; }
        public decimal StudentStatus { get; set; }
        public DateTime FinishDate { get; set; }

    }
}
