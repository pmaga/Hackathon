using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MakingIdeas.Dtos;
using MakingIdeas.Models;
using MakingIdeas.Repositories;

namespace MakingIdeas.Controllers
{
    [RoutePrefix("api/Ideas")]
    public class IdeasController : ApiController
    {
        private readonly IdeaRepository _ideaRepository;

        public IdeasController()
        {
            _ideaRepository = new IdeaRepository();
        }

        [System.Web.Mvc.HttpGet]
        [Route("getNewest/{amount}")]
        public List<IdeaFeedView> GetNewest(int amount)
        {
            return _ideaRepository.GetNewestIdeas(amount)
                    .Select(n => new IdeaFeedView(n.Id, n.Title, n.Body, n.CreatedDate)).ToList();
        }
    }
}