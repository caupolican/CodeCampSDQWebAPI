using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CodeCampSDQ.Models
{ 
    public class ScheduleRepository : IScheduleRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<Schedule> All
        {
            get { return context.Schedules; }
        }

        public IQueryable<Schedule> AllIncluding(params Expression<Func<Schedule, object>>[] includeProperties)
        {
            IQueryable<Schedule> query = context.Schedules;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Schedule Find(int id)
        {
            return context.Schedules.Find(id);
        }

        public void InsertOrUpdate(Schedule schedule)
        {
            if (schedule.Id == default(int)) {
                // New entity
                context.Schedules.Add(schedule);
            } else {
                // Existing entity
                context.Entry(schedule).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var schedule = context.Schedules.Find(id);
            context.Schedules.Remove(schedule);
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

    public interface IScheduleRepository : IDisposable
    {
        IQueryable<Schedule> All { get; }
        IQueryable<Schedule> AllIncluding(params Expression<Func<Schedule, object>>[] includeProperties);
        Schedule Find(int id);
        void InsertOrUpdate(Schedule schedule);
        void Delete(int id);
        void Save();
    }
}