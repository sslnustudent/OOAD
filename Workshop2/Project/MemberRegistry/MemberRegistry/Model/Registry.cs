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

        public int GetNumberOfMembers() 
        {
            return memberList.Count;
        }

        public Member GetMember(int listnumber)
        {
            return memberList[listnumber];
        }

        public void AddMember(Member m_member)
        {
            if (m_member == null)
            {
                return;
            }

            int id = 0;
            for (int i = 1; i <= GetNumberOfMembers(); i++)
            {
                if(id < memberList[i - 1].memberID)
                {
                    id = memberList[i - 1].memberID;
                }
            }
            id++;
            m_member.memberID = id;

            memberList.Add(m_member);
        }

        public void DeleteMember(int listnumber)
        {
            memberList.Remove(memberList[listnumber]);
        }

        public void EditMember(int listnumber, Member m_member)
        {
            m_member.memberID = memberList[listnumber].memberID;
            memberList[listnumber] = m_member;
        }

        public void AddBoat(Boat m_boat, int memberlistnumber)
        {
            if (m_boat == null)
            {
                return;
            }
            memberList[memberlistnumber].boatlist.Add(m_boat);
        }

        public void DeleteBoat(int boatListNumber, int memberListNumber)
        {
            memberList[memberListNumber].boatlist.Remove(memberList[memberListNumber].boatlist[boatListNumber]);
        }

        public void EditBoat(int boatListNumber, int memberListNumber, Boat m_boat)
        {
            memberList[memberListNumber].boatlist[boatListNumber] = m_boat;
        }

        public Registry() 
        {
            repository = new Repository();
            memberList = repository.LoadMembers();
        }

        public void SaveLists() 
        {
            repository.SaveMembers(memberList);
        }
    }
}
