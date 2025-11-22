namespace Aerodrom.classes
{
    public class People : BaseEntity
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                Touch();
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                Touch();
            }
        }

        private DateOnly _dateOfBirth;
        public DateOnly DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                Touch();
            }
        }

        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                Touch();
            }
        }

        public People(string firstName, string lastName, DateOnly dateOfBirth, Gender gender)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
    }
}
