<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Back_end.Context;
using Back_end.Entity;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aereo.Context;
using Ecommerce.Context;
using Ecommerce.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
>>>>>>> cbffc80931c3d623a4b914fdd8e582f4d1ad1e3c

namespace Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
<<<<<<< HEAD

        // Criando um Metodo do tipo Get para retornar todos os usuarios.
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            //Instanciando um novo Context
            //usamos o using para garantir que a conexão com o banco de dados será encerrado
            using (MyContext ctx = new MyContext())
            {
                //Retorna uma lista com todos os usuários;
=======
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
>>>>>>> cbffc80931c3d623a4b914fdd8e582f4d1ad1e3c
                return Ok(ctx.Clientes.ToList());
            }
        }

<<<<<<< HEAD
        //Criando mais um metodo do tipo Get, onde pediremos para o client o ID do tipo Int
        //e retornaremos um objeto do tipo Usuario
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetPeloId(int id)
        {
            using (MyContext context = new MyContext())
            {
                //Aplicando consulta no campo ID e retornando o primeiro registro ou NULL (Nulo)
                Usuario user = context.Clientes.Where(u => u.Id.Equals(id)).FirstOrDefault();

                if (user == null)
                    return NotFound();


                return user;
            }
        }

        //Criando um metodo para inserir registro do tipo Usuario
        [HttpPost]
        public ActionResult<Cliente> Post(Cliente usuario)
        {
            using (MyContext ctx = new MyContext())
            {
                //Inserindo no banco de dados um usuario sem informar o ID
                //e o metodo Add adiciona o ID para nós com o que foi gerado
                ctx.Usuarios.Add(usuario);
                //Efetivamente realizando as alterações no BD
                ctx.SaveChanges();
            }
            //Retornando o usuario inserido já com o ID.
            return usuario;
        }

        //Criando o Put que se refere a alteração de registros no banco de dados
        [HttpPut]
        public ActionResult<Cliente> Put(Cliente usuario)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //Metodo para alterar o registro no Banco de Dados
                ctx.Usuarios.Update(usuario);
                //Confirmar a alteração
                ctx.SaveChanges();
            }

            return usuario;
        }

        //Criando metodo para deletar um usuario, para isso o usuario deve informar um ID
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //Instanciando um context para interagir com o banco de dados
            using (MyContext ctx = new MyContext())
            {
                //O metodo Remove exige um usuario
                //Para isso estamos fazendo a consulta no banco de dados pelo ID
                Cliente usuario = ctx.Clientes.Where(u => u.Id.Equals(id)).FirstOrDefault();

                //Caso não encontre o BD o id informado, retorna NotFound (Não encontrado)
                if (usuario == null)
                    return NotFound();

                //Metodo para remover o usuario
                ctx.Clientes.Remove(usuario);
                //Efetiva a alteração
                ctx.SaveChanges();
            }

            return Ok();
=======
        [HttpGet("{id}")]
        public ActionResult GetPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente cliente = ctx.Clientes.Include(c=>c.Endereco).Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente cliente = ctx.Clientes.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (cliente == null)
                    return NotFound();

                ctx.Clientes.Remove(cliente);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
            return Ok(cliente);
        }

        [HttpPost("login")]
        public ActionResult Login(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Cliente usuario = ctx.Clientes.Where(u => u.Email.Equals(cliente.Email) && u.Senha.Equals(cliente.Senha)).FirstOrDefault();

                if (usuario == null)
                    return NotFound();
                else
                {
                    usuario.Senha = "";
                    return Ok(usuario);
                }
            }
        }

        [HttpPut]
        public ActionResult Put(Cliente cliente)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Clientes.Update(cliente);
                ctx.SaveChanges();
            }
            return Ok(cliente);
>>>>>>> cbffc80931c3d623a4b914fdd8e582f4d1ad1e3c
        }
    }
}