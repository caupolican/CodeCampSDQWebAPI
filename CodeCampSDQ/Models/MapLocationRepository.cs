using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace CodeCampSDQ.Models
{ 
    public class MapLocationRepository : IMapLocationRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<MapLocation> All
        {
            get { return context.MapLocations; }
        }

        public IQueryable<MapLocation> AllIncluding(params Expression<Func<MapLocation, object>>[] includeProperties)
        {
            IQueryable<MapLocation> query = context.MapLocations;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public MapLocation Find(int id)
        {
            return context.MapLocations.Find(id);
        }

        public void InsertOrUpdate(MapLocation maplocation)
        {
            if (maplocation.Id == default(int)) {
                // New entity
                context.MapLocations.Add(maplocation);
            } else {
                // Existing entity
                context.Entry(maplocation).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var maplocation = context.MapLocations.Find(id);
            context.MapLocations.Remove(maplocation);
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

    public interface IMapLocationRepository : IDisposable
    {
        IQueryable<MapLocation> All { get; }
        IQueryable<MapLocation> AllIncluding(params Expression<Func<MapLocation, object>>[] includeProperties);
        MapLocation Find(int id);
        void InsertOrUpdate(MapLocation maplocation);
        void Delete(int id);
        void Save();
    }
}