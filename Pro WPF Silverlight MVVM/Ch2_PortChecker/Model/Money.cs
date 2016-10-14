using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Money
    {
        public static Money operator +(Money lhs, Money rhs)
        {
            return new Money();
        }

        public static implicit operator decimal(Money lhs)
        {
            return 0;
        }
    }
}
