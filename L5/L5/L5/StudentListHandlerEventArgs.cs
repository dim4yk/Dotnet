using System;
using System.Collections.Generic;
using System.Text;

namespace L5
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string TypeOfChanges { get; set; }
        public Student Student { get; set; }

        public StudentListHandlerEventArgs(string collname, string type, Student stud)
        {
            CollectionName = collname;
            TypeOfChanges = type;
            Student = stud;
        }

        public override string ToString()
        {
            return "Collection Name: " + CollectionName + 
                   "; Type of Changes: " + TypeOfChanges + 
                   "; \n" + Student.ToString() + "\n";
        }
    }

    
}
