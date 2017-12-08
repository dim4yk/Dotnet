using System;

namespace L4
{
    class Program
    {
        static void Main()
        {
            StudentCollection sc1 = new StudentCollection();
            StudentCollection sc2 = new StudentCollection();
            sc1.CollectionName = "Collection 1";
            sc2.CollectionName = "Collection 2";

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            sc1.StudentCountChanged += journal1.JournalEventHandler;
            sc1.StudentReferenceChanged += journal1.JournalEventHandler;

            sc2.StudentCountChanged += journal1.JournalEventHandler;
            sc2.StudentCountChanged += journal2.JournalEventHandler;
            sc2.StudentReferenceChanged += journal1.JournalEventHandler;
            sc2.StudentReferenceChanged += journal2.JournalEventHandler;

            sc1.AddDefaults(5);
            sc2.AddDefaults(2);

            sc1.Remove(3);

            sc2[1].Name = "Jack";

            Student studForChange = new Student();
            studForChange.Surname = "Willson";
            sc2[1] = studForChange;

            Console.WriteLine(journal1.ToString() + "\n");
            Console.WriteLine(journal2.ToString() + "\n");

            Console.ReadKey();
        }
    }
}
