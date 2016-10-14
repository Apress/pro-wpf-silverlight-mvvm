using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooleanToValueConverterExample
{
    public class DomainObject
    {
        public DomainObject()
        {
            ShowText = false;
        }

        public bool ShowText
        {
            get;
            private set;
        }            
    }
}
