using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MakingIdeas.Models;

namespace MakingIdeas.Controllers
{
    [RoutePrefix("api/Ideas")]
    public class IdeasController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        [Route("")]
        public List<Idea> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ideas.ToList();
            }
        }
    }
}