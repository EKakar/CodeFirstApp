using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum Status
    {
        //Sen verileri görünütülerken deleted olanları göstermessin.
        //Veritabanın veri silinmesi gerçekleşmez veri passive alınır
        Active = 1,
        Modified,
        Deleted
    }
}
