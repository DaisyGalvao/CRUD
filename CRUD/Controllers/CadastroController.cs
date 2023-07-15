using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using CRUD.Models;
using System.Data.SqlClient;
using Dapper;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(CadastroModel cadastroModel)
        {
            var query = @"insert into cadastro values
                        (
                         @Nome,
                         @Email
                        )";
            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            { 
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = cadastroModel.nome,
                        Email = cadastroModel.email
                    }).FirstOrDefault();
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public CadastroModel GetById(int id)
        {
            var query = @"select * from cadastro where ID = @Id";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<CadastroModel>(query,
                    new
                    { Id = id }).FirstOrDefault();

                return resp;
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<CadastroModel> GetAll()
        {
            var query = @"select * from cadastro";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<CadastroModel>(query).ToList();

                return resp;
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update(CadastroModel cadastroModel)
        {
            var query = @"Update cadastro set
                        nome = @Nome,
                        email = @Email
                      where ID = @id"; 

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Nome = cadastroModel.nome,
                        Email = cadastroModel.email,
                        Id = cadastroModel.ID
                    }).FirstOrDefault();
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            var query = @"delete from cadastro where ID = @Id";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new { Id = id }).FirstOrDefault();
                   
            }
        }

    }

}
