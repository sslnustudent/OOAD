using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Controller
{
    class User
    {

        public void RunApplication(View.ConsoleView c_view, Model.Registry c_reg)
        {
            bool quit = false;
            int menuChoice;
            int boatMenuChoice;
            int listnumber;

            while (quit == false)
            {
                try
                {

                    menuChoice = c_view.Menu();
                    switch (menuChoice)
                    {
                        //Quit
                        case 0:
                            quit = true;
                            break;
                        //Compact List
                        case 1:

                            for (int i = 1; i <= c_reg.GetNumberOfMembers(); i++)
                            {
                                c_view.CompactListMemberPrint(c_reg.GetMember(i - 1));
                            }
                            c_view.PressKeyToContinue();
                            break;
                        //Verbose List
                        case 2:

                            for (int i = 1; i <= c_reg.GetNumberOfMembers(); i++)
                            {
                                c_view.VerboseListMemberPrint(c_reg.GetMember(i - 1));
                            }
                            c_view.PressKeyToContinue();
                            break;
                        //Add Member
                        case 3:
                            c_reg.AddMember(c_view.AddMember());
                            c_view.PressKeyToContinue();
                            c_reg.SaveLists();
                            break;
                        //Delete Member
                        case 4:
                            for (int i = 1; i <= c_reg.GetNumberOfMembers(); i++)
                            {
                                c_view.SelectListMember(c_reg.GetMember(i - 1), i);
                            }
                            c_reg.DeleteMember(c_view.SelectMember());
                            c_view.PressKeyToContinue();
                            c_reg.SaveLists();
                            break;
                        //Edit Member
                        case 5:
                            for (int i = 1; i <= c_reg.GetNumberOfMembers(); i++)
                            {
                                c_view.SelectListMember(c_reg.GetMember(i - 1), i);
                            }
                            listnumber = c_view.SelectMember();
                            c_reg.EditMember(listnumber, c_view.AddMember());
                            c_reg.SaveLists();
                            break;
                        case 6:
                        //View Member
                            for (int i = 1; i <= c_reg.GetNumberOfMembers(); i++)
                            {
                                c_view.SelectListMember(c_reg.GetMember(i - 1), i);
                            }
                            listnumber = c_view.SelectMember();
                            c_view.VerboseListMemberPrint(c_reg.GetMember(listnumber));
                            boatMenuChoice = c_view.BoatMenu();
 
                            switch (boatMenuChoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    //Add Boat
                                    c_reg.AddBoat(c_view.AddBoat(), listnumber);
                                    c_reg.SaveLists();
                                    break;
                                case 2:
                                    //Delete Boat
                                    c_reg.DeleteBoat(c_view.SelectBoat(c_reg.GetMember(listnumber)), listnumber);
                                    c_reg.SaveLists();
                                    break;
                                //Edit Boat
                                case 3:
                                    c_reg.EditBoat(c_view.SelectBoat(c_reg.GetMember(listnumber)), listnumber, c_view.AddBoat());
                                    c_reg.SaveLists();
                                    break;
                            }
                            break;
                    }
                }
                catch
                {
                    c_view.ErrorMessege();
                }
            }
        }
    }
}
