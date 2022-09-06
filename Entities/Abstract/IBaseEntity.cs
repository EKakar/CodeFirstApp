using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IBaseEntity 
    {
        //BaseEntity'i School ve Teacher sınıfları kalıtım olarak alacağı için burada bulunan propertyleri kendileri implemente etmek zorunda kalacaktır.

        //BaseEntity benim repository pattern kısmımda kullanılacak
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; } // İlk oluşturduğumda null
        DateTime? DeletedDate { get; set; } // İlk oluşturduğumda null
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        string DeletedBy { get; set; }
        Status status { get; set; }
    }
}
