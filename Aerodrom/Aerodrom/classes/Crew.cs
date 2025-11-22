using Aerodrom.enums;

namespace Aerodrom.classes
{
    public class Crew : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Touch();
            }
        }

        private CrewMember _pilot;
        public CrewMember Pilot
        {
            get => _pilot;
            set
            {
                _pilot = value;
                Touch();
            }
        }

        private CrewMember _copilot;
        public CrewMember Copilot
        {
            get => _copilot;
            set
            {
                _copilot = value;
                Touch();
            }
        }

        private CrewMember _stewardess1;
        public CrewMember Stewardess1
        {
            get => _stewardess1;
            set
            {
                _stewardess1 = value;
                Touch();
            }
        }


        private CrewMember _stewardess2;
        public CrewMember Stewardess2
        {
            get => _stewardess2;
            set
            {
                _stewardess2 = value;
                Touch();
            }
        }

        public Crew(string name, CrewMember pilot, CrewMember copilot, CrewMember stewardess1, CrewMember stewardess2) : base()
        {
            Name = name;
            Pilot = pilot;
            Copilot = copilot;
            Stewardess1 = stewardess1;
            Stewardess2 = stewardess2;

            pilot.AssigneMember();
            copilot.AssigneMember();
            stewardess1.AssigneMember();
            stewardess2.AssigneMember();
        }

        public void PrintCrew()
        {
            Console.WriteLine(Name);
            Pilot.PrintCrewMember();
            Copilot.PrintCrewMember();
            Stewardess1.PrintCrewMember();
            Stewardess2.PrintCrewMember();
        }
    }
}
