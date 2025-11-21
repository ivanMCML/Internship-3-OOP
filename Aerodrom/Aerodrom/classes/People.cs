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

        private int _yearOfBirth;
        public int YearOfBirth
        {
            get => _yearOfBirth;
            set
            {
                _yearOfBirth = value;
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

        public People(string firstName, string lastName, int yearOfBirth, Gender gender)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            Gender = gender;
        }
    }
}
