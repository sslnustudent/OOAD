using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Controller
{
    class User
    {

        public void Start(View.ConsoleView consoleView, Model.Registry registry)
        {
            bool quit = false;

            int menuChoice;
            string name;
            string number;
            int id;

            int boatid;
            string boatname;
            int ownerid;
            string type;
            int length;

            while (quit == false)
            {
                try
                {
                    consoleView.Menu();
                    menuChoice = int.Parse(Console.ReadLine());
                    switch (menuChoice)
                    {
                        //Quit
                        case 0:
                            registry.SaveLists();
                            quit = true;
                            break;
                        //Compact List
                        case 1:

                            for (int i = 1; i <= registry.GetNumberOfMembers(); i++)
                            {
                                consoleView.CompactListMemberPrint(registry.GetMemberName(i - 1), registry.GetMemberID(i - 1), registry.GetMemberNumberOfBoats(i - 1));
                            }
                            ;
                            break;
                        //Verbose List
                        case 2:

                            for (int i = 1; i <= registry.GetNumberOfMembers(); i++)
                            {
                                consoleView.VerboseListMemberPrint(registry.GetMemberName(i - 1), registry.GetMemberPersonalNumber(i - 1), registry.GetMemberID(i - 1));

                                for (int a = 1; a <= registry.GetNumberOfBoats(); a++)
                                {
                                    if (registry.CheckBoatOwner(a - 1, registry.GetMemberID(i - 1)) == true)
                                    {
                                        consoleView.VerboseListBoatPrint(registry.GetBoatName(a - 1), registry.GetBoatType(a - 1), registry.GetBoatLength(a - 1), registry.GetBoatID(a - 1));
                                    }
                                }
                            }

                            break;
                        //Add Member
                        case 3:
                            consoleView.AddMemberName();
                            name = Console.ReadLine();
                            consoleView.AddMemberPersonalNumber();
                            number = Console.ReadLine();
                            registry.AddMember(name, number);

                            break;
                        //Delete Member
                        case 4:
                            consoleView.SelectMemberById();
                            registry.DeleteMember(Convert.ToInt32(Console.ReadLine()));
                            break;
                        //Edit Member
                        case 5:
                            consoleView.SelectMemberById();
                            id = Convert.ToInt32(Console.ReadLine());
                            consoleView.AddMemberName();
                            name = Console.ReadLine();
                            consoleView.AddMemberPersonalNumber();
                            number = Console.ReadLine();
                            registry.EditMember(id, name, number);

                            break;
                        case 6:
                        //View Member
                            consoleView.SelectMemberById();
                            id = Convert.ToInt32(Console.ReadLine());
                            ownerid = registry.GetMemberListNumber(id);
                            consoleView.VerboseListMemberPrint(registry.GetMemberName(id), registry.GetMemberPersonalNumber(id), registry.GetMemberID(id));
                            for (int a = 1; a <= registry.GetNumberOfBoats(); a++)
                            {
                                if (registry.CheckBoatOwner(a - 1, id) == true)
                                {
                                    consoleView.VerboseListBoatPrint(registry.GetBoatName(a - 1), registry.GetBoatType(a - 1), registry.GetBoatLength(a - 1), registry.GetBoatID(a - 1));
                                }
                            }

                            break;
                        case 7:
                        //Add Boat
                            consoleView.AddBoatName();
                            boatname = Console.ReadLine();
                            consoleView.AddBoatOwner();
                            ownerid = Convert.ToInt32(Console.ReadLine());
                            consoleView.AddBoatType();
                            type = Console.ReadLine();
                            consoleView.AddBoatLength();
                            length = Convert.ToInt32(Console.ReadLine());
                            registry.AddBoat(boatname, ownerid, type, length);
                            break;
                        case 8:
                        //Delete Boat
                            consoleView.SelectBoatById();
                            registry.DeleteBoat(Convert.ToInt32(Console.ReadLine()));
                            break;
                        //Edit Boat
                        case 9:
                            consoleView.SelectBoatById();
                            boatid = Convert.ToInt32(Console.ReadLine());
                            consoleView.AddBoatName();
                            boatname = Console.ReadLine();
                            consoleView.AddBoatOwner();
                            ownerid = Convert.ToInt32(Console.ReadLine());
                            consoleView.AddBoatType();
                            type = Console.ReadLine();
                            consoleView.AddBoatLength();
                            length = Convert.ToInt32(Console.ReadLine());
                            registry.EditBoat(boatid, boatname, ownerid, type, length);
                            break;

                    }
                }
                catch 
                {
                    consoleView.ErrorMessege();
                }
                consoleView.PressKeyToContinue();
                Console.ReadKey();

            }
        }
    }
}
