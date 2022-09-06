using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConctreteRepository
{

    //Bir proje okuma ve yazma işlemleri farklı sınıflarda tanımlanması gerekmektedir.
    //Repository pattern bunu karşılamaz. Bunun alternatifi olarak  CQRS pattern ortaya atılmıştır. CQRS pattern de okuma ve yazma işlemleri birbirinden ayrılır.Projenin büyüklüğüne göre yapısal tasarım değişiklik firmadan firmaya gösterir.
    public class SchoolRepository : BaseRepository<School>
    {
        public SchoolRepository(CodeFirstDbContext codeFirstDbContext) : base(codeFirstDbContext)
        {
        }
    }
}
