using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace CodeCampSDQ.Models
{ 
    public class SpeakerRepository : ISpeakerRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<Speaker> All
        {
            get { return context.Speakers; }
        }

        public IQueryable<Speaker> AllIncluding(params Expression<Func<Speaker, object>>[] includeProperties)
        {
            IQueryable<Speaker> query = context.Speakers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Speaker Find(int id)
        {
            return context.Speakers.Find(id);
        }

        public void InsertOrUpdate(Speaker speaker)
        {
            if (speaker.Id == default(int)) {
                // New entity
                context.Speakers.Add(speaker);
            } else {
                // Existing entity
                context.Entry(speaker).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var speaker = context.Speakers.Find(id);
            context.Speakers.Remove(speaker);
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

    public interface ISpeakerRepository : IDisposable
    {
        IQueryable<Speaker> All { get; }
        IQueryable<Speaker> AllIncluding(params Expression<Func<Speaker, object>>[] includeProperties);
        Speaker Find(int id);
        void InsertOrUpdate(Speaker speaker);
        void Delete(int id);
        void Save();
    }
}