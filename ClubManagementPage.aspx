<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClubManagementPage.aspx.cs" Inherits="ClubManagementPage" %>

<!DOCTYPE>

<html>
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />
    <title>Department Management - DWA Model Case</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Club Management</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click"  CausesValidation="False">LOGOUT</asp:LinkButton>
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
                <div class="div_center_HEADER">
                    Clubs
                </div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxClubs" runat="server"   CssClass="listbox_main" AutoPostBack="True" OnSelectedIndexChanged="listBoxClubs_SelectedIndexChanged" Height="258px" Width="286px"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="team_image" src="images/team.png" alt="Club manegement image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Club Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbClubId" runat="server" Text="Club ID:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbClubId" runat="server" CssClass="detail_textbox" MaxLength="4"></asp:TextBox>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbClubName" runat="server" Text="Club Name:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbClubName" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbSCity" runat="server" Text="City:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbCity" runat="server" CssClass="detail_textbox" MaxLength="10"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbDepartmentEmail" runat="server" Text="Email:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbEmail" runat="server" CssClass="detail_textbox" MaxLength="100"></asp:TextBox>

                    </div>
                </div>
                <!-- End of div_right_DETAILS -->


                <div id="div_right_BUTTONS">
                    <asp:Button ID="btNew" runat="server" Text="New"  CausesValidation="False" OnClick="btNew_Click" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btAdd" runat="server" Text="Add"  CausesValidation="True" OnClick="btAdd_Click" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btUpdate" runat="server" Text="Update" CausesValidation="True" OnClick="btUpdate_Click" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btDelete" runat="server" Text="Delete"  CausesValidation="False" OnClick="btDelete_Click" CssClass="div_right_buttons_button" />
                </div>


                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:RangeValidator ID="RangeValidator_Deptno" runat="server"
                        ControlToValidate="tbClubid" ErrorMessage="Club number should be between 50 and 4999"
                        Type="Integer" MinimumValue="50" MaximumValue="4999"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RangeValidator>
                    <br />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server"
                        ControlToValidate="tbEmail" ErrorMessage="Email is not correct"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RegularExpressionValidator>

                </div>
                <!-- End of div_right_VALIDATORS -->
            </div>
            <!-- End of div_RIGHT -->



            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                   Katalina Kivinen 17.11.2015 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
