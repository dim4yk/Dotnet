using System;

namespace Project1
{
    class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person() {
            this.name = "";
            this.surname = "";
            this.birthday = new DateTime();
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
            get => birthday;
            set => birthday = value;
        }

        public int ChangeYear {
            get => birthday.Year;
            set => birthday = 
                new DateTime(value,birthday.Month,birthday.Day);
        }

        public override string ToString() {
            return "Name: "+name+" Surname: "+surname+" Birthday: "+birthday;
        }

        public string ToShortString() {
            return "Name: " + name + " Surname: " + surname;
        }
    }
}
