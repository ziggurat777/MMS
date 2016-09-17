using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMS.Models
{
    public class MemberResopnse
    {
        public List<Member> MemberList { get; set; }

        public bool State { get; set; }

        public string Message { get; set; }
    }
}