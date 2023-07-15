using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using CRUD.Models;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.ConstrainedExecution;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public void Create(EnderecoModel enderecoModel)
        {
            var query = @"insert into endereco values
                        (
                         @Id_usuario,
                         @Rua,
                         @Numero,
                         @Cep
                        )";
            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Id_usuario = enderecoModel.ID_usuario,
                        Rua = enderecoModel.rua,
                        Numero = enderecoModel.numero,
                        Cep = enderecoModel.cep
                    }).FirstOrDefault();
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public EnderecoModel GetById(int id)
        {
            var query = @"select * from endereco where ID = @Id";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                var resp = conn.Query<EnderecoModel>(query,
                    new
                    { Id = id }).FirstOrDefault();

                return resp;
            }
        }

        [HttpPut]
        [Route("Update")]
        public void Update(EnderecoModel enderecoModel)
        {
            var query = @"Update endereco set
                        rua = @Rua,
                        numero = @Numero,
                        cep = @Cep
                      where ID = @id";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query,
                    new
                    {
                        Rua = enderecoModel.rua,
                        Numero = enderecoModel.numero,
                        Cep = enderecoModel.cep,
                        id = enderecoModel.ID
                    }).FirstOrDefault();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            var query = @"delete from endereco where ID = @Id";

            using (var conn = new SqlConnection("Server=DAISY\\SQLEXPRESS; Database=CRUD; User Id=sa; Password=anonimo;"))
            {
                conn.Open();

                conn.Query(query, new { Id = id }).FirstOrDefault();

            }
        }
    }
}
