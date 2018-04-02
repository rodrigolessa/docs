using Analyzing.Quality.Tools.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analyzing.Quality.Tools.UI.Web.Services
{
    public class FuncionarioService
    {
        public Funcionario Obter(string id)
        {
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

            return funcionario;
        }
    }
}