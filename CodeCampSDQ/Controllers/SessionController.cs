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
    public class SessionController : ApiController
    {

        ISessionRepository repository;

        public SessionController()
        {
            repository = new SessionRepository();
        }

        public SessionController(ISessionRepository repository)
        {
            this.repository = repository;
        }


        // GET api/Session
        public IEnumerable<Session> GetSessions()
        {
            return repository.All.AsEnumerable();
        }

        // GET api/Session/5
        public Session GetSession(int id)
        {
            Session session = repository.Find(id);
            if (session == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return session;
        }

        // PUT api/Session/5
        public HttpResponseMessage PutSession(int id, Session session)
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

        // POST api/Session
        public HttpResponseMessage PostSession(Session session)
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

        // DELETE api/Session/5
        public HttpResponseMessage DeleteSession(int id)
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