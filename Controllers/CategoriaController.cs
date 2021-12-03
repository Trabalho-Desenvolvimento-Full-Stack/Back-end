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
    public class CategoriaController : ControllerBase
    {

        // Criando um Metodo do tipo Get para retornar todos os categorias.
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
                return Ok(ctx.Categorias.ToList());
            }
        }

        //Criando mais um metodo do tipo Get, onde pediremos para o client o ID do tipo Int
        //e retornaremos um objeto do tipo Categoria
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                Categoria user = context.Categorias.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();


                return user;
            }
        }

        //Criando um metodo para inserir registro do tipo Categoria
        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            using (MyContext ctx = new MyContext())
            {
                //Inserindo no banco de dados um categoria sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.Categorias.Add(categoria);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();
            }
            //Retornando o categoria inserido já com o ID.
            return categoria;
        }

        //Criando o Put que se refere a alteração de registros no banco de dados
        [HttpPut]
        public ActionResult<Cliente> Put(Cliente categoria)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //Metodo para alterar o registro no Banco de Dados
                ctx.Categorias.Update(categoria);
                //Confirmar a alteração
                ctx.SaveChanges();
            }

            return categoria;
        }

        //Criando metodo para deletar um categoria, para isso o categoria deve informar um ID
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um categoria
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                Cliente categoria = ctx.Clientes.Where(u => u.Id.Equals(id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (categoria == null)
                    return NotFound();

                //Metodo para remover o categoria
                ctx.Clientes.Remove(categoria);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}