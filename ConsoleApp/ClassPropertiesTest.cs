using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    interface IClassPropertiesTest
    {
        int Count { get; set; }
        string Name { get; set; }
    }
    class ClassPropertiesTest:IClassPropertiesTest
    {
        public int Count { get; set; }
        public string Name { get; set; }

        private SubProperties _sub;
        public SubProperties sub
        {
            get { 
                if (_sub == null)
                    _sub = new SubProperties();
                return _sub; 
            }
            set
            {
                 _sub=value;
            }
        }
    }
    class ClassPropertiesTest2 : IClassPropertiesTest
    {

        public int Count
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    class SubProperties
    {
        public int A { get; set; }
        public string B { get; set; }
        public object C { get; set; }
    }
}
