using DataAccess.Context;
using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConctreteRepository
{

    //<T> koyunca generic bir yapıya dönüştürdüm.
    //where T : class deyince bu generic yapının class olması zorunluluğu getirdim
    //Bu gelen classların IBaseEntity tipinde olması gerektiğinide söyledim.

    //Base Repository bizim CRUD işlemlerimizi üstelenecek olan sınıf!!!
    public class BaseRepository<T> where T : class , IBaseEntity
    {
        private readonly CodeFirstDbContext _codeFirstDbContext; //Ekleme silme güncelleme işlemleri için buna ihtiyacım vardı.

        private DbSet<T> _table;

        public BaseRepository(CodeFirstDbContext codeFirstDbContext)
        {
            _codeFirstDbContext = codeFirstDbContext;
            _table = _codeFirstDbContext.Set<T>(); // School gelirse _table --> DbSet<School>
                                                   // Teacher gelirse _table --> DbSet<Teacher>
        }
        public bool Add(T entity)
        {
            _table.Add(entity);
            return Save() > 0;
        }
        public bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return Save() > 0;
        }

        public bool Delete(T entity)
        {
            //Veri tabanında biz verilerin silinmeyeceğini söylediğimiz için burada gelip statusunu deleted olarak ayarladık ve gittik bunu güncelledik.
            entity.status = Status.Deleted;
            return Update(entity);

            //Normalde silme işlemi böyle yapıyorduk
            //_table.Remove(entity);
            //return Save() > 0;
        }

        public bool Update(T entity)
        {
            //Senin change tracker ile durum kontrolü yapmanı sağlıyor.
            _codeFirstDbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save() > 0;
        }

        public List<T> GetAll()
        {
            return _table.Where(x => x.status == Status.Active || x.status == Status.Modified).ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public int Save()
        {
            return _codeFirstDbContext.SaveChanges();
        }
    }
}
