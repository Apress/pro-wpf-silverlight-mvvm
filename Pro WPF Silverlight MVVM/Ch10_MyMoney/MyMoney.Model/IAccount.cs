using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public interface IAccount
    {
        #region Properties

        string Name
        {
            get;
        }

        Money Balance
        {
            get;
        }

        IAccount Parent
        {
            get;
            set;
        }

        #endregion
    }
}
