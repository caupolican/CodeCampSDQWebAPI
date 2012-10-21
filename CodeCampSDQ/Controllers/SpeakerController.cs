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
    public class SpeakerController : ApiController
    {
        ISpeakerRepository repository;

        public SpeakerController()
        {
            repository = new SpeakerRepository();
        }

        public SpeakerController(ISpeakerRepository repository)
        {
            this.repository = repository;
        }


        // GET api/Speaker
        public IEnumerable<Speaker> GetSpeakers()
        {
            return repository.All.AsEnumerable();
        }

        // GET api/Speaker/5
        public Speaker GetSpeaker(int id)
        {
            Speaker session = repository.Find(id);
            if (session == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return session;
        }

        // PUT api/Speaker/5
        public HttpResponseMessage PutSpeaker(int id, Speaker session)
        {
            if (ModelState.IsValid && id == session.Id)
            {
                try
                {
                    repository.InsertOrUpdate(session);
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

        // POST api/Speaker
        public HttpResponseMessage PostSpeaker(Speaker session)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.InsertOrUpdate(session);
                    repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, session);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = session.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Speaker/5
        public HttpResponseMessage DeleteSpeaker(int id)
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