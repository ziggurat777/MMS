using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string EmailAdderss { get; set; }
        public string PhoneNumber { get; set; }
    }
}