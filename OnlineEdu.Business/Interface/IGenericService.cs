using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Interface
{
    public interface IGenericService<A> where A : class
    {
        List<A> AGetList();

        A AGetByFilter(Expression<Func<A, bool>> kosul);

        A AGetById(int id);

        void ACreate(A entity);

        void AUpdate(A entity);

        void ADelete(int id);

        int ACount();

        int AFilteredCount(Expression<Func<A, bool>> kosul);

        List<A> AGetFilteredList(Expression<Func<A, bool>> kosul);
    }
}
