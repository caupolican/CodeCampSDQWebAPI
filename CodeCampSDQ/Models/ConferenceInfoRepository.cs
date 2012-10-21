using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace CodeCampSDQ.Models
{ 
    public class ConferenceInfoRepository : IConferenceInfoRepository
    {
        CodeCampSDQContext context = new CodeCampSDQContext();

        public IQueryable<ConferenceInfo> All
        {
            get { return context.ConferenceInfoes; }
        }

        public IQueryable<ConferenceInfo> AllIncluding(params Expression<Func<ConferenceInfo, object>>[] includeProperties)
        {
            IQueryable<ConferenceInfo> query = context.ConferenceInfoes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ConferenceInfo Find(int id)
        {
            return context.ConferenceInfoes.Find(id);
        }

        public void InsertOrUpdate(ConferenceInfo conferenceinfo)
        {
            if (conferenceinfo.Id == default(int)) {
                // New entity
                context.ConferenceInfoes.Add(conferenceinfo);
            } else {
                // Existing entity
                context.Entry(conferenceinfo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var conferenceinfo = context.ConferenceInfoes.Find(id);
            context.ConferenceInfoes.Remove(conferenceinfo);
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

    public interface IConferenceInfoRepository : IDisposable
    {
        IQueryable<ConferenceInfo> All { get; }
        IQueryable<ConferenceInfo> AllIncluding(params Expression<Func<ConferenceInfo, object>>[] includeProperties);
        ConferenceInfo Find(int id);
        void InsertOrUpdate(ConferenceInfo conferenceinfo);
        void Delete(int id);
        void Save();
    }
}