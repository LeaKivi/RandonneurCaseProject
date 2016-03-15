using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RiderManagement : System.Web.UI.Page
{

    private BrevetDAO brevetDAO = new BrevetDAO();
    private BrevetRiderDAO brevetriderDAO = new BrevetRiderDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(false); // false = login is not required for accessing this page

        if (this.IsPostBack == false)
        {
            CreateBrevetList(); //populate brevet list for the 1st time
        }
    }

    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = brevetDAO.GetBrevetByBrevetId(brevetId);

        if (brevet != null)
        {
            modelToScreen(brevet);
            
            showNoMessage();
        }

        
    }

    private void modelToScreen(Brevet brevet)
    {
        CreateBrevetRiderList(brevet);
    }

    private void CreateBrevetList()
    {
        List<Brevet> brevetList = brevetDAO.GetallBrevetsOrderedByDisDateLoc(); 

        listBoxBrevets.Items.Clear();

        if(brevetList == null)
        {
           showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");

        }

        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance + " km: " + brevet.BrevetDate.ToString("yyyy-MM-dd") + ", " + brevet.Location;

                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listBoxBrevets.Items.Add(listItem);
            }
        }

    }

    private void CreateBrevetRiderList(Brevet brevet)
    {
        List <BrevetRider> brevetRiderList = brevetriderDAO.GetRiderListForRiderListbyBrevetId(brevet.BrevetId);

        listBoxBrevetRiders.Items.Clear();

        if(brevetRiderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");

        }
        else if(brevetRiderList.Count == 0)
            {
                listBoxBrevetRiders.Items.Add("No riders registered for this brevet yet");
            }
        else
        {
            foreach (BrevetRider brevetRider in brevetRiderList)
            {
                String text = brevetRider.Rider.FamilyName + ", " + brevetRider.Rider.GivenName + " (" + brevetRider.Rider.Club.ClubName + ")";

                ListItem listItem = new ListItem(text, "" + brevetRider.Rider.RiderId);

                listBoxBrevetRiders.Items.Add(listItem);
            }
        }
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

