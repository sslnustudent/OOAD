using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.View
{
    class ConsoleView
    {
        public void Menu() 
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================");
            Console.WriteLine("             Member Registry                ");
            Console.WriteLine("============================================\n");
            Console.ResetColor();
            Console.WriteLine("0. Save and Quit.\n");
            Console.WriteLine("-Lists-------------------------------------\n");
            Console.WriteLine("1. Compact List.");
            Console.WriteLine("2- Verbose List.\n");
            Console.WriteLine("-Members-----------------------------------\n");
            Console.WriteLine("3. Add Member.");
            Console.WriteLine("4. Delete Member.");
            Console.WriteLine("5. Edit Member.");
            Console.WriteLine("6. View Member.\n");
            Console.WriteLine("-Boats-------------------------------------\n");
            Console.WriteLine("7. Add Boat");
            Console.WriteLine("8. Delete Boat.");
            Console.WriteLine("9. Edit Boat.\n");
            Console.WriteLine("============================================\n");


            Console.Write("Chose option [0-9]: ");
        }

        public void PressKeyToContinue() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n  Press any key to continue   ");
            Console.ResetColor();
        }

        public void SelectMemberById() 
        {
            Console.WriteLine("Write the member id: ");
        }

        public void SelectBoatById()
        {
            Console.WriteLine("Write the boat id: ");
        }

        public void AddMemberName() 
        {
            Console.WriteLine("Write the member name: ");
        }

        public void AddMemberPersonalNumber()
        {
            Console.WriteLine("Write the member personal number: ");
        }

        public void AddBoatName() 
        {
            Console.WriteLine("Write the boat name: ");
        }

        public void AddBoatOwner()
        {
            Console.WriteLine("Write the boats owners id: ");
        }

        public void AddBoatType()
        {
            Console.WriteLine("Write the boat type: ");
        }

        public void AddBoatLength()
        {
            Console.WriteLine("Write boat length: ");
        }

        public void CompactListMemberPrint(string name, int id, int numberOfBoats)
        {
            Console.WriteLine("Name: {0}    Member-ID: {1}   Number of boats: {2}", name, id, numberOfBoats);
        }

        public void VerboseListMemberPrint(string memberName, string personID, int memberID)
        {
            Console.WriteLine("\n-Member-------------------------------------------------------\n");
            Console.WriteLine("Name: {0} Personal Number:   {1}   Member-ID:  {2}\n", memberName, personID, memberID);
            Console.WriteLine("-Boats--------------------------------------------------------\n");
        }

        public void VerboseListBoatPrint(string boatName, string boatType, int boatLength, int boatid)
        {
            Console.WriteLine("Name of Boat: {0}    Type of Boat: {1}\nBoat Length: {2}    BoatID: {3}", boatName, boatType, boatLength, boatid);
        }

        public void ErrorMessege() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   Error something went wrong  ");
            Console.WriteLine("-------------------------------");
            Console.ResetColor();
        }
    }
}
