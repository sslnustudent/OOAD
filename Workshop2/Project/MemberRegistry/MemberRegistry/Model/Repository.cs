using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.Model
{
    class Repository
    {
         
        enum MemberReadStatus
        {
            Indefinite,
            Name,
            PersonalNumber,
            MemberID,
            BoatName,
            Type,
            Length
        }

        enum BoatReadStatus
        {
            Indefinite,
            Name,
            OwnerID,
            BoatID,
            Type,
            Length
        }
        
        public Repository() 
        {
        }

        public List<Member> LoadMembers() 
        {
            List<Member> memberList = new List<Member>();
            bool newMember = false;
            Member m_member = new Member();
            Boat m_boat = new Boat();
            string line;
            MemberReadStatus stat = MemberReadStatus.Indefinite;
            using (StreamReader reader = new StreamReader("../../Registry.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if(line == "[MemberName]")
                    {
                        if (newMember == true)
                        {
                            memberList.Add(m_member);
                        }
                        else if (newMember == false) 
                        {
                            newMember = true;
                        }
                        stat = MemberReadStatus.Name;
                        line = reader.ReadLine();
                    }
                    if (line == "[Personal-Number]")
                    {
                        stat = MemberReadStatus.PersonalNumber;
                        line = reader.ReadLine();
                    }
                    if (line == "[Member-ID]")
                    {
                        stat = MemberReadStatus.MemberID;
                        line = reader.ReadLine();
                        m_member.boatlist = new List<Boat>();
                    }
                    if (line == "[BoatName]")
                    {
                        stat = MemberReadStatus.BoatName;
                        line = reader.ReadLine();
                    }
                    if (line == "[Type]") 
                    {
                        stat = MemberReadStatus.Type;
                        line = reader.ReadLine();
                    }
                    if (line == "[Length]")
                    {
                        stat = MemberReadStatus.Length;
                        line = reader.ReadLine();
                    }

                    switch (stat)
                    {
                        case MemberReadStatus.Name:
                            m_member = new Member(line);
                            break;
                        case MemberReadStatus.PersonalNumber:
                            m_member.personalNumber = line;
                            break;
                        case MemberReadStatus.MemberID:
                            m_member.memberID = int.Parse(line);
                            break;
                        case MemberReadStatus.BoatName:
                            m_boat = new Boat(line);
                            break;
                        case MemberReadStatus.Type:
                            m_boat.type = line;
                            break;
                        case MemberReadStatus.Length:
                            m_boat.length = int.Parse(line);
                            m_member.boatlist.Add(m_boat);
                            break;
                    }
                }
                memberList.Add(m_member);
            }

            return memberList;
        }

        public void SaveMembers(List<Member> memberlist) 
        {
            using (StreamWriter writer = new StreamWriter("../../Registry.txt"))
            {
                for (int i = 1; i <= memberlist.Count; i++)
                {
                    writer.WriteLine("[MemberName]");
                    writer.WriteLine(memberlist[i - 1].name);
                    writer.WriteLine("[Personal-Number]");
                    writer.WriteLine(memberlist[i - 1].personalNumber);
                    writer.WriteLine("[Member-ID]");
                    writer.WriteLine(memberlist[i - 1].memberID);
                    for (int a = 1; a <= memberlist[i - 1].boatlist.Count; a++)
                    {
                        writer.WriteLine("[BoatName]");
                        writer.WriteLine(memberlist[i - 1].boatlist[a-1].name);
                        writer.WriteLine("[Type]");
                        writer.WriteLine(memberlist[i - 1].boatlist[a-1].type);
                        writer.WriteLine("[Length]");
                        writer.WriteLine(memberlist[i - 1].boatlist[a-1].length);
                    }
                }
            }
        }

    }
}
