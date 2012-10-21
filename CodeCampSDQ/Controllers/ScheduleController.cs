using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodeCampSDQ.Models;

namespace CodeCampSDQ.Controllers
{
    public class ScheduleController : ApiController
    {

        IScheduleRepository repository;

        public ScheduleController()
        {
            repository = new ScheduleRepository();
        }

        public ScheduleController(IScheduleRepository repository)
        {
            this.repository = repository;
        }


        // GET api/Schedule
        public IEnumerable<Schedule> GetSchedules()
        {
            return repository.AllIncluding(x => x.Days);
        }

        // GET api/Schedule/5
        public Schedule GetSchedule(int id)
        {
            Schedule schedule = repository.Find(id);
            if (schedule == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return schedule;
        }

        // PUT api/Schedule/5
        public HttpResponseMessage PutSchedule(int id, Schedule schedule)
        {
            if (ModelState.IsValid && id == schedule.Id)
            {
                try
                {
                    repository.InsertOrUpdate(schedule);
                    repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Schedule
        public HttpResponseMessage PostSchedule(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.InsertOrUpdate(schedule);
                    repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, schedule);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = schedule.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Schedule/5
        public HttpResponseMessage DeleteSchedule(int id)
        {
            try
            {
                repository.Delete(id);
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, id);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}