using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Model
{
    class Member
    {
        public string name { get; set; }
        public string personalNumber { get; set; }
        public int memberID { get; set; }

        public Member() 
        { }

        public Member(string a_name) 
        {
            name = a_name;
        }
        public Member(string a_name, string a_personalNumber, int id)
        {
            name = a_name;
            personalNumber = a_personalNumber;
            memberID = id;
        }

    }
}
