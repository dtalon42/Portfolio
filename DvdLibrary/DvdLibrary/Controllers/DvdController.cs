using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        public IDvdRepository InitRepo()
        {
            DvdLibraryFactory factory = new RepositoryFactory();
            IDvdRepository repo = factory.GetRepository();
            return repo;
        }

        [Route("dvds/")]
        [HttpGet]
        public IHttpActionResult GetAllDvds()
        {
            return Ok(InitRepo().GetAll());
        }

        [Route("dvd/{dvdId}")]
        [HttpGet]
        public IHttpActionResult GetDvd(int dvdId)
        {
            var result = InitRepo().Get(dvdId);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [Route("dvds/rating/{dvdRating}")]
        [HttpGet]
        public IHttpActionResult GetDvdsByRating(string dvdRating)
        {
            if (dvdRating.ToUpper() == "G"
                || dvdRating.ToUpper() == "PG"
                || dvdRating.ToUpper() == "PG-13"
                || dvdRating.ToUpper() == "R")
            {
                return Ok(InitRepo().GetDvdsByRating(dvdRating));
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("dvds/title/{dvdTitle}")]
        [HttpGet]
        public IHttpActionResult GetDvdsByTitle(string dvdTitle)
        {
            var result = InitRepo().GetDvdsByTitle(dvdTitle);

            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Route("dvds/year/{dvdYear}")]
        [HttpGet]
        public IHttpActionResult GetDvdsByYear(string dvdYear)
        {
            if (dvdYear.All(c => char.IsDigit(c)) && dvdYear.Length == 4)
            {
                var result = InitRepo().GetDvdsByYear(dvdYear);
                if (result.Count == 0)
                    return NotFound();
                else
                    return Ok(result);
            }
            else
                return BadRequest();
            
        }

        [Route("dvds/director/{dvdDirector}")]
        [HttpGet]
        public IHttpActionResult GetDvdsByDirector(string dvdDirector)
        {
            var result = InitRepo().GetDvdsByDirector(dvdDirector);
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result);
        }

        [Route("dvd/")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Dvd newDvd)
        {
            return Ok(InitRepo().Create(newDvd));
        }

        [Route("dvd/{id}")]
        [HttpPut]
        public void Update([FromBody] Dvd updatedDvd)
        {
            InitRepo().Update(updatedDvd);
        }

        [Route("dvd/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            InitRepo().Delete(id);
        }
    }
}
