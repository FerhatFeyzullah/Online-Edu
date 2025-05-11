using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;

namespace OnlineEdu.Business.Management
{
    public class GenericManager<A>(IRepository<A> _repository) : IGenericService<A> where A : class
    {
        public int ACount()
        {
            return _repository.Count();
        }

        public void ACreate(A entity)
        {
            _repository.Create(entity);
        }

        public void ADelete(int id)
        {
            _repository.Delete(id);
        }

        public int AFilteredCount(Expression<Func<A, bool>> kosul)
        {
           return _repository.FilteredCount(kosul);
        }

        public A AGetByFilter(Expression<Func<A, bool>> kosul)
        {
            return _repository.GetByFilter(kosul);
        }

        public A AGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<A> AGetFilteredList(Expression<Func<A, bool>> kosul)
        {
            return _repository.GetFilteredList(kosul);
        }

        public List<A> AGetList()
        {
            return _repository.GetList();
        }

        public void AUpdate(A entity)
        {
            _repository.Update(entity);
        }
    }
}
