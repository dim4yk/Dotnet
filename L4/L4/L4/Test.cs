using System;
using System.Collections.Generic;
using System.Text;

namespace L4
{
    class Test
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

        public override string ToString()
        {
            return "Subject: " + Subject + " Info about test: " + InfoTest;
        }
    }
}
