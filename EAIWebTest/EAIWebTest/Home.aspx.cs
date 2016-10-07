using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;

namespace EAIWebTest
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                string htmlCode = "";
                int pagecount = 0;
                string Weburl = ConfigurationManager.AppSettings["AlexaURL"].ToString();
                List<string> domains = new List<string>();
                string pattern = "\"/siteinfo/.*\"";
                
                while (domains.Count < 97)
                {

                    ///Downloading the Source code
                    using (WebClient client = new WebClient())
                    {

                        htmlCode = client.DownloadString(Weburl);
                    }



                    ///Finding the Domain Names

                    foreach (Match m in Regex.Matches(htmlCode, pattern, RegexOptions.IgnoreCase))
                    {
                        string[] getdomain = m.Value.Split('/');
                        if (getdomain[2] != null)
                        {
                            getdomain[2] = getdomain[2].Trim('"');
                            if (domains.Count < 97)
                            {
                                domains.Add(getdomain[2].ToString());
                            }
                            else {


                                break;
                            }
                        }

                    }

                    ///Navigating to next page
                    if (domains.Count < 97)
                    {
                        pagecount++;
                        Weburl = ConfigurationManager.AppSettings["AlexaURL"].ToString() + "/global;" + pagecount + "";
                    }
                }

                GridDomains.DataSource = ConvertListToDataTable(domains);
                GridDomains.DataBind();
                GridDomains.HeaderRow.Cells[0].Attributes["Width"] = "50px";
               
            }
            catch( Exception ex)
            {
                Response.Write(ex.Message);
            }
            }

        static DataTable ConvertListToDataTable(List<string> list)
        {
            int counter = 1;
      
            DataTable table = new DataTable();

            table.Columns.Add("Rank");
            table.Columns.Add("Domain Name");
            

           
            foreach (var item in list)
            {
                table.Rows.Add(counter, item);
                counter++;
            }

            return table;
        }
    }
}