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
    public class ItemPedidoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<ItemPedido>> Get()
        {
            using (MyContext ctx = new MyContext())
            {
                return Ok(ctx.ItemPedidos.ToList());
            }
        }



        [HttpGet("{id}")]
        public ActionResult<ItemPedido> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                ItemPedido user = context.ItemPedidos.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();
                return user;
            }
        }



        [HttpPost]
        public ActionResult<ItemPedido> Post(ItemPedido item)
        {
            using (MyContext ctx = new MyContext())
            {

                ctx.ItensPedidos.Add(item);

                ctx.SaveChanges();
            }
            return item;
        }



        [HttpPut]
        public ActionResult<ItemPedido> Put(ItemPedido item)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.ItensPedidos.Update(item);
                ctx.SaveChanges();
            }

            return item;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                ItemPedido item = ctx.ItemPedidos.Where(u => u.Id.Equals(id)).FirstOrDefault();
                if (item == null)
                    return NotFound();
                ctx.ItemPedidos.Remove(item);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}