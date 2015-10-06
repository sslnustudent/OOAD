using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Model
{
    class Registry
    {
        private Repository repository;

        private List<Member> memberList;

        private List<Boat> boatList;

        public int GetMemberListNumber(int id) 
        {
            for (int i = 1; i <= GetNumberOfMembers(); i++)
            {
                if (id == memberList[i - 1].memberID)
                {
                    return i - 1;
                }
            }
            return 0;
        }

        public int GetBoatListNumber(int id)
        {
            for (int i = 1; i <= GetNumberOfBoats(); i++)
            {
                if (id == boatList[i - 1].boatID)
                {
                    return i - 1;
                }
            }
            return 0;
        }

        public int GetNumberOfMembers() 
        {
            return memberList.Count;
        }

        public int GetNumberOfBoats() 
        {
            return boatList.Count;
        }

        public bool CheckBoatOwner(int i, int id)
        {
            if (id == boatList[i].ownerID)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public string GetMemberName(int listnumber) 
        {
            return memberList[listnumber].name;
        }

        public string GetMemberPersonalNumber(int listnumber) 
        {
            return memberList[listnumber].personalNumber;
        }

        public int GetBoatID(int listnumber)
        {
            return boatList[listnumber].boatID;
        }

        public int GetMemberID(int listnumber)
        {
            return memberList[listnumber].memberID;
        }

        public string GetBoatName(int listnumber) 
        {
            return boatList[listnumber].name;
        }

        public string GetBoatType(int listnumber) 
        {
            return boatList[listnumber].type;
        }

        public int GetBoatLength(int listnumber)
        {
            return boatList[listnumber].length;
        }

        public int GetMemberNumberOfBoats(int listnumber)
        {
            int i = 0;
            int id = memberList[listnumber].memberID;

            foreach (Boat b in boatList)
            {
                if (b.ownerID == id)
                { 
                    i++;
                }
            }

            return i;
        }

        public void AddMember(string name, string number)
        {
            int id = 0;
            for (int i = 1; i <= GetNumberOfMembers(); i++)
            {
                if(id < memberList[i - 1].memberID)
                {
                    id = memberList[i - 1].memberID;
                }
            }
            id++;
            Member member = new Member(name, number, id);

            memberList.Add(member);
        }

        public void DeleteMember(int id)
        {
            int i = GetMemberListNumber(id);
            memberList.Remove(memberList[i]);

            //Deleting the members boats
            for (int a = 1; a <= GetNumberOfBoats(); a++)
            {
                if (CheckBoatOwner(a - 1, id) == true)
                {

                    DeleteBoat(GetBoatID(a - 1));
                }
            }

        }

        public void EditMember(int id, string name, string number)
        {
            int i = GetMemberListNumber(id);
            memberList[i].name = name;
            memberList[i].personalNumber = number;

        }

        public void AddBoat(string name, int ownerid, string type, int length)
        {

            int id = 0;
            for (int i = 1; i <= GetNumberOfBoats(); i++)
            {
                if (id < boatList[i - 1].boatID)
                {
                    id = boatList[i - 1].boatID;
                }
            }
            id++;
            Boat boat = new Boat(name, ownerid, id, type, length);

            boatList.Add(boat);
        }

        public void DeleteBoat(int id)
        {
            int i = GetBoatListNumber(id);
            boatList.Remove(boatList[i]);

        }

        public void EditBoat(int id, string name, int ownerid, string type, int length)
        {
            int i = GetBoatListNumber(id);
            boatList[i].name = name;
            boatList[i].ownerID = ownerid;
            boatList[i].type = type;
            boatList[i].length = length;
        }

        public Registry() 
        {
            repository = new Repository();
            memberList = repository.LoadMembers();
            boatList = repository.LoadBoats();

        }

        public void SaveLists() 
        {
            repository.SaveMembers(memberList);
            repository.SaveBoats(boatList);
        }
    }
}
