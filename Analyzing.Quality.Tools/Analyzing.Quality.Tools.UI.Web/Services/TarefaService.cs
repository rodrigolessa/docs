using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Analyzing.Quality.Tools.UI.Web.Services
{
    public class TarefaService
    {
        private void CarregaDados()
        {
            StringBuilder sb = new StringBuilder();
            SqlConnection conn = new SqlConnection(@"data source=(local);initial catalog=ProvaDeConceito;persist security info=True;user id=sa;password=q1w2e3;MultipleActiveResultSets=True;App=EntityFramework");
            string sql = @"select Id,Nome from Alunos";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    sb.Append("\nId: ");
                    sb.Append(rdr.GetValue(0) + "\t\t" + rdr.GetValue(1));
                    sb.Append("\n");
                }
            }
            catch (SqlException ex)
            {
                sb.Append(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private async void CarregarDadosAssincrono()
        {
            StringBuilder sb = new StringBuilder();
            SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Cadastro;Integrated Security=True");
            string sql = @"select Id,Nome from Alunos";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                await conn.OpenAsync();

                using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                    {
                        sb.Append("\nId: ");
                        sb.Append(await rdr.GetFieldValueAsync<int>(0) + "\t\t" + await rdr.GetFieldValueAsync<string>(1));
                        sb.Append("\n");
                    }
                }
            }
            catch (SqlException ex)
            {

                sb.Append(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        IDriverBase driver;

        public void SetupTestComplexidade(int prm1, string prm2, string prm3)
        {
            var appURL = prm3.Trim();

            if (prm1 == 0)
                appURL = "http://www.google.com/";
            else if (prm1 == 9)
                appURL = "http://www.testers.com/";
            else if (prm1 == 9 && prm2 == "outro")
                appURL = "http://localhost/teste";
            else
                appURL = "http://www.bing.com/";

            if (appURL.Length > 50)
                return;

            for (int i = 0; i < appURL.Length; i++)
            {
                string browser = "Chrome";
                switch (browser)
                {
                    case "Chrome":
                        driver = new ChromeDriver();
                        break;
                    case "Firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "IE":
                        driver = new InternetExplorerDriver();
                        break;
                    default:
                        if (i == 5)
                        {
                            appURL = "posição 5";
                            if (prm2 == "posicao")
                                appURL = "http://microsoft.com.br";
                        }
                        else
                            appURL = "http://github.com";
                        driver = new ChromeDriver();
                        break;
                }
            }
        }
    }

    internal class InternetExplorerDriver : IDriverBase
    {
    }

    internal class FirefoxDriver : IDriverBase
    {
    }

    internal class ChromeDriver : IDriverBase
    {
        public ChromeDriver()
        {
        }
    }

    internal interface IDriverBase
    {
    }
}