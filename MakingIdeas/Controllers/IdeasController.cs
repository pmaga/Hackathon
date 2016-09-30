using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [Route("getNewest/{amount:int?}")]
        public List<IdeaFeedView> GetNewest(int amount = 0)
        {
            return _ideaRepository.GetNewestIdeas(amount).ToList();
        }

        [System.Web.Mvc.HttpGet]
        [Route("getTrendings/{amount:int?}")]
        public List<IdeaFeedView> GetTrendings(int amount = 0)
        {
            return _ideaRepository.GetTrandingIdeas(amount).ToList();
        }

        [System.Web.Mvc.HttpPut]
        [Route("addLike/{ideaId}")]
        public HttpResponseMessage AddLike(int ideaId)
        {
            try
            {
                var result = _ideaRepository.AddLike(ideaId);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not update idea.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Mvc.HttpGet]
        [Route("{id}")]
        public IdeaDto Get(int id)
        {
            var idea = _ideaRepository.Get(id);

            return new IdeaDto
            {
                Title = idea.Title,
                Body = idea.Body,
                Tags = idea.Tags.Select(n => n.Name).ToList(),
                ThumbnailUrl = idea.ThumbnailUrl,
                Likes = idea.Likes,
                Project = idea.Project
            };
        }

        [System.Web.Mvc.HttpPost]
        [Route("")]
        public HttpResponseMessage Create([FromBody] IdeaDto idea)
        {

            try
            {
                var result = _ideaRepository.Create(new Idea
                {
                    Title = idea.Title,
                    Body = idea.Body,
                    Project = idea.Project,
                    ThumbnailUrl = idea.ThumbnailUrl,
                    Tags = idea.Tags.Select(n => new Tag { Name = n }).ToList()
                });

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not create idea.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}