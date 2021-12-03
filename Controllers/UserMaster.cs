using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Back_end.Context;
using Back_end.Entity;

namespace Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<UserMaster>> Get()
        {
            using (MyContext ctx = new MyContext())
            {
                return Ok(ctx.UsersMaster.ToList());
            }
        }



        [HttpGet("{id}")]
        public ActionResult<UserMaster> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                Usuario user = context.UsersMaster.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();
                return user;
            }
        }



        [HttpPost]
        public ActionResult<UserMaster> Post(UserMaster user)
        {
            using (MyContext ctx = new MyContext())
            {

                ctx.UsersMaster.Add(user);

                ctx.SaveChanges();
            }
            return user;
        }



        [HttpPut]
        public ActionResult<UserMaster> Put(UserMaster user)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.UsersMaster.Update(user);
                ctx.SaveChanges();
            }

            return user;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                UserMaster user = ctx.UsersMaster.Where(u => u.Id.Equals(id)).FirstOrDefault();
                if (user == null)
                    return NotFound();
                ctx.UsersMaster.Remove(user);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}