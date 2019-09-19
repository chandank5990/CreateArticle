using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace CreateArticle
{

    public partial class Article : System.Web.UI.Page
    {
        static string Custcode;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb");
        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CSK\Tablas.mdb");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PnlModifyArticle.Visible = false;
                pnlCreateNArticle.Visible = false;
                btnModifyArticle.Enabled = false;
                btnCreateNArticle.Enabled = false;
                TextBox1.Focus();
            }
            
        }

        protected void btnModifyArticle_Click(object sender, EventArgs e)
        {
            PnlModifyArticle.Visible = true;
            pnlCreateNArticle.Visible = false;
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            I1.Visible = false;
            TextBox4.Focus();
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        protected void btnCreateNArticle_Click(object sender, EventArgs e)
        {
            //if (TextBox3.Text != "")
            //{
                AddDefaultFirstRecord();
                PnlModifyArticle.Visible = false;
                pnlCreateNArticle.Visible = true;
                //TextBox12.Text = (Convert.ToInt64(TextBox3.Text) + 1).ToString();
                TextBox16.Text = "15000";
                TextBox14.Text = "DIE ";
                TextBox14.Focus();
                //TextBox14.Text = TextBox14.Text.Length - 1;
                TextBox17.Text = "40";
                btnCreateNArticle.Enabled = false;
                
            //}
            //else
            //{
            //    string script = "alert('Last Article No. Not Available !!!')";
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnCreateArt, this.GetType(), "Test", script, true);
            //}
            TextBox13.Text = "";
            //TextBox14.Text = "";
            TextBox15.Text = "";
            //TextBox17.Text = "";
            TextBox12.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                string script = "alert('Plz Inter Customer Code !!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSearch, this.GetType(), "Test", script, true);
                btnModifyArticle.Enabled = false;
                btnCreateNArticle.Enabled = false;
                PnlModifyArticle.Visible = false;
                pnlCreateNArticle.Visible = false;
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            else
            {
                if (TextBox1.Text == "494901" || TextBox1.Text == "343401")
                {
                    RemoveArticle();
                }
                else
                {
                    OleDbCommand cmd = con.CreateCommand();
                    con.Open();
                    cmd = new OleDbCommand("SELECT DISTINCTROW NomCli FROM [Clientes] WHERE CodCli = '" + TextBox1.Text + "' ", con);
                    //cmd = new OleDbCommand("SELECT DISTINCTROW [Clientes].NomCli,[Artículos de clientes].CodArt FROM ( [Clientes] INNER JOIN [Artículos de clientes]   ON  [Clientes].CodCli = [Artículos de clientes].CodArtCli) WHERE [Clientes].CodCli = '" + TextBox1.Text + "' ORDER BY [Artículos de clientes].CodArt DESC", con);
                    //OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //oldA.Fill(dt);

                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.FieldCount > 0)
                        {
                            TextBox2.Text = reader["NomCli"].ToString();
                            //TextBox3.Text = reader["CodArt"].ToString();

                            btnModifyArticle.Enabled = true;
                            btnCreateNArticle.Enabled = true;

                            TextBox11.Text = TextBox1.Text;
                            HiddenField1.Value = TextBox1.Text;
                            PnlModifyArticle.Visible = false;
                            pnlCreateNArticle.Visible = false;
                            btnModifyArticle.Focus();
                            Custcode = TextBox11.Text;
                        }
                    }
                    else
                    {
                        string script = "alert('Invalid Customer Code !!!')";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSearch, this.GetType(), "Test", script, true);
                    }

                }

            }
        }

        void RemoveArticle()
        {
            if (TextBox1.Text == "494901" || TextBox1.Text == "343401")
            {
                OleDbCommand cmd1 = con.CreateCommand();
                con.Open();
                cmd1 = new OleDbCommand("SELECT TOP 4 [Clientes].NomCli,[Artículos de clientes].CodArt FROM ( [Clientes] INNER JOIN [Artículos de clientes]   ON  [Clientes].CodCli = [Artículos de clientes].CodArtCli) WHERE [Clientes].CodCli = '" + TextBox1.Text + "' ORDER BY [Artículos de clientes].CodArt DESC", con);
                OleDbDataAdapter oldA = new OleDbDataAdapter(cmd1);
                DataTable dt = new DataTable();
                oldA.Fill(dt);
                con.Close();
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["CodArt"].ToString() == "49490109001" || dr["CodArt"].ToString() == "49490109002" || dr["CodArt"].ToString() == "49490109003")
                    {
                        dr.Delete();
                    }
                    else if (dr["CodArt"].ToString() == "34340109001" || dr["CodArt"].ToString() == "34340109002" || dr["CodArt"].ToString() == "34340109003")
                    {
                        dr.Delete();
                    }
                    //else if (dr["CodArt"].ToString() == "49490109003")
                    //{
                    //    dr.Delete();
                    //}

                }
                dt.AcceptChanges();
                TextBox2.Text = dt.Rows[0]["NomCli"].ToString();
                TextBox3.Text = dt.Rows[0]["CodArt"].ToString();

                btnModifyArticle.Enabled = true;
                btnCreateNArticle.Enabled = true;

                TextBox11.Text = TextBox1.Text;
                HiddenField1.Value = TextBox1.Text;
                PnlModifyArticle.Visible = false;
                pnlCreateNArticle.Visible = false;
                btnModifyArticle.Focus();
                Custcode = TextBox11.Text;
            }
        }



        protected void btnSearchArticle_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            if (TextBox4.Text == "" && TextBox5.Text == "")
            {
                string script = "alert('Plz Enter Article Or Drawing No. !!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnCreateArt, this.GetType(), "Test", script, true);
                //btnSearchArticle.Focus();
            }
            else
            {
                if (TextBox4.Text != "")
                {
                    cmd = new OleDbCommand("SELECT DISTINCTROW [Artículos de clientes].CodArt, [Artículos de clientes].NomArt, [Artículos de clientes].Precio, [Artículos de clientes].PlaArt, [Artículos de clientes].Descuento FROM [Artículos de clientes] WHERE CodArt = '" + TextBox4.Text + "' AND CodArtCli = '" + TextBox1.Text + "' ", con);
                }
                if (TextBox5.Text != "")
                {
                    cmd = new OleDbCommand("SELECT DISTINCTROW [Artículos de clientes].CodArt, [Artículos de clientes].NomArt, [Artículos de clientes].Precio, [Artículos de clientes].PlaArt, [Artículos de clientes].Descuento FROM [Artículos de clientes] WHERE PlaArt = '" + TextBox5.Text + "' AND CodArtCli = '" + TextBox11.Text + "' ", con);
                }

                //OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //oldA.Fill(dt);

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.FieldCount > 0)
                    {
                        TextBox6.Text = reader["CodArt"].ToString();
                        TextBox7.Text = reader["NomArt"].ToString();
                        TextBox8.Text = reader["Precio"].ToString();
                        TextBox9.Text = reader["PlaArt"].ToString();
                        TextBox10.Text = reader["Descuento"].ToString();

                        I1.Visible = true;
                        I1.Attributes.Add("src", "Drawing2.aspx?Article=" + reader["CodArt"].ToString() + "&testdrawing= kkk");
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        con.Close();
                    }
                }
                else
                {
                    string script = "alert('Article Or Drawing No. Not Found!!!')";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSearchArticle, this.GetType(), "Test", script, true);
                }
                
            }
        }

        void LastArtice()
        {
            if (TextBox1.Text == "494901" || TextBox1.Text == "343401")
            {
                OleDbCommand cmd1 = con.CreateCommand();
                con.Open();
                cmd1 = new OleDbCommand("SELECT TOP 4 [Clientes].NomCli,[Artículos de clientes].CodArt FROM ( [Clientes] INNER JOIN [Artículos de clientes]   ON  [Clientes].CodCli = [Artículos de clientes].CodArtCli) WHERE [Clientes].CodCli = '" + TextBox1.Text + "' ORDER BY [Artículos de clientes].CodArt DESC", con);
                OleDbDataAdapter oldA = new OleDbDataAdapter(cmd1);
                DataTable dt = new DataTable();
                oldA.Fill(dt);
                con.Close();
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr["CodArt"].ToString() == "49490109001" || dr["CodArt"].ToString() == "49490109002" || dr["CodArt"].ToString() == "49490109003")
                    {
                        dr.Delete();
                    }
                    else if (dr["CodArt"].ToString() == "34340109001" || dr["CodArt"].ToString() == "34340109002" || dr["CodArt"].ToString() == "34340109003")
                    {
                        dr.Delete();
                    }
                    //else if (dr["CodArt"].ToString() == "49490109003")
                    //{
                    //    dr.Delete();
                    //}

                }
                dt.AcceptChanges();
                //TextBox2.Text = dt.Rows[0]["NomCli"].ToString();
                TextBox3.Text = dt.Rows[0]["CodArt"].ToString();

                TextBox12.Text = (Convert.ToInt64(dt.Rows[0]["CodArt"].ToString()) + 1).ToString();

                //TextBox11.Text = TextBox1.Text;
                //HiddenField1.Value = TextBox1.Text;

            }
        }

        protected void btnCreateArt_Click(object sender, EventArgs e)
        {

            if (TextBox13.Text != "" && TextBox14.Text != "" && TextBox15.Text != "" && TextBox16.Text != "" && TextBox17.Text != "")
            {
                if (TextBox1.Text == "494901" || TextBox1.Text == "343401")
                {
                    LastArtice();
                }

                else
                {
                    OleDbCommand cmd1 = con.CreateCommand();
                    con.Open();
                    cmd1 = new OleDbCommand("SELECT DISTINCTROW CodArt FROM [Artículos de clientes] WHERE CodArtCli = '" + TextBox1.Text + "' ORDER BY [Artículos de clientes].CodArt DESC", con);
                    //OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //oldA.Fill(dt);

                    OleDbDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.FieldCount > 0)
                        {
                            TextBox12.Text = (Convert.ToInt64(reader["CodArt"]) + 1).ToString();
                        }
                        if (reader["CodArt"].ToString().StartsWith("0"))
                        {
                            TextBox12.Text = "0" + TextBox12.Text;
                        }
                        
                    }

                    else
                    {
                        TextBox12.Text = TextBox1.Text + "00001";
                    }
                    con.Close();
                }
                //LastArtice();

                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd = new OleDbCommand("Insert into [Artículos de clientes] (CodArt, NomArt, Precio, PlaArt, Descuento, FamPie, CodArtCli) Values ('" + TextBox12.Text + "', '" + TextBox14.Text + "', " + TextBox15.Text + ", '" + TextBox13.Text + "', " + TextBox17.Text + ", '" + TextBox16.Text + "', '" + HiddenField1.Value + "') ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                AddNewRecordRowToGrid();
                //btnCreateArt.Enabled = false;
                string script = "alert('Article Created Successfully !!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnCreateArt, this.GetType(), "Test", script, true);
                //btnCreateArt.Enabled = true;
                //TextBox12.Text = (Convert.ToInt64(TextBox12.Text) + 1).ToString();
                TextBox14.Focus();
                TextBox13.Text = "";
                TextBox14.Text = "DIE ";
                TextBox15.Text = "";
                //TextBox16.Text = "";
                //TextBox17.Text = "";
                
            }
            else
            {
                string script = "alert('Plz Fill All The Fields Properly !!!')";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnCreateArt, this.GetType(), "Test", script, true);
            }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            List<string> result = new List<string>();
            //using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\Software\CSK\Tablas.mdb"))
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand("select CodCli,NomCli from [Clientes] where CodCli LIKE '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(string.Format("{0}", dr["CodCli"]));
                    }
                    return result;
                }
            }
        }

        //AutoComplete Article
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchArticles(string prefixText, int count)
        {
            List<string> result = new List<string>();
            //using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = W:\Software\CSK\Tablas.mdb"))
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand("select CodArt from [Artículos de clientes] where CodArt LIKE '%'+@SearchText+'%' AND CodArtCli = '" + Custcode + "' ORDER BY [Artículos de clientes].CodArt DESC", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(string.Format("{0}", dr["CodArt"]));
                    }
                    return result;
                }
            }
        }

        //AutoComplete Marking
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public  static List<string> SearchMarkings(string prefixText, int count)
        {
            Article Art = new Article();
            List<string> result = new List<string>();
            //using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\Software\CSK\Tablas.mdb"))
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand("select PlaArt from [Artículos de clientes] where PlaArt LIKE '%'+@SearchText+'%' AND CodArtCli = '"+Custcode+"'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(string.Format("{0}", dr["PlaArt"]));
                    }
                    return result;
                }
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd = new OleDbCommand("UPDATE [Artículos de clientes] SET NomArt = '"+TextBox7.Text+"' , Precio = "+TextBox8.Text+" , PlaArt = '"+TextBox9.Text+"' , Descuento = "+TextBox10.Text+" , CodArtCli = '"+TextBox11.Text+"' WHERE CodArt = '" + TextBox6.Text + "'", con);
            OleDbDataReader reader = cmd.ExecuteReader();

            string script = "alert('Modified Successfully !!!')";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnModify, this.GetType(), "Test", script, true);
        }
        private void AddDefaultFirstRecord()
        {
            //creating DataTable
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "Article";
            //creating columns for DataTable
            dt.Columns.Add(new DataColumn("Article", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Family", typeof(int)));
            dt.Columns.Add(new DataColumn("Marking", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Discount", typeof(int)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["Article"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            if (ViewState["Article"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["Article"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //Creating new row and assigning values
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Article"] = TextBox12.Text;
                        drCurrentRow["Description"] = TextBox14.Text;
                        drCurrentRow["Family"] = TextBox16.Text;
                        drCurrentRow["Marking"] = TextBox13.Text;
                        drCurrentRow["Price"] = TextBox15.Text;
                        drCurrentRow["Discount"] = TextBox17.Text;
                    }
                    //Removing initial blank row
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //Added New Record to the DataTable
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //storing DataTable to ViewState
                    ViewState["Article"] = dtCurrentTable;
                    //binding Gridview with New Row
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
        }

    }
}