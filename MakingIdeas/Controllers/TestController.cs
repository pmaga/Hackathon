using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MakingIdeas.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        [Route("GetWelcomeMessage")]
        public string GetWelcomeMessage()
        {
            return "Welcome from Web API";
        }
    }
}
