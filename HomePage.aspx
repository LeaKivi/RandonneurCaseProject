<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>
<link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />

<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>HH Randonneurs</title>

</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Randonnerus</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click">LOGOUT</asp:LinkButton>
                </div>
            </div>



            <div id="div_LEFT">
                <div id="div_NAV">
                    <asp:HyperLink ID="hyperLinkHomePage" runat="server" CssClass="current_page_link" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink><br />
                    <asp:HyperLink ID="hyperLinkRiderList" runat="server" CssClass="other_page_link" NavigateUrl="~/RiderList.aspx">Rider List</asp:HyperLink><br />
                    <asp:HyperLink ID="hyperLinkBrevetResults" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetResults.aspx">Brevet Results</asp:HyperLink><br /><br />

                    <asp:HyperLink ID="hyperLinkBrevetRegistration" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetRegistration.aspx">Brevet Registration</asp:HyperLink><br /><br />

                    <asp:HyperLink ID="hyperLinkBrevetManagement" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetManagement.aspx">Brevet Management</asp:HyperLink><br />
                    <asp:HyperLink ID="hyperLinkRiderManagement" runat="server" CssClass="other_page_link" NavigateUrl="~/RiderManagement.aspx">Rider Management</asp:HyperLink><br />
                    <asp:HyperLink ID="hyperLinkClubManagementPage" runat="server" CssClass="other_page_link" NavigateUrl="~/ClubManagementPage.aspx">Club Management</asp:HyperLink><br /><br />
                    <asp:HyperLink ID="hyperLinkUpdateReusults" runat="server" CssClass="other_page_link" NavigateUrl="~/UpdateResults.aspx">Update Results</asp:HyperLink>
                   
                </div>
            </div>



            <div id="div_CENTER">
                Welcome to HH Randonneurs home page! <br /> <br />
                <img src="images/brevet_rider.png" alt="Brevet Rider" /><br />
                <br /><p>
                HH Randonneurs orginize annual Super <br />
                Randonneur series of 200, 300, 400 and<br /> 
                600km brevets. In addition, we orginize <br />
                1000 and 1200km brevets when possible.
                </p>
                <p>Whichever brevet you choose, we'll make it <br />
                    an unforgettable ride!
                </p>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>



            <div id="div_RIGHT"><p>
                You can view rider lists and brevet results without logging in.<br />
                <br />
                Login is required for brevet registrations.&nbsp;<br />
                Pre-registration for brevets is accepted up to one week before the<br />
                event.<br /> </p>

                <asp:Panel ID="panelLogin" runat="server" GroupingText="Login" CssClass="loginPanel">
                    <asp:Label ID="lbUsername" runat="server" EnableViewState="False" Text="Username:"></asp:Label><br />
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label><br />
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Button ID="btLogin" runat="server" EnableTheming="False" Text="Login" OnClick="btLogin_Click" CssClass="loginButton" />
                </asp:Panel>
                <asp:Label ID="lbMessage" runat="server" CssClass="validatorMessage"></asp:Label><br />
                <p>
                <b>Links</b> <br />
                 <a ID="Wiki_Randonneuring"   href="https://en.wikipedia.org/wiki/Brevet_(cycling)">http://en.wikipedia.org/wiki/Brevet_(cycling)</a> <br />
                <a ID="WikiParisBrestParis"   href="https://en.wikipedia.org/Paris-Brest-Paris">https://en.wikipedia.org/Paris-Brest-Paris</a><br />
                <a ID="randonneursfi"   href="https://www.randonneurs.fi">https://www.randonneurs.fi</a><br />
                <a ID="rusa"   href="http://www.rusa.org">http://www.rusa.org</a><br />
                </p>
            </div>

            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
             
                                      <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

               <div id="div_footer_AUTHOR">
                    Katalina Kivinen 2015 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>