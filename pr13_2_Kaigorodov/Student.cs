using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract13_2
{
    class Student
    {
        private string name;
        private string surname;
        private string recordBookNumber;
        private string groupe;
        private int kurs;
        public Student(string name, string surname, string recordBookNumber, string group, int course)
        {
            this.name = name;
            this.surname = surname;
            this.recordBookNumber = recordBookNumber;
            this.groupe = group;
            this.kurs = course;
        }
        public string Group
        {
            get { return groupe; }
            set { groupe = value; }
        }
        public int Course
        {
            get { return kurs; }
            set { kurs = value; }
        }
      
        public string getName()
        {
          return this.name;
        }
        public string getSurname()
        {
            return this.surname;
        }
        public string getRecordBookNumber()
        {
            return this.recordBookNumber;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public void setRecordBookNumber(string recordBookNumber)
        {
            this.recordBookNumber = recordBookNumber;
        }
    }
}
