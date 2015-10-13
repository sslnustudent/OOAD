using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Model
{
    class Boat
    {
        public string name { get; set; }
        public string type{ get; set; }
        public int length { get; set; }

        public Boat() 
        { }

        public Boat(string a_name) 
        {
            name = a_name;
        }

        public Boat(string a_name, string a_type, int a_length)
        {
            name = a_name;
            type = a_type;
            length = a_length;
        }

    }
}
