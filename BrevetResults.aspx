<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrevetResults.aspx.cs" Inherits="BrevetResults" %>

<!DOCTYPE">

<html>
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />
    <title>Brevet Results - DWA Model Case</title>
    <style type="text/css">
        .listbox_main {}
        .detail_textbox {}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Brevet&nbsp; Results</h1>
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
                    Select a Brevet</div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxBrevets" runat="server"   CssClass="listbox_main" AutoPostBack="True" Width="283px" Height="286px" OnSelectedIndexChanged="listBoxBrevets_SelectedIndexChanged" ></asp:ListBox>
                </div>

                <div id="div_center_Search">
                    <div class="div_center_details">
                        <asp:Label ID="lbDistance" runat="server" Text="Distance(km)" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlDistance" runat="server" CssClass="detail_textbox"  Width="283px" Height="16px"></asp:DropDownList>
                    </div> 
                    <div class="div_center_details">
                        <asp:Label ID="lbYear" runat="server" Text="Year" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="detail_textbox"  Width="283px" Height="16px"></asp:DropDownList>
                    </div>
                    <div class="div_center_details">
                        <asp:Label ID="lbLocation" runat="server" Text="Location:" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="detail_textbox"  Width="283px"></asp:DropDownList>
                    </div><br />

                <asp:Button ID="btSearchBrevets" runat="server" Text="Search Brevets"  CausesValidation="False"  CssClass="div_right_buttons_button" Width="189px" OnClick="btSearchBrevets_Click" />
                
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Brevet Results 
                    <br />
                    <asp:ListBox ID="listboxBrevetResults" runat="server"   CssClass="listbox_main" Height="448px" Width="448px" ></asp:ListBox>
                </div>

                <!-- End of div_right_DETAILS -->


                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

           
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
