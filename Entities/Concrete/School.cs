using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class School : IBaseEntity, ISchool
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int NumberOfStudent { get; set; }
        public int NumberOfEmploye { get; set; }
        public List<Teacher> Teachers { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Nesne üretilidiği zaman tarih bilgisi otomatik gelir
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
        public Status status { get; set; } = Status.Active; // Nesne üretildiğinde nesne her zaman active olarak db ye kaydedilecek.
    }
}
