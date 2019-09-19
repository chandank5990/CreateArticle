using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace CopySteps
{
    public partial class Page2 : System.Web.UI.Page
    {
        public OleDbConnection database;
        DataTable udata = new DataTable();
        DataTable uMissingSteps = new DataTable();
        DataTable data = new DataTable();
        DataTable MissingSteps = new DataTable();
        OleDbConnection con = new OleDbConnection();
        OleDbCommand oleDbCmd = new OleDbCommand();
        String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CSK\Tablas.mdb";
        //String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb";
        //String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\\test\\Access\\tablas.mdb";
        OleDbDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(connParam);
            // Button1_Click(null, null);
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TxtFrom.Text = Session["PTNo"] as String;
            Button1_Click(null,null);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*int originalFromPT = 0;
            int originalToPt = 0;

            bool bfrmPT = false;
            bool btoPT = false;

            bfrmPT = Int32.TryParse(TxtFrom.Text, out originalFromPT);
            btoPT = Int32.TryParse(TxtTo.Text, out originalToPt);

            if (TxtTo.Text.Length == 0)
                TxtTo.Text = TxtFrom.Text;
            
            int fromPT, toPT;
            DataTable check = new DataTable();
            bfrmPT = Int32.TryParse(TxtFrom.Text, out fromPT);
            btoPT = Int32.TryParse(TxtTo.Text, out toPT);*/


           /* for (int i = fromPT; i <= toPT; i++)
            {

                TxtFrom.Text = i + "";
                DataSet ds = new DataSet();
                OleDbCommand oleDbCmd = con.CreateCommand();
                oleDbCmd = new OleDbCommand("SELECT [Artículos de clientes].CodArt, [Artículos de clientes].FamPie, [Artículos de clientes].NomArt, [Ordenes de fabricación].NumOrd, [Ordenes de fabricación].PinOrd, [Ordenes de fabricación].ArtOrd, [Ordenes de fabricación].PieOrd, [Ordenes de fabricación].EntOrd, [Ordenes de fabricación].Observaciones, [Ordenes de fabricación].Datos, [Ordenes de fabricación].PlaOrd,[Artículos de clientes].UltIndice " +
                    " FROM [Pedidos de clientes] INNER JOIN ([Artículos de clientes] INNER JOIN [Ordenes de fabricación] ON [Artículos de clientes].CodArt = [Ordenes de fabricación].ArtOrd) ON [Pedidos de clientes].NumPed = [Ordenes de fabricación].PinOrd " +
                    " WHERE [Pedidos de clientes].NumPed LIKE '" + i + "' ORDER BY [Ordenes de fabricación].NumOrd ASC", con);

                OleDbDataAdapter Da = new OleDbDataAdapter(oleDbCmd);
                Da.SelectCommand = oleDbCmd;
                Da.Fill(data);
            }
            string temp = "";
            OleDbCommand oleDbCmd2 = con.CreateCommand();
            for (int i = 0; i < data.Columns.Count; i++)
            {
                MissingSteps.Columns.Add("column" + i.ToString());
            }

            for (int j = 0; j < data.Rows.Count; j++)
            {
                oleDbCmd2 = new OleDbCommand("SELECT * FROM [Artículos de clientes (fases)] WHERE CodArt = '" + data.Rows[j][0].ToString() + "' ", con);

                OleDbDataAdapter Da2 = new OleDbDataAdapter(oleDbCmd2);
                Da2.SelectCommand = oleDbCmd2;
                Da2.Fill(check);

                if (check.Rows.Count > 0)
                {
                    check.Clear();
                }
                else
                {
                    MissingSteps.Rows.Add(data.Rows[j].ItemArray);
                }

            }
            //GridView1.DataSource = MissingSteps;

            //GridView1.DataBind();
            var MissingUnique = MissingSteps.AsEnumerable()
                       .GroupBy(x => x.Field<string>("column0"))
                       .Select(g => g.First());
            if (MissingSteps.Rows.Count > 0)
            {

                DataTable MisUniq = MissingUnique.CopyToDataTable();
                DataTable final = new DataTable();
                DataRow dr = final.NewRow();
                DataTable dt = new DataTable();
                dt.Columns.Add("CodArt");

                for (int k = 0; k < 11; k++)
                    final.Columns.Add();

                for (int i = 0; i < MisUniq.Rows.Count; i++)
                {*/
            DataTable dt = new DataTable();
            dt.Columns.Add("CodArt");
            DataTable final = new DataTable();
                    OleDbCommand oleDbCmd3 = con.CreateCommand();
                    oleDbCmd3 = new OleDbCommand("SELECT  NumFas, CodPie, Operac, FasExt FROM [Familias de piezas (fases)] WHERE CodFam = '" + 15000 + "' ", con);
                    OleDbDataAdapter Da = new OleDbDataAdapter(oleDbCmd3);
                    Da.SelectCommand = oleDbCmd3;
                    Da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        //dt.Rows[0]["CodArt"] = 5;
                        //row["CodArt"] = MisUniq.Rows[i][0].ToString();
                        row["CodArt"] =TxtFrom.Text;
                        final.Rows.Add(row.ItemArray);
                    }
                    dt.Clear();
                //}
                GridView1.DataSource = final;
                GridView1.DataBind();
            }
            //else
            //{
            //    string script = "alert('There is No Any Missing Steps To Copy !!!')";
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button1, this.GetType(), "Test", script, true);
            //}
       
            //TxtFrom.Text = originalFromPT + "";
            //TxtTo.Text = originalToPt + "";
            //Button3_Click1(null, null);
      
       // }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int originalFromPT = 0;
            //int originalToPt = 0;

            Button2_Click(null, null);
            foreach (GridViewRow g1 in GridView1.Rows)
            {

                OleDbCommand oleDbCmd4 = con.CreateCommand();
                con.Open();
                //oleDbCmd4 = new OleDbCommand("INSERT INTO [Artículos de clientes (fases)] (CodArt, NumFas, CodPie,Operac, FasExt, CodMaq, CodUti, TiePre, TieFab, CodPro, Control) VALUES ('" + g1.Cells[0].Text + "'," + g1.Cells[1].Text + ", '" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "', " + g1.Cells[4].Text + ", " + g1.Cells[5].Text + ",'" + g1.Cells[6].Text + "', " + g1.Cells[7].Text + "," + g1.Cells[8].Text + "," + g1.Cells[9].Text + ",'"+ g1.Cells[10].Text+"')", con);
                oleDbCmd4 = new OleDbCommand("INSERT INTO [Artículos de clientes (fases)] (CodArt, NumFas, CodPie,Operac, FasExt) VALUES ('" + g1.Cells[0].Text + "'," + g1.Cells[1].Text + ", '" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "', " + g1.Cells[4].Text + ")", con);
                oleDbCmd4.ExecuteNonQuery();
                con.Close();

            }
            //string script = "alert('Steps Copied Successfully In Article !!!')";
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button2, this.GetType(), "Test", script, true);
            //GridView1.DataSource = null;
            //GridView1.DataBind();

            //TxtFrom.Text = originalFromPT + "";
            //TxtTo.Text = originalToPt + "";

            //Button4_Click(null, null);

            string script = "alert('Steps Copied Successfully !!!')";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button2, this.GetType(), "Test", script, true);
            GridView1.DataSource = null;
            GridView1.DataBind();

        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (TxtTo.Text.Length == 0)
                TxtTo.Text = TxtFrom.Text;
            bool bfrmPT = false;
            bool btoPT = false;
            int fromPT, toPT;
            DataTable ucheck = new DataTable();
            bfrmPT = Int32.TryParse(TxtFrom.Text, out fromPT);
            btoPT = Int32.TryParse(TxtTo.Text, out toPT);
            for (int i = fromPT; i <= toPT; i++)
            {

                TxtFrom.Text = i + "";
                OleDbCommand uoleDbCmd = con.CreateCommand();

                uoleDbCmd = new OleDbCommand("SELECT [Ordenes de fabricación].NumOrd, [Artículos de clientes].CodArt, [Artículos de clientes].FamPie, [Artículos de clientes].NomArt, [Ordenes de fabricación].PinOrd, [Ordenes de fabricación].ArtOrd, [Ordenes de fabricación].PieOrd, [Ordenes de fabricación].EntOrd, [Ordenes de fabricación].Observaciones, [Ordenes de fabricación].Datos, [Ordenes de fabricación].PlaOrd,[Artículos de clientes].UltIndice " +
                    " FROM [Pedidos de clientes] INNER JOIN ([Artículos de clientes] INNER JOIN [Ordenes de fabricación] ON [Artículos de clientes].CodArt = [Ordenes de fabricación].ArtOrd) ON [Pedidos de clientes].NumPed = [Ordenes de fabricación].PinOrd " +
                    " WHERE [Pedidos de clientes].NumPed LIKE '" + i + "' ORDER BY [Ordenes de fabricación].NumOrd ASC", con);

                OleDbDataAdapter uDa = new OleDbDataAdapter(uoleDbCmd);
                uDa.SelectCommand = uoleDbCmd;
                uDa.Fill(udata);
                //GridView2.DataSource = data;
                //GridView2.DataBind();
            }
            string temp = "";
            OleDbCommand uoleDbCmd2 = con.CreateCommand();
            for (int i = 0; i < udata.Columns.Count; i++)
            {
                uMissingSteps.Columns.Add("column" + i.ToString());
            }

            for (int j = 0; j < udata.Rows.Count; j++)
            {
                uoleDbCmd2 = new OleDbCommand("SELECT NumOrd FROM [Ordenes de fabricación (fases)] WHERE [Ordenes de fabricación (fases)].NumOrd LIKE '" + udata.Rows[j][0] + "'", con);

                OleDbDataAdapter uDa2 = new OleDbDataAdapter(uoleDbCmd2);
                uDa2.SelectCommand = uoleDbCmd2;
                uDa2.Fill(ucheck);

                if (ucheck.Rows.Count > 0)
                {
                    ucheck.Clear();
                }
                else
                {
                    uMissingSteps.Rows.Add(udata.Rows[j].ItemArray);
                }

            }
            //GridView1.DataSource = MissingSteps;

            //GridView1.DataBind();
            var MissingUnique = uMissingSteps.AsEnumerable()
                       .GroupBy(x => x.Field<string>("column0"))
                       .Select(g => g.First());
            if (uMissingSteps.Rows.Count > 0)
            {

                DataTable MisUniq = MissingUnique.CopyToDataTable();


                DataTable ufinal = new DataTable();
                DataRow dr = ufinal.NewRow();
                DataTable dt = new DataTable();
                dt.Columns.Add("NumOrd");

                for (int k = 0; k < 11; k++)
                    ufinal.Columns.Add();
                //final.Columns.Add(); // For FasFin
                //final.Columns.Add(); //For CasFin

                for (int i = 0; i < MisUniq.Rows.Count; i++)
                {
                    OleDbCommand uoleDbCmd3 = con.CreateCommand();
                    uoleDbCmd3 = new OleDbCommand("SELECT  NumFas, CodPie, Operac, FasExt FROM [Familias de piezas (fases)] WHERE CodFam LIKE '" + "15000" + "' ", con);
                    OleDbDataAdapter uDa6 = new OleDbDataAdapter(uoleDbCmd3);
                    uDa6.SelectCommand = uoleDbCmd3;
                    uDa6.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        row["NumOrd"] = MisUniq.Rows[i][0].ToString();
                        ufinal.Rows.Add(row.ItemArray);
                    }
                    dt.Clear();
                }
                GridView2.DataSource = ufinal;
                GridView2.DataBind();
            }
            //else
            //{
            //    string script = "alert('There is No Any Missing Steps To Copy In UID !!!')";
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button1, this.GetType(), "Test", script, true);
            //}
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Button3_Click1(null, null);
            foreach (GridViewRow g1 in GridView2.Rows)
            {

                OleDbCommand oleDbCmd4 = con.CreateCommand();
                con.Open();
                //oleDbCmd4 = new OleDbCommand("INSERT INTO [Artículos de clientes (fases)] (CodArt, NumFas, CodPie,Operac, FasExt, CodMaq, CodUti, TiePre, TieFab, CodPro, Control) VALUES ('" + g1.Cells[0].Text + "'," + g1.Cells[1].Text + ", '" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "', " + g1.Cells[4].Text + ", " + g1.Cells[5].Text + ",'" + g1.Cells[6].Text + "', " + g1.Cells[7].Text + "," + g1.Cells[8].Text + "," + g1.Cells[9].Text + ",'"+ g1.Cells[10].Text+"')", con);
                oleDbCmd4 = new OleDbCommand("INSERT INTO [Ordenes de fabricación (fases)] (NumOrd, NumFas, CodPie,Operac, FasExt,FasFin,CanFab) VALUES ('" + g1.Cells[0].Text + "'," + g1.Cells[1].Text + ", '" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "', " + g1.Cells[4].Text + "," + false + "," + 0 + ")", con);
                oleDbCmd4.ExecuteNonQuery();
                con.Close();

            }
            //string script = "alert('Steps Copied Successfully In UID !!!')";
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Button2, this.GetType(), "Test", script, true);
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
    }

}
