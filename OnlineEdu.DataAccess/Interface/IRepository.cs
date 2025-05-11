using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Interface
{
    public interface IRepository<A> where A : class
    {
        List<A> GetList();

        A GetByFilter(Expression<Func<A, bool>> kosul);

        A GetById(int id);

        void Create(A entity);

        void Update(A entity);

        void Delete(int id);

        int Count();

        int FilteredCount(Expression<Func<A, bool>> kosul);

        List<A> GetFilteredList(Expression<Func<A, bool>> kosul);
    }
}
