using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class SalesTotals
    {
        public IDictionary<Area, Money> CalculatePrimaryAreaSalesTotals(IEnumerable<Sale> sales)
        {
            IDictionary<Area, Money> areaSalesTotals = new Dictionary<Area, Money>();

            areaSalesTotals[Area.NorthAmerica] = CalculateAreaSalesTotal(sales, Area.NorthAmerica);
            
            areaSalesTotals[Area.WesternEurope] = CalculateAreaSalesTotal(sales, Area.WesternEurope);

            return areaSalesTotals;
        }

        private Money CalculateAreaSalesTotal(IEnumerable<Sale> sales, Area area)
        {
            return sales.Sum(sale => new decimal?(sale.Area == area ? sale.Value : null));
        }
    }
}
