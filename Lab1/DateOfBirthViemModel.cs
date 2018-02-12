using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DateOfBirthViemModel
    {
        private DateTime? _dateOfBirth;
        private int _age;
        private bool _isTodayABday = false;
        private string _zodiakWest;
        private string _zodiakChinese;

        public int Age
        {
            get { return _age; }
        }

        public bool IsaBDay
        {
            get { return _isTodayABday; }
        }

        public string ZodiacWest { get { return _zodiakWest; } }
        
        public string ZodiacChinese { get { return _zodiakChinese; } }

        public DateOfBirthViemModel(DateTime? dateTime) {
            this._dateOfBirth = dateTime;

            int days = (DateTime.Today - _dateOfBirth).Value.Days;
            _age = days / 365;

            if (days < 0 || _age > 135)
                throw new ArgumentException("Illegal Argument Exception");



            _isTodayABday = _isABDay(_dateOfBirth);

            _zodiakChinese = _chineseZodiak(_dateOfBirth);
            _zodiakWest = _zodiak(_dateOfBirth);

        }

        private bool _isABDay(DateTime? date)
        {
            return DateTime.Today.DayOfYear == date.Value.DayOfYear;
        }

        private string _chineseZodiak (DateTime? date)
        {
            return _chineseZodiaks[(date.Value.Year - 5) % 12];
        }

        private string _zodiak(DateTime? date)
        {
            int day = date.Value.Day;
            int month = date.Value.Month;
            int i = 11;

            if (month == 1 || month == 4)
                if (day >= 20)
                    return _zodiaks[month - 1];
                else if (month == 1)
                    return _zodiaks[_zodiaks.Length - 1];
                else
                    return _zodiaks[month - 2];

            else if (month == 2)
                if (day >= 19)
                    return _zodiaks[month - 1];
                else
                    return _zodiaks[month - 2];

            else if (month == 3 || month == 5 || month == 6)
                if (day >= 21)
                    return _zodiaks[month - 1];
                else
                    return _zodiaks[month - 2];

            else if (month == 7 || month == 8 || month == 9 || month == 10)
                if (day >= 23)
                    return _zodiaks[month - 1];
                else
                    return _zodiaks[month - 2];

            else
            {
                if (day >= 22)
                {
                    return _zodiaks[month - 1];
                }
                else
                {
                    return _zodiaks[month - 2];
                }
            }
        }

        private string[] _chineseZodiaks = {"Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] _zodiaks = {"Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Saggitarius", "Capricorn" };

    }
}
