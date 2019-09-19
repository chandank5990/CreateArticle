using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

using System.Drawing.Imaging;
using PQScan.PDFToImage;
using Spire.Pdf;
using System.Net;
using System.Net.NetworkInformation;

namespace Points_Pending_Supplier
{
    public partial class Drawing2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Article = Request.QueryString["Article"];
            if (Article.Length > 6)
            {

                string pdfpath = "W:\\test\\Access\\Planos\\" + Article.Substring(0, 6) + "\\" + Article + ".PC" + ".pdf";
                if (File.Exists(pdfpath))
                {
                    PdftoIMG(pdfpath);
                    Image1.ImageUrl = "~/Images/UIDimage/New.jpg";
                }

                else
                {
                    //Iframe.Attributes.Add("src", "Planos/draft.pdf");
                    Image1.ImageUrl = "~/Images/draft.jpg";

                }
            }
        }
 
        void PdftoIMG(string pdfpath)
        {
            Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
            pdfdocument.LoadFromFile(pdfpath);
            System.Drawing.Image image = pdfdocument.SaveAsImage(0, 96, 96);
            image.Save(string.Format(Server.MapPath("~/Images/UIDimage/New.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg));
        }


        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }
    }
}