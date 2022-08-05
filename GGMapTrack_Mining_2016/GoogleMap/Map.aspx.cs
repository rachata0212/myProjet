using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace GoogleMap
{
    // A sample project by Ghaffar khan

    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.LocationsTableAdapter da = new GoogleMap.DataSet1TableAdapters.LocationsTableAdapter();
            DataSet1.LocationsDataTable table = new DataSet1.LocationsDataTable();
            da.Fill(table);
            BuildScript(table);

        }
        private void BuildScript(DataTable tbl)
        {
            String Locations = "";
            foreach (DataRow r in tbl.Rows)
            {
                // bypass empty rows	 	
                if (r["Latitude"].ToString().Trim().Length == 0)
                    continue;

                string Latitude = r["Latitude"].ToString();
                string Longitude = r["Longitude"].ToString();

                // create a line of JavaScript for marker on map for this record	
                Locations += Environment.NewLine + " map.addOverlay(new GMarker(new GLatLng(" + Latitude + "," + Longitude + ")));";
            }

            // construct the final script
            js.Text = @"<script type='text/javascript'>
                            function initialize() {
                              if (GBrowserIsCompatible()) {
                                var map = new GMap2(document.getElementById('map_canvas'));
                                map.setCenter(new GLatLng(45.05,7.6667), 2); 
                                " + Locations + @"
                                map.setUIToDefault();
                              }
                            }
                            </script> ";
        }       

    }
}
