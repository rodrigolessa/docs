using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Analyzing.Quality.Tools.UI.Web.Models;

namespace Analyzing.Quality.Tools.UI.Web.Controllers
{
    public class FuncionarioController : ApiController
    {
        private ProvaDeConceito db = new ProvaDeConceito();

        // GET: api/Funcionario
        public IQueryable<Funcionario> GetFuncionario()
        {
            return db.Funcionario;
        }

        // GET: api/Funcionario/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult GetFuncionario(string id)
        {
            //Funcionario funcionario = db.Funcionario.Find(id);
            //if (funcionario == null)
            //{
            //    return NotFound();
            //}

            // HACK: Código alterado para simular uma falha de segurança - SQL Injection

            var funcionario = new Funcionario();

            var strconn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProvaDeConceito"].ToString();
            var strquery = "SELECT [Nome], [Email] FROM [dbo].[Funcionario] WHERE [Id] = " + id;

            using (var conn = new System.Data.SqlClient.SqlConnection(strconn))
            {
                var command = new System.Data.SqlClient.SqlCommand(strquery, conn);
                command.Connection.Open();

                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                    funcionario.Nome = rd["Nome"] as string;
                    funcionario.Email = rd["Email"] as string;
                }
            }

            return Ok(funcionario);
        }

        // PUT: api/Funcionario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionario(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            db.Entry(funcionario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Funcionario
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult PostFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcionario.Add(funcionario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcionario.Id }, funcionario);
        }

        // DELETE: api/Funcionario/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult DeleteFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            db.Funcionario.Remove(funcionario);
            db.SaveChanges();

            return Ok(funcionario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionarioExists(int id)
        {
            return db.Funcionario.Count(e => e.Id == id) > 0;
        }
    }
}