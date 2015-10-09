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
            MemberID
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
            Member member = new Member();
            string line;
            MembertReadStatus stat = MembertReadStatus.Indefinite;
            using (StreamReader reader = new StreamReader("../../TestRegistryMembers.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if(line == "[Name]")
                    {
                        stat = MembertReadStatus.Name;
                        line = reader.ReadLine();
                    }
                    if (line == "[Personal-Number]")
                    {
                        stat = MembertReadStatus.PersonalNumber;
                        line = reader.ReadLine();
                    }
                    if (line == "[Member-ID]")
                    {
                        stat = MembertReadStatus.MemberID;
                        line = reader.ReadLine();
                    }

                    switch (stat)
                    {
                        case MembertReadStatus.Name :
                            member = new Member(line);
                            break;
                        case MembertReadStatus.PersonalNumber :
                            member.personalNumber = line;
                            break;
                        case MembertReadStatus.MemberID :
                            member.memberID = Convert.ToInt32(line);
                            memberList.Add(member);
                            break;
                    }
                }
            }

            return memberList;
        }

        public List<Boat> LoadBoats()
        {
            List<Boat> boatlist = new List<Boat>();
            Boat boat = new Boat();
            string line;
            BoatReadStatus stat = BoatReadStatus.Indefinite;
            using (StreamReader reader = new StreamReader("../../TestRegistryBoats.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "[Name]")
                    {
                        stat = BoatReadStatus.Name;
                        line = reader.ReadLine();
                    }
                    if (line == "[Owner-ID]")
                    {
                        stat = BoatReadStatus.OwnerID;
                        line = reader.ReadLine();
                    }
                    if (line == "[Boat-ID]")
                    {
                        stat = BoatReadStatus.BoatID;
                        line = reader.ReadLine();
                    }
                    if (line == "[Type]")
                    {
                        stat = BoatReadStatus.Type;
                        line = reader.ReadLine();
                    }
                    if (line == "[Length]")
                    {
                        stat = BoatReadStatus.Length;
                        line = reader.ReadLine();
                    }

                    switch (stat)
                    {
                        case BoatReadStatus.Name:
                            boat = new Boat(line);
                            break;
                        case BoatReadStatus.OwnerID:
                            boat.ownerID = Convert.ToInt32(line);
                            break;
                        case BoatReadStatus.BoatID:
                            boat.boatID = Convert.ToInt32(line);
                            boatlist.Add(boat);
                            break;
                        case BoatReadStatus.Type:
                            boat.type = line;
                            break;
                        case BoatReadStatus.Length:
                            boat.length = Convert.ToInt32(line);
                            break;
                    }
                }
            }

            return boatlist;
        }

        public void SaveMembers(List<Member> memberlist) 
        {
            using (StreamWriter writer = new StreamWriter("../../TestRegistryMembers.txt"))
            {
                for (int i = 1; i <= memberlist.Count; i++)
                {
                    writer.WriteLine("[Name]");
                    writer.WriteLine(memberlist[i - 1].name);
                    writer.WriteLine("[Personal-Number]");
                    writer.WriteLine(memberlist[i - 1].personalNumber);
                    writer.WriteLine("[Member-ID]");
                    writer.WriteLine(memberlist[i - 1].memberID);
                }
            }
        }

        public void SaveBoats(List<Boat> boatlist) 
        {
            using (StreamWriter writer = new StreamWriter("../../TestRegistryBoats.txt"))
            {
                for (int i = 1; i <= boatlist.Count; i++)
                {
                    writer.WriteLine("[Name]");
                    writer.WriteLine(boatlist[i - 1].name);
                    writer.WriteLine("[Owner-ID]");
                    writer.WriteLine(boatlist[i - 1].ownerID);
                    writer.WriteLine("[Boat-ID]");
                    writer.WriteLine(boatlist[i - 1].boatID);
                    writer.WriteLine("[Type]");
                    writer.WriteLine(boatlist[i - 1].type);
                    writer.WriteLine("[Length]");
                    writer.WriteLine(boatlist[i - 1].length);
                }
            }
        }


    }
}
