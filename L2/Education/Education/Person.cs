using System;
using System.Collections.Generic;

namespace Project1
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected System.DateTime _birthday;


        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this._birthday = birthday;
        }

        public Person() {
            this.name = "";
            this.surname = "";
            this._birthday = new DateTime();
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public string Surname {
            get => surname;
            set => surname = value;
        }

        public DateTime Birthday {
            get => _birthday;
            set => _birthday = value;
        }

        public int ChangeYear {
            get => _birthday.Year;
            set => _birthday = 
                new DateTime(value,Date.Month,Date.Day);
        }



        public DateTime Date { get => _birthday; set => _birthday = value; }



        public override string ToString() {
            return "Name: "+ Name +" Surname: "+ Surname +" Birthday: "+ Date;
        }



        public virtual string ToShortString() {
            return "Name: " + Name + " Surname: " + Surname;
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   name == person.name &&
                   surname == person.surname &&
                   _birthday == person._birthday &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Birthday == person.Birthday;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            Person dcopy = (Person)this.MemberwiseClone();
            dcopy.Name = new string(Name.ToCharArray());
            dcopy.Surname = new string(Surname.ToCharArray());
            dcopy.Date = new DateTime(Date.Year, Date.Month, Date.Day);
            return dcopy;
        }

        public static bool operator ==(Person P1, Person P2) {

            if (((object)P1 == null) || ((object)P2 == null)) {
                return false;
            }

            return P1.Equals(P2)&&
                P1.GetHashCode()!=P2.GetHashCode();
        }

        public static bool operator !=(Person P1, Person P2) {
            if (((object)P1 == null) || ((object)P2 == null))
            {
                return true;
            }
            return !(P1.Equals(P2))&&
                P1.GetHashCode()!=P2.GetHashCode();
        }
    }
}
