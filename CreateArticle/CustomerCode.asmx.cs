using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

namespace CreateArticle
{
    /// <summary>
    /// Summary description for CustomerCode
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CustomerCode : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetCustomerCode(string code)
        {
            List<string> result = new List<string>();
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\C#\Office\Tablas.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand("select CodCli,NomCli from [Clientes] where CodCli LIKE '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", code);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(string.Format(dr["CodCli"].ToString()));
                    }
                    return result;
                }
            }
        }
    }
}
