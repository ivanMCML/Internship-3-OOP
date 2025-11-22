using Aerodrom.enums;

namespace Aerodrom.classes
{
    public class CrewMember : People
    {
        private CrewMemberType _position;
        public CrewMemberType Position
        {
            get => _position;
            set
            {
                _position = value;
                Touch();
            }
        }

        private bool _isAssigned;
        public bool IsAssigned
        {
            get => _isAssigned;
            set
            {
                _isAssigned = value;
                Touch();
            }
        }

        public CrewMember(CrewMemberType position, string firstName, string lastName, DateOnly dateOfBirth, Gender gender)
            : base(firstName, lastName, dateOfBirth, gender)
        {
            Position = position;
            IsAssigned = false;
        }

        public void AssigneMember()
        {
            IsAssigned = true;
        }

        public void PrintCrewMember()
        {
            Console.WriteLine($"{FirstName} - {LastName} - {Position} - {Gender} - {DateOfBirth}");
        }
    }
}
