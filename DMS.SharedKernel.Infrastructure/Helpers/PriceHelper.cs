using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.SharedKernel.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return String.Format("BDT{0}", price);
        }
    }

}
