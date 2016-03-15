using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BrevetResults : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private BrevetRiderDAO brevetRiderDAO = new BrevetRiderDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(false); // true = login is required for accessing this page
        

        if (this.IsPostBack == false)
        {
            PopulateddlDistanceWithValues();
            PopulateddlLocationWithValues();
            PopulateddlYearWithValues();
            createBrevetList(); // Populate Brevet List for the first time
        }
    }

    private void createBrevetList()
    {
        List<Brevet> brevetList = brevetDAO.GetallBrevetsOrderedByDisDateLoc();

        listBoxBrevets.Items.Clear();
        if (brevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        if (brevetList.Count == 0)
        {
            listboxBrevetResults.Items.Add("There are no results for this brevet");
        }
        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance + " " + brevet.Location + ", " + brevet.BrevetDate.ToString("yyyy-MM-dd");

                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listBoxBrevets.Items.Add(listItem);
            }
        }
    }

    private void createBrevetListOnSearchConditions(int distance, string location, int date)
    {
        List<Brevet> brevetList = brevetDAO.GetallBrevetsOrderedBySearchConditions(distance, location, date);

        listboxBrevetResults.Items.Clear();
        if (brevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        if (brevetList.Count == 0)
        {
            listboxBrevetResults.Items.Add("There are no brevets that match your search conditions");
        }
        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance + " " + brevet.Location + ", " + brevet.BrevetDate.ToString("yyyy-MM-dd");

                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listboxBrevetResults.Items.Add(listItem);
            }
        }
    }

    private void CreateBrevetRiderList(Brevet brevet)
    {
        List<BrevetRider> brevetRiderList = brevetRiderDAO.GetRiderListForBrevetListbyBrevetId(brevet.BrevetId);

        listboxBrevetResults.Items.Clear();

        if (brevetRiderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");

        }
      
        else
        {
            foreach (BrevetRider brevetRider in brevetRiderList)
            {
               // TimeSpan finishingTime = brevetRider.FinishingTime(brevetRider.FinishingDate);

                String text = brevetRider.Rider.FamilyName + ", " + brevetRider.Rider.GivenName + " (" + brevetRider.Rider.Club.ClubName + ")"
                    + "completed: " + brevetRider.IsCompleted + " time: " + brevetRider.FinishingTimeAsString;

                ListItem listItem = new ListItem(text, "" + brevetRider.Rider.RiderId);

                listboxBrevetResults.Items.Add(listItem);
            }
        }
    }

    protected void btSearchBrevets_Click(object sender, EventArgs e)
    {
        searchModelToScreen();       
    }

    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = brevetDAO.GetBrevetByBrevetId(brevetId);

        if (brevet != null)
        {
            modelToScreen(brevet);
            
            
        }
    }

    private void searchModelToScreen ()
    {
        String location = null;
        int date = -1;
        int distance = -1;

        if (ddlDistance.SelectedValue != "All")
        {
            distance = Convert.ToInt32(ddlDistance.SelectedValue);
        }
        if (ddlLocation.SelectedValue != "All")
        {
            location = ddlLocation.SelectedValue;
        }
        if (ddlYear.SelectedValue != "All")
        {
            date = Convert.ToInt32(ddlYear.SelectedValue);
        }
        createBrevetListOnSearchConditions(distance, location, date);
    }
    private void modelToScreen(Brevet brevet)
    {
        CreateBrevetRiderList(brevet);
    }
    private void showErrorMessage(String message)
    {
        lbMessage.Text = message;
        lbMessage.ForeColor = System.Drawing.Color.Red;
    }

    private void showNoMessage()
    {
        lbMessage.Text = "";
        lbMessage.ForeColor = System.Drawing.Color.Black;
    }

    private void PopulateddlDistanceWithValues()
    {

        ddlDistance.Items.Clear();
        ddlDistance.Items.Add("All");
        ddlDistance.Items.Add("200");
        ddlDistance.Items.Add("300");
        ddlDistance.Items.Add("400");
        ddlDistance.Items.Add("600");
        ddlDistance.Items.Add("1000");
        ddlDistance.Items.Add("1200");

    }

    private void PopulateddlLocationWithValues()
    {
        List<Brevet> listofbrevetLocations = brevetDAO.GetaDistinctLocation();
        //if we can serach by one value, we need this:
        ddlLocation.Items.Add("All");
        foreach (Brevet brevet in listofbrevetLocations)
        {
            
            String textForLocation = brevet.Location;
            ListItem listItemForLocation = new ListItem(textForLocation);
            

            ddlLocation.Items.Add(listItemForLocation);
           
        }
        
    }
    private void PopulateddlYearWithValues()
    {
        List<Brevet> listofbrevetDates = brevetDAO.GetaDistinctYear();
        //if we can serach by one value, we need this:
        ddlYear.Items.Add("All");

        foreach (Brevet brevet in listofbrevetDates)
        {
            DateTime brevetYear = brevet.BrevetDate;
            String textForYear = brevetYear.ToString("yyyy");
            ListItem listItemForYear = new ListItem(textForYear);
            if (!ddlYear.Items.Contains(listItemForYear))
            {
                ddlYear.Items.Add(listItemForYear);
            }
            
            
        }

    }

   


    /* **********************************************************************
        * LOGIN MANAGEMENT CODE 
        * - This is the special code to be used on your ASPX pages.
        * - DO NOT change anything else but the HyperLink controls here!
        *   HyperLink controls are managed under comments (1), (2), and (3)
        *********************************************************************** */
    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();    // Should disable browser's Back Button

        // (1) Hide all hyperlinks that are available for autenthicated users only
        // (1) Hide all hyperlinks that are available for autenthicated users only
        hyperLinkBrevetManagement.Visible = false;
        hyperLinkRiderManagement.Visible = false;
        hyperLinkClubManagementPage.Visible = false;
        hyperLinkUpdateReusults.Visible = false;
        hyperLinkBrevetRegistration.Visible = false;

        if (loginRequired == true && Session["username"] == null)
        {
            Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
        }

        if (Session["username"] == null)
        {
            lbLoginInfo.Text = "You are not logged in";
            btLogout.Visible = false;
        }

        if (Session["username"] != null)
        {

            lbLoginInfo.Text = "You are logged in as " + Session["username"];
            btLogout.Visible = true;

            // (2) Show all hyperlinks that are available for autenthicated users only
            hyperLinkBrevetRegistration.Visible = true;
        }

        if (Session["administrator"] != null)
        {
            if (Session["administrator"] != null)
            {
                // (3) In addition, show all hyperlinks that are available for administrators only
                hyperLinkBrevetManagement.Visible = true;
                hyperLinkRiderManagement.Visible = true;
                hyperLinkClubManagementPage.Visible = true;
                hyperLinkUpdateReusults.Visible = true;
            }
        }
    }

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("HomePage.aspx");
    }
    /* LOGIN MANAGEMENT code ends here  */



 
}
// End