using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class EnumTest
    {
        MyEnum _myenum;
        public MyEnum myenum
        {
            get { return _myenum; }
            set { _myenum = value; }
        }
    }
    public enum MyEnum
    {
        a = 0, b = 2, c = 3
    }
}
