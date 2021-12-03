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
    public class PedidoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            using (MyContext ctx = new MyContext())
            {
                return Ok(ctx.Pedidos.ToList());
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                Pedido user = context.Pedidos.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();
                return user;
            }
        }



        [HttpPost]
        public ActionResult<Pedido> Post(Pedido pedido)
        {
            using (MyContext ctx = new MyContext())
            {

                ctx.Pedidos.Add(pedido);

                ctx.SaveChanges();
            }
            return pedido;
        }



        [HttpPut]
        public ActionResult<Pedido> Put(Pedido pedido)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Pedidos.Update(pedido);
                ctx.SaveChanges();
            }

            return pedido;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                Pedido pedido = ctx.Pedidos.Where(u => u.Id.Equals(id)).FirstOrDefault();
                if (pedido == null)
                    return NotFound();
                ctx.Pedidos.Remove(pedido);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}