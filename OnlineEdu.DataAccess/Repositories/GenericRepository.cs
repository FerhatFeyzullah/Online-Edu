using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Interface;

namespace OnlineEdu.DataAccess.Repositories
{
    public class GenericRepository<A>: IRepository<A> where A : class
    {
        protected readonly OnlineEduContext _context;
        public GenericRepository(OnlineEduContext context)
        {
            _context = context;
        }

        public DbSet<A> Table { get => _context.Set<A>();}
        public int Count()
        {
            return Table.Count();
        }

        public void Create(A entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public int FilteredCount(Expression<Func<A, bool>> kosul)
        {
            return Table.Where(kosul).Count();
        }

        public A GetByFilter(Expression<Func<A, bool>> kosul)
        {
            return Table.Where(kosul).FirstOrDefault();
        }

        public A GetById(int id)
        {
            return Table.Find(id);
        }

        public List<A> GetFilteredList(Expression<Func<A, bool>> kosul)
        {
            return Table.Where(kosul).ToList();
        }

        public List<A> GetList()
        {
            return Table.ToList();
        }

        public void Update(A entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}
