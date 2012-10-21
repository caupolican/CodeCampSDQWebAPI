using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CodeCampSDQ.Models
{ 
    public class PointRepository : IPointRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<Point> All
        {
            get { return context.Points; }
        }

        public IQueryable<Point> AllIncluding(params Expression<Func<Point, object>>[] includeProperties)
        {
            IQueryable<Point> query = context.Points;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Point Find(int id)
        {
            return context.Points.Find(id);
        }

        public void InsertOrUpdate(Point point)
        {
            if (point.Id == default(int)) {
                // New entity
                context.Points.Add(point);
            } else {
                // Existing entity
                context.Entry(point).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var point = context.Points.Find(id);
            context.Points.Remove(point);
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

    public interface IPointRepository : IDisposable
    {
        IQueryable<Point> All { get; }
        IQueryable<Point> AllIncluding(params Expression<Func<Point, object>>[] includeProperties);
        Point Find(int id);
        void InsertOrUpdate(Point point);
        void Delete(int id);
        void Save();
    }
}