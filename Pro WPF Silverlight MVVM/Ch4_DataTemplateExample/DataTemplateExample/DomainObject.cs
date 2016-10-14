using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTemplateExample
{
    public class DomainObject
    {
        private int _instanceNumber;
        private static int InstanceCount = 0;

        public DomainObject()
        {
            _instanceNumber = ++InstanceCount;
        }

        public string DisplayText
        {
            get { return string.Format("Domain Object #{0}", _instanceNumber); }
        }
    }
}
