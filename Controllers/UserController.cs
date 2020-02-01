using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Omnistack.Context;
using Omnistack.Models.User;
using Omnistack.Services;

namespace Omnistack.Controller
{
    [Route("v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private OmnistackContext _context = new OmnistackContext();

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                GithubService.InsertGitHubUser(item);
                _context.Users.Add(item);
                _context.SaveChanges();

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(_context.Users.FirstOrDefault(x => x.Id.Equals(id)));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_context.Users.AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(x => x.Id.Equals(id));

                _context.Remove(entity);
                _context.SaveChanges();

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("put")]
        public IActionResult Put([FromBody] User item)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(x => x.Id.Equals(item.Id));

                entity.Avatar = item.Avatar;
                entity.Name = item.Name;
                entity.UserName = item.UserName;
                entity.Url = item.Url;
                entity.Bio = item.Bio;
                entity.Linkedin = item.Linkedin;
                entity.Location = item.Location;

                _context.Users.Update(entity);
                _context.SaveChanges();

                return new ObjectResult(entity);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}