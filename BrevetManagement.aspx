<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrevetManagement.aspx.cs" Inherits="BrevetManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />
    <title>Brevet Management - DWA Model Case</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Brevet&nbsp; Management</h1>
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
                    Brevets</div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxBrevets" runat="server"   CssClass="listbox_main" AutoPostBack="True" Height="293px" Width="285px" OnSelectedIndexChanged="listBoxBrevets_SelectedIndexChanged" ></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="team_image" src="images/brevet.png" alt="Club manegement image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Brevet Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbBrevetId" runat="server" Text="Brevet ID:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbBrevetId" runat="server" CssClass="detail_textbox"  Width="263px"></asp:TextBox>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbDistance" runat="server" Text="Distance:" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlDistance" runat="server" CssClass="detail_textbox"  Height="16px" Width="268px"></asp:DropDownList>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbSDate" runat="server" Text="Date:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbDate" runat="server" CssClass="detail_textbox" MaxLength="10" Width="263px"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbLocation" runat="server" Text="Location:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbLocation" runat="server" CssClass="detail_textbox" MaxLength="100" Width="263px"></asp:TextBox>

                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbClimbing" runat="server" Text="Climbing(m):" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbClimbing" runat="server" CssClass="detail_textbox" MaxLength="100" Width="263px"></asp:TextBox>

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

                    <asp:RangeValidator ID="RangeValidator_BrevetId" runat="server"
                        ControlToValidate="tbBrevetid" ErrorMessage="Brevet id should be between 1 and 9999"
                        Type="Integer" MinimumValue="1" MaximumValue="9999"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RangeValidator>
                    <br />

                    <asp:RegularExpressionValidator ID="DateValidator_Date" runat="server"
                        ControlToValidate="tbDate" ErrorMessage="Date should be in following format: yyyy-mm-dd"
                        ValidationExpression="^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RegularExpressionValidator>
                <%--    <br />
                    <asp:RegularExpressionValidator ID="DistanceValidator_Distance" runat="server"
                        ControlToValidate="tbDistance" ErrorMessage="You can input only 200, 300, 400, 600, 1000 or 1200"
                        ValidationExpression="^(+([200]|[300]|[400]|[600]|[1000]|[1200]))$"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RegularExpressionValidator>--%>
                    <br />
                    <asp:RangeValidator ID="RangeValidator_climbing" runat="server"
                        ControlToValidate="tbClimbing" ErrorMessage="Climbing should be between 0 and 99999"
                        Type="Integer" MinimumValue="0" MaximumValue="99999"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RangeValidator>
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
