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

        public CrewMember(CrewMemberType position, string firstName, string lastName, int yearOfBirth, Gender gender)
            : base(firstName, lastName, yearOfBirth, gender)
        {
            Position = position;
            IsAssigned = false;
        }
    }
}
