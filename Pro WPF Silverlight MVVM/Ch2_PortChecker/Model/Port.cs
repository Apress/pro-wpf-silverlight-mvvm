using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortChecker.Model
{
    public class Port
    {
        public Port(int number, bool? isOpen)
        {
            Number = number;
            IsOpen = isOpen;
        }

        public int Number
        {
            get;
            private set;
        }

        public bool? IsOpen
        {
            get;
            private set;
        }
    }
}
