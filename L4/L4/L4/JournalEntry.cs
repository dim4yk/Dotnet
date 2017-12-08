using System;
using System.Collections.Generic;
using System.Text;

namespace L4
{
    class JournalEntry
    {
        public string CollectionName { get; set; }

        public string TypeOfChanges { get; set; }

        public Student GetStudent { get; set; }

        public JournalEntry(string collname, string type, Student stud)
        {
            CollectionName = collname;
            TypeOfChanges = type;
            GetStudent = stud;
        }

        public override string ToString()
        {
            return "Collection Name: " + CollectionName +
                   "; Type of Changes: " + TypeOfChanges +
                   "; \n" + GetStudent.ToShortString() + "\n";
        }
    }
}
