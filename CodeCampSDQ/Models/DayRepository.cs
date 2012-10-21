using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CodeCampSDQ.Models
{ 
    public class DayRepository : IDayRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<Day> All
        {
            get { return context.Days; }
        }

        public IQueryable<Day> AllIncluding(params Expression<Func<Day, object>>[] includeProperties)
        {
            IQueryable<Day> query = context.Days;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Day Find(int id)
        {
            return context.Days.Find(id);
        }

        public void InsertOrUpdate(Day day)
        {
            if (day.Id == default(int)) {
                // New entity
                context.Days.Add(day);
            } else {
                // Existing entity
                context.Entry(day).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var day = context.Days.Find(id);
            context.Days.Remove(day);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IDayRepository : IDisposable
    {
        IQueryable<Day> All { get; }
        IQueryable<Day> AllIncluding(params Expression<Func<Day, object>>[] includeProperties);
        Day Find(int id);
        void InsertOrUpdate(Day day);
        void Delete(int id);
        void Save();
    }
}