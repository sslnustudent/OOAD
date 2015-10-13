using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Registry reg =  new Model.Registry();
            Controller.User user = new Controller.User();
            View.ConsoleView con = new View.ConsoleView();

            user.RunApplication(con, reg);
        }
    }
}
