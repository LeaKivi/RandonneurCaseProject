﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BrevetRegistration : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private BrevetRiderDAO brevetRiderDAO = new BrevetRiderDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            createBrevetList(); // Populate Club List for the first time
        }
        viewStateDetailsDisplayed();
        addButtonScripts();
    }

    private void addButtonScripts()
    {
        btRegistration.Attributes.Add("onclick",
          "return confirm('Are you sure you want to register for this brevet?');");
    }

    private void createBrevetList()
    {
        List<Brevet> brevetList = brevetDAO.GetallBrevetsOrderedByDisDateLoc();

        listBoxBrevets.Items.Clear();
        if (brevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Location + ", " + brevet.BrevetDate.ToString("yyyy-MM-dd");

                ListItem listItem = new ListItem(text, "" + brevet.BrevetId);
                listBoxBrevets.Items.Add(listItem);
            }
        }
    }
    protected void btRegistration_Click(object sender, EventArgs e)
    {
        BrevetRider brevetRider = new BrevetRider();
        String username = ""+Session["username"];
        RiderDAO riderDAO = new RiderDAO();
        
        brevetRider.Rider = riderDAO.FindRiderByUserName(username);
        brevetRider.Brevet = brevetDAO.GetBrevetByBrevetId(Convert.ToInt32(listBoxBrevets.SelectedValue)); 
        int insertOk = brevetRiderDAO.InsertBrevetRider(brevetRider); 

        if (insertOk == 0)// Insert succeeded
        {
            createBrevetList();
            listBoxBrevets.SelectedValue = brevetRider.Brevet.BrevetId.ToString();
            viewStateDetailsDisplayed();
            lbMessage.Text = "You have succesfully registered for this brevet!";

        }
        else if (insertOk == 1)
        {
            showErrorMessage("You have already registered for this brevet.");
           
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }


    }

    private void modelToScreen(Brevet brevet)
    {

        tbClimbing.Text = "" + brevet.Climbing;
        tbDate.Text = brevet.BrevetDate.ToString("yyyy-MM-dd");
        tbLocation.Text = brevet.Location;
        tbDistance.Text = "" + brevet.Distance;

    }



    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);
        Brevet brevet = brevetDAO.GetBrevetByBrevetId(brevetId);

        if (brevet != null)
        {
            modelToScreen(brevet);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }

    private void viewStateDetailsDisplayed()
    {
        if (listBoxBrevets.SelectedValue != null)
        {
            btRegistration.Enabled = true;
        }
        else
        {
            btRegistration.Enabled = false;
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