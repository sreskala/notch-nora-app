using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Posts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return await Mediator.Send(new Details.Query{ Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]Post post)
        {
            return Ok(await Mediator.Send(new Create.Command {Post = post}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(int id, Post post)
        {
            post.Id = id;

            return Ok(await Mediator.Send(new Edit.Command{Post = post}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
           return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}