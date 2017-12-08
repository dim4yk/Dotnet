using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace L5
{
    [Serializable]
    public class Test : ISerializable
    {
        public string Subject { get; set; }
        public bool InfoTest { get; set; }


        public Test(string subject, bool infoTest)
        {
            Subject = subject;
            InfoTest = infoTest;
        }

        public Test()
        {
            Subject = "";
            InfoTest = false;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Subject", Subject);
            info.AddValue("InfoTest", InfoTest);
        }

        public Test(SerializationInfo info, StreamingContext context)
        {
            Subject = (string)info.GetValue("Subject", typeof(string));
            InfoTest = (bool)info.GetValue("InfoTest", typeof(bool));
        }

        public override string ToString()
        {
            return "Subject: " + Subject + " Info about test: " + InfoTest;
        }
    }
}
