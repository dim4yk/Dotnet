using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace L5
{
    public enum Education { Master, Bachelor, SecondEducation }
    [Serializable]
    public class Exam : IDateAndCopy, ISerializable
    {
        [XmlIgnore]
        public string subject;
        [XmlIgnore]
        public int mark;
        [XmlIgnore]
        public DateTime _examinationDate;


        public Exam()
        {
            this.subject = "";
            this.mark = -1;
            this._examinationDate = new DateTime();
        }

        public Exam(string subject, int mark, DateTime examinationDate)
        {
            this.subject = subject;
            this.mark = mark;
            this._examinationDate = examinationDate;
        }

        public string Subject
        {
            get => subject;
            set => subject = value;
        }

        public int Mark
        {
            get => mark;
            set => mark = value;
        }


        public DateTime Date { get => _examinationDate; set => _examinationDate = value; }

        public object DeepCopy()
        {
            Exam dcopy = (Exam)this.MemberwiseClone();
            dcopy.subject = new string(subject.ToCharArray());
            dcopy.mark = mark;
            dcopy._examinationDate = new DateTime(Date.Year, Date.Month, Date.Day);
            return dcopy;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Subject", Subject);
            info.AddValue("Mark", Mark);
            info.AddValue("ExaminationDate", Date);
        }

        public Exam(SerializationInfo info, StreamingContext context)
        {
            Subject = (string)info.GetValue("Subject", typeof(string));
            Mark = (int)info.GetValue("Mark", typeof(int));
            Date = (DateTime)info.GetValue("ExaminationDate", typeof(DateTime));
        }

        public override string ToString()
        {
            return "Subject: " + subject + " Mark: " + mark + " Examination date: " + Date;
        }

    }
}
