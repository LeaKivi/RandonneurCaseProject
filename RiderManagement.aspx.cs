/* **************************************************************************
 * RiderManagement.cs  Original version: Kari Silpiö 18.3.2014 v1.0
 *                              Modified by     : Katalina Kivinen 21.11.2015- 
 * -------------------------------------------------------------------------
 *  Application: DWA Randonneur Case
 *  Class:       Code-behind class for RiderManagement.aspx
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RiderManagement : System.Web.UI.Page
{
    private RiderDAO riderDAO = new RiderDAO();

    protected void Page_Load(object sender, EventArgs e)
    {

        checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            viewStateNew();
            createRiderList(); // Populate Club List for the first time
        }

        addButtonScripts();
    }



    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
    }
    private void createRiderList()
    {
        List<Rider> riderList = riderDAO.GetAllRidersOrderedByName();

        listBoxRiders.Items.Clear();
        if (riderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Rider rider in riderList)
            {
                String text = rider.GivenName + " " + rider.FamilyName + ", " + rider.RiderId;

                ListItem listItem = new ListItem(text, "" + rider.RiderId);
                listBoxRiders.Items.Add(listItem);
            }
        }
    }
    protected void listBoxRiders_SelectedIndexChanged(object sender, EventArgs e)
    {
        int riderId = Convert.ToInt32(listBoxRiders.SelectedValue);
        Rider rider = riderDAO.GetRiderByRiderId(riderId);

        if (rider != null)
        {
            modelToScreen(rider);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }
    protected void btNew_Click(object sender, EventArgs e)
    {
        viewStateNew();
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        Rider rider = screenToModel();
        int insertOk = riderDAO.InsertRider(rider);

        if (insertOk == 0)// Insert succeeded
        {
            createRiderList();
            listBoxRiders.SelectedValue = rider.RiderId.ToString();
            ddlClubName.SelectedValue = rider.Club.Clubno.ToString();
            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage("Rider id " + rider.RiderId + " is already in use. No record insered into the datebase.");
            tbRiderId.Focus();
        }
        else if (insertOk == 2)
        {
            showErrorMessage("username is already in use. No record insered into the datebase.");
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }
    protected void btUpdate_Click(object sender, EventArgs e)
    {
       
            //need to ad: if password was changed, need to reenter it! how? 
            Rider rider = screenToModel();
            if (rider != null)
            {
                int updateOk = riderDAO.UpdateRider(rider);

                if (updateOk == 0) // Update succeeded
                {
                    String selectedValue = listBoxRiders.SelectedValue;

                    createRiderList();
                    viewStateNew();
                    showNoMessage();
                }

                else
                {
                    showErrorMessage("No record updated. " +
                      "THE DATABASE IS TEMPORARILY OUT OF USE.");
                }
            }
        
        else
        {
            showErrorMessage("Passwords do not match");
        }

    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        int riderId = Convert.ToInt32(listBoxRiders.SelectedValue);
        int deleteOk = riderDAO.DeteleRider(riderId);

        if (deleteOk == 0) // Delete succeeded
        {
            createRiderList();
            viewStateNew();
            showNoMessage();
        }
        else if (deleteOk == 1)
        {
            showErrorMessage("No record deleted. " +
              "Please delete the brevet riders first.");
        }
        else
        {
            showErrorMessage("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    private void modelToScreen(Rider rider)
    {
        tbRiderId.Text = "" + rider.RiderId;
        tbGivenName.Text = rider.GivenName;
        tbSurname.Text = rider.FamilyName;
        tbRiderEmail.Text = rider.RiderEmail;
        tbPhone.Text = rider.Phone;
        tbUsername.Text = rider.Username;
        tbPassword.Text = rider.Password;
        tbCheckPassword.Text = rider.Password;
        //tbCheckPassword.Enabled = false;
        ddlClubName.SelectedValue = rider.Club.Clubno.ToString();

        if (rider.Gender == "F")
        {
            rbFemale.Checked = true;
            rbMale.Checked = false;
        }
        else
        {
            rbMale.Checked = true;
            rbFemale.Checked = false;
        }
        if (rider.Role == "admin")
        {
            rbAdministrator.Checked = true;
            rbNormalUser.Checked = false;
        }
        else if (rider.Role == "user")
        {
            rbNormalUser.Checked = true;
            rbAdministrator.Checked = false;
        }

    }

    private void populateDDLClubsWithAllValues()
    {
        ddlClubName.Items.Clear();

        ClubDAO clubDAO = new ClubDAO();
        List<Club> clubList = clubDAO.GetAllClubsOrderedByName();

        foreach (Club club in clubList )
        {
            ListItem listItem = new ListItem(club.ClubName,""+ club.Clubno);
            
            ddlClubName.Items.Add(listItem);
        }

    }

    private void resetForm()
    {
        tbRiderId.Text = "";
        tbGivenName.Text = "";
        tbSurname.Text = "";
        tbRiderEmail.Text = "";
        tbPhone.Text = "";
        tbUsername.Text = "";
        tbPassword.Text = "";
        tbCheckPassword.Text = "";
        
        rbFemale.Checked = false;
        rbMale.Checked = false;
        rbAdministrator.Checked = false;
        rbNormalUser.Checked = false;
    }

    private Rider screenToModel()
    {
       Rider rider = new Rider();

        rider.RiderId = Convert.ToInt32(tbRiderId.Text.Trim());
        rider.GivenName = tbGivenName.Text.Trim();
        rider.FamilyName = tbSurname.Text.Trim();
        rider.RiderEmail = tbRiderEmail.Text.Trim();
        rider.Phone = tbPhone.Text.Trim();
        rider.Username = tbUsername.Text.Trim();
        rider.Password = tbPassword.Text.Trim();
        rider.Club.Clubno = Convert.ToInt32(ddlClubName.SelectedItem.Value);

       
        if (rbFemale.Checked == true)
        {
            rider.Gender = "F";
        }
        if (rbMale.Checked == true)
        {
            rider.Gender = "M";
        }
        if (rbAdministrator.Checked == true)
        {
            rider.Role = "admin";
        }
        if (rbNormalUser.Checked == true)
        {
            rider.Role = "user";
        }
        if (tbCheckPassword.Text == tbPassword.Text)
        {
            return rider;
        }
        else
        {
            showErrorMessage("Passwords don't match");
            tbCheckPassword.Focus();
            return null;
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

    private void viewStateDetailsDisplayed()
    {
        tbRiderId.Enabled = false;
       
        btAdd.Enabled = false;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }
    private void viewStateNew()
    {
        tbRiderId.Enabled = true;
        tbRiderId.Focus();

        populateDDLClubsWithAllValues();

        tbCheckPassword.Enabled = true;
        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;

        resetForm();
        listBoxRiders.SelectedIndex = -1;
        showNoMessage();
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


    //protected void tbPassword_TextChanged(object sender, EventArgs e)
    //{
    //    tbCheckPassword.Enabled = true;
    //}
}
// End