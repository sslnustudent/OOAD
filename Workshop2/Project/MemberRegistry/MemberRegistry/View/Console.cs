using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistry.Model;

namespace MemberRegistry.View
{
    class ConsoleView
    {
        public int Menu() 
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================");
            Console.WriteLine("             Member Registry                ");
            Console.WriteLine("============================================\n");
            Console.ResetColor();
            Console.WriteLine("0. Quit.\n");
            Console.WriteLine("-Lists-------------------------------------\n");
            Console.WriteLine("1. Compact List.");
            Console.WriteLine("2- Verbose List.\n");
            Console.WriteLine("-Members-----------------------------------\n");
            Console.WriteLine("3. Add Member.");
            Console.WriteLine("4. Delete Member.");
            Console.WriteLine("5. Edit Member.");
            Console.WriteLine("6. View Member.\n");
            Console.WriteLine("============================================\n");
            Console.Write("Chose option [0-9]: ");
            return int.Parse(Console.ReadLine());
        }

        public void PressKeyToContinue() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n  Press any key to continue   ");
            Console.ResetColor();
            Console.ReadKey();
        }

        public int SelectMember() 
        {
            Console.WriteLine("Select a member: ");
            return Convert.ToInt32(Console.ReadLine()) - 1;
        }

        public int SelectBoat(Member v_member) 
        {
            for (int i = 1; i <= v_member.boatlist.Count; i++)
            {
                SelectListBoat(v_member.boatlist[i - 1], i - 1);
            }

            Console.WriteLine("Write the boat number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int BoatMenu() 
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================");
            Console.WriteLine("             Member Registry                ");
            Console.WriteLine("============================================\n");
            Console.ResetColor();
            Console.WriteLine("-Boats-------------------------------------\n");
            Console.WriteLine("0. Go back");
            Console.WriteLine("1. Add Boat");
            Console.WriteLine("2. Delete Boat.");
            Console.WriteLine("3. Edit Boat.\n");
            Console.WriteLine("============================================\n");
            Console.Write("Chose option [0-3]: ");
            return int.Parse(Console.ReadLine());
        }

        public Member AddMember() 
        {
            Console.WriteLine("Write the member name: ");
            Member v_member = new Member(Console.ReadLine());
            if (v_member.name == "")
            {
                ErrorMessege();
                return null; 
            }
            Console.WriteLine("The format of personal number is xxxxxxxxxx\nExample: 9101049121");
            Console.WriteLine("Write the member personal number: ");
            v_member.personalNumber = Console.ReadLine();
            if (v_member.personalNumber == "")
            { return null; }
            foreach (char c in v_member.personalNumber)
            {
                if (c < '0' || c > '9')
                { 
                    ErrorMessege();
                    return null; 
                }
            }
            if (v_member.personalNumber.Length != 10)
            {
                ErrorMessege();
                return null;
            }
            v_member.boatlist = new List<Boat>();
            return v_member;
        }

        public Boat AddBoat() 
        {
            Console.WriteLine("Write the boat name: ");
            Boat v_boat = new Boat(Console.ReadLine());
            if (v_boat.name == "")
            {
                ErrorMessege();
                return null; 
            }
            v_boat.type = SelectBoatType();
            if (v_boat.type == "")
            {
                ErrorMessege();
                return null; 
            }
            Console.WriteLine("Write the boat length: ");
            v_boat.length = int.Parse(Console.ReadLine());
            return v_boat;
        }

        public string SelectBoatType() 
        {
            Console.WriteLine("0. Sailboat");
            Console.WriteLine("1. Motorsailer");
            Console.WriteLine("2. Kayak/Canoe");
            Console.WriteLine("3. Other\n");
            Console.Write("Chose boat type: ");
            int selectedType = int.Parse(Console.ReadLine());
            switch (selectedType) 
            {
                case 0:
                    return "Sailboat";
                case 1:
                    return "Motorsailer";
                case 2:
                    return "Kayak/Canoe";
                case 3:
                    return "Other";
            }
            return null;
        }

        public void CompactListMemberPrint(Member v_member)
        {
            Console.WriteLine("Name: {0}    Member-ID: {1}  Number of boats: {2}", v_member.name, v_member.memberID, v_member.boatlist.Count);
        }

        public void SelectListMember(Member v_member, int listnumber)
        {
            Console.WriteLine("{0}. Name: {1}    Member-ID: {2}", listnumber, v_member.name, v_member.memberID);
        }

        public void SelectListBoat(Boat v_boat, int lisnumber)
        {
            Console.WriteLine("{0}. Name: {1}    Type: {2}  Length{3}", lisnumber,v_boat.name, v_boat.type, v_boat.length);
        }

        public void VerboseListMemberPrint(Member v_member)
        {
            Console.WriteLine("\n-Member-------------------------------------------------------\n");
            Console.WriteLine("Name: {0} Personal Number:   {1}   Member-ID:  {2}\n", v_member.name, v_member.personalNumber, v_member.memberID);
            Console.WriteLine("-Boats--------------------------------------------------------\n");
            for (int i = 1; i <= v_member.boatlist.Count; i++)
            {
                    VerboseListBoatPrint(v_member.boatlist[i - 1]);
            }
        }

        public void VerboseListBoatPrint(Boat v_boat)
        {
            Console.WriteLine("Name of Boat: {0}    Type of Boat: {1}   Boat Length: {2}", v_boat.name, v_boat.type, v_boat.length);
        }

        public void ErrorMessege() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   Error something went wrong  ");
            Console.WriteLine("-------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
