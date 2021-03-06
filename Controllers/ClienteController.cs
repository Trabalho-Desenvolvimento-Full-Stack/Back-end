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
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            using (MyContext ctx = new MyContext())
            {
                return Ok(ctx.Clientes.ToList());
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Cliente> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                Usuario user = context.Clientes.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();
                return user;
            }
        }



        [HttpPost]
        public ActionResult<Cliente> Post(Cliente usuario)
        {
            using (MyContext ctx = new MyContext())
            {

                ctx.Usuarios.Add(usuario);

                ctx.SaveChanges();
            }
            return usuario;
        }



        [HttpPut]
        public ActionResult<Cliente> Put(Cliente usuario)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }

            return usuario;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                Cliente usuario = ctx.Clientes.Where(u => u.Id.Equals(id)).FirstOrDefault();
                if (usuario == null)
                    return NotFound();
                ctx.Clientes.Remove(usuario);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}