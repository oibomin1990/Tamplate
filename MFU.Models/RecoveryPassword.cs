using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models
{
    public class RecoveryPassword
    {
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}