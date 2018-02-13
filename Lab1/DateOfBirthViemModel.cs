using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab1.Annotations;

//Unused usings

namespace Lab1
{
    internal class DateOfBirthViemModel:INotifyPropertyChanged
    {
        private static readonly string[] ChineseZodiaks = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private static readonly string[] Zodiaks = { "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Saggitarius", "Capricorn" };

        private DateTime _dateOfBirth = DateTime.Today;
        private int _age;
        private bool _isTodayABday;
        private string _zodiakWest;
        private string _zodiakChinese;

        public string Age
        {
            get
            {
                return $"Your age is {_age}";
            }
        }
        public string ZodiacWest
        {
            get
            {
                return $"Western zodiak: {_zodiakWest}";
            }
            private set
            {
                _zodiakWest = value;
                OnPropertyChanged();
            }
        }
        public string ZodiacChinese
        {
            get
            {
                return $"China zodiak: {_zodiakChinese}";
            }
            private set
            {
                _zodiakChinese = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                try
                {
                    UpdateValues();
                    OnPropertyChanged();
                    if (_isTodayABday)
                        MessageBox.Show("Z DNEM NARODZHENNYA ! SLAVA UKRAINE");
                }
                catch (Exception)
                {
                    MessageBox.Show("You enter illegal date!");
                }
            }
        }

        internal DateOfBirthViemModel()
        {
        }

        private void UpdateValues()
        {
            int days = (DateTime.Today - _dateOfBirth).Days;
            var age = days / 365;
            
            if (days < 0 || age > 135)
                throw new ArgumentException("Illegal Argument Exception");

            _age = age;
            OnPropertyChanged(nameof(Age));
            _isTodayABday = IsAbDay();
            ZodiacChinese = ChineseZodiak();
            ZodiacWest = Zodiak();
        }
        //You don't need to pass argument to this method
        //WrongNaming
        private bool IsAbDay()
        {
            return DateTime.Today.DayOfYear == _dateOfBirth.DayOfYear;
        }
        private string ChineseZodiak()
        {
            return ChineseZodiaks[(_dateOfBirth.Year - 5) % 12];
        }
        private string Zodiak()
        {
            int day = _dateOfBirth.Day;
            int month = _dateOfBirth.Month;
            //Not used variable

            if (month == 1 || month == 4)
                return day >= 20 ? Zodiaks[month - 1] : (month == 1 ? Zodiaks[Zodiaks.Length - 1] : Zodiaks[month - 2]);
            if (month == 2)
                return day >= 19 ? Zodiaks[month - 1] : Zodiaks[month - 2];

            if (month == 3 || month == 5 || month == 6)
                return day >= 21 ? Zodiaks[month - 1] : Zodiaks[month - 2];

            if (month == 7 || month == 8 || month == 9 || month == 10)
                return day >= 23 ? Zodiaks[month - 1] : Zodiaks[month - 2];

            return day >= 22 ? Zodiaks[month - 1] : Zodiaks[month - 2];
        }

        //This fields should be static
        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
