using System;
using System.Collections.Generic;
using System.Text;

namespace L4
{
    class Journal
    {
        private List<JournalEntry> ListOfChanges = new List<JournalEntry>();

        public void JournalEventHandler(object source, StudentListHandlerEventArgs eventArgs) {
            JournalEntry journalEntry = new JournalEntry(eventArgs.CollectionName, eventArgs.TypeOfChanges, eventArgs.Student);
            ListOfChanges.Add(journalEntry);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (JournalEntry change in ListOfChanges)
            {
                stringBuilder.Append("Collection Name: " + change.CollectionName +
                   "; Type of Changes: " + change.TypeOfChanges +
                   "; \n" + change.GetStudent.ToShortString()+ "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
