using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Common.Models
{
    public class BagItem
    {
        public BagProduct Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

    }
public class BagProduct
{
    public int ArtikelNr
        {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public double GSWert
    {
        get;
        set;
    }


}
}
