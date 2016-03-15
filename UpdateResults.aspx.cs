using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateResults : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private BrevetRiderDAO brevetRiderDAO = new BrevetRiderDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page


        if (this.IsPostBack == false)
        {
            createBrevetList(); // Populate Brevet List for the first time
            PopulateHoursAndMinutesTextBoxes();
            resetScreen();
            
        }
    }
    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {

        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = brevetDAO.GetBrevetByBrevetId(brevetId);

        if (brevet != null)
        {
            modelToScreenBrevet(brevet);

            showNoMessage();
        }
    }

    private void modelToScreenBrevet(Brevet brevet)
    {
        CreateBrevetRiderList(brevet);


    }
    private void resetScreen()
{
    tbBrevetId.Text = "";
    tbRiderId.Text = "";
    calendarCompletionDate.SelectedDates.Clear();
    rbNo.Checked = false;
    rbYes.Checked = true;
        ddlFinishingHour.SelectedValue = "0";
        ddlFinishingMinutes.SelectedValue = "0";
}

    private void modelToScreenBrevetRider(BrevetRider brevetRider, Brevet brevet)
    {
        tbBrevetId.Text = ""+ brevet.BrevetId;
        tbRiderId.Text = "" + brevetRider.Rider.RiderId;
        if (brevetRider.IsCompleted == "Y")
        {
            rbNo.Checked = false;
            rbYes.Checked = true;
        }
        else
        {
            rbNo.Checked = true;
            rbYes.Checked = false;
        }
        
        calendarCompletionDate.VisibleDate = brevet.BrevetDate;
        calendarCompletionDate.SelectedDate = brevet.BrevetDate;
        int hours = brevetRider.FinishingTime.Hours;
        int minutes = brevetRider.FinishingTime.Minutes;
        ddlFinishingHour.SelectedValue = ""+hours;
        ddlFinishingMinutes.SelectedValue = ""+minutes;

    }

    private void CreateBrevetRiderList(Brevet brevet)
    {
        List<BrevetRider> brevetRiderList = brevetRiderDAO.GetRiderListForBrevetListbyBrevetId(brevet.BrevetId);

        listBoxBrevetRiders.Items.Clear();

        if (brevetRiderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");

        }

        else
        {
            foreach (BrevetRider brevetRider in brevetRiderList)
            {
                // TimeSpan finishingTime = brevetRider.FinishingTime(brevetRider.FinishingDate);

                String text = brevetRider.Rider.RiderId + " " + brevetRider.Rider.FamilyName + ", " + brevetRider.Rider.GivenName 
                    + " completed: " + brevetRider.IsCompleted + " time: " + brevetRider.FinishingTime;

                ListItem listItem = new ListItem(text, "" + brevetRider.Rider.RiderId);

                listBoxBrevetRiders.Items.Add(listItem);
            }
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
           listBoxBrevetRiders.Items.Add("There are no results for this brevet");
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

    private void screenToModel ()
    {
        BrevetRiderDAO brevetRiderDAO = new BrevetRiderDAO();
        Brevet brevet = new Brevet();
        BrevetRider brevetRider = new BrevetRider();
        brevetRider.FinishingDate = calendarCompletionDate.SelectedDate;
        if (rbYes.Checked == true)
        { brevetRider.IsCompleted = "Y"; }
        TimeSpan time = TimeSpan.Parse(string.Format("{0}:{1}", ddlFinishingHour.SelectedValue, ddlFinishingMinutes.SelectedValue));
        brevetRider.FinishingTime = time;
        int updateOk = brevetRiderDAO.UpdateBrevetRider(brevetRider);

        if (updateOk == 0) //update ok
        {
            showNoMessage();
        }
        else
        {
            showErrorMessage("DataBase is out of use. No entry was modified.");
        }

    }
    protected void listBoxBrevetRiders_SelectedIndexChanged(object sender, EventArgs e)
    {
        int riderId = Convert.ToInt32(listBoxBrevetRiders.SelectedValue);
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = brevetDAO.GetBrevetByBrevetId(brevetId);
        BrevetRider brevetRider = brevetRiderDAO.GetBrevetRiderByRiderId(riderId);

        if (brevet != null)
        {
            modelToScreenBrevetRider(brevetRider, brevet);

            showNoMessage();
        }
    }

    protected void btSaveResults_Click(object sender, EventArgs e)
    {
        screenToModel();
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        resetScreen();
    }

    protected void PopulateHoursAndMinutesTextBoxes()
    {
        ListItem listItem;
        for (int i = 0; i<10; i++)
        {
            listItem = new ListItem("0" + i, ""+i);
            ddlFinishingHour.Items.Add(listItem);
        }
        for (int i = 10; i < 24; i++)
        {
            listItem = new ListItem(""+i);
            ddlFinishingHour.Items.Add(listItem);
        }
        for (int i = 0; i < 10; i++)
        {
            listItem = new ListItem("0" + i, "" + i);
            ddlFinishingMinutes.Items.Add(listItem);
        }
        for (int i = 10; i < 60; i++)
        {
            listItem = new ListItem("" + i);
            ddlFinishingMinutes.Items.Add(listItem);
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
