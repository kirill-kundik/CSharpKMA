using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DateOfBirthViemModel
    {
        private DateTime _dateOfBirth;
        private int _age;
        private bool _isTodayABday;
        private string _zodiakWest;
        private string _zodiakChinese;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set {
                if(IsDateValid(DateOfBirth))
                    this._dateOfBirth = DateOfBirth;
            }
        }

        public DateOfBirthViemModel(DateTime dateTime) {
            DateOfBirth = dateTime;
        }

        private bool IsDateValid (DateTime date)
        {

            DateTime now = DateTime.Now;    


            return false;
        }
    }
}
