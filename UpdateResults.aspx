<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateResults.aspx.cs" Inherits="UpdateResults" %>

<!DOCTYPE>

<html>
<head id="Head2" runat="server">
    <meta charset="utf-8"/>
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />
    <title>Brevet Registration - DWA Model Case</title>
    <style type="text/css">
        .listbox_main {
            margin-left: 0px;
            margin-top: 0px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Update Results</h1>
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
                    <asp:ListBox ID="listBoxBrevets" runat="server"   CssClass="listbox_main" AutoPostBack="True" Height="226px" Width="286px" OnSelectedIndexChanged="listBoxBrevets_SelectedIndexChanged" ></asp:ListBox>
                </div>
                <div class="div_center_HEADER">
                    Select a Brevet Rider</div>
                <div id="div_Center_SecondList">
                    <asp:ListBox ID="listBoxBrevetRiders" runat="server"   CssClass="listbox_main" AutoPostBack="True" Height="226px" Width="286px" OnSelectedIndexChanged="listBoxBrevetRiders_SelectedIndexChanged" ></asp:ListBox>
                &nbsp;</div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Brevet Rider Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbRiderId" runat="server" Text="RiderId:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbRiderId" runat="server" CssClass="detail_textbox" MaxLength="50" Height="16px" Width="268px" ReadOnly="True"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lSBrevetId" runat="server" Text="BrevetId:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbBrevetId" runat="server" CssClass="detail_textbox" MaxLength="10" Width="263px" ReadOnly="True"></asp:TextBox>

                    </div>

                  <div class="div_right_details_ROW">
                        <asp:Label ID="Completion" runat="server" Text="Completion Status:" CssClass="detail_label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rbNo"  runat="server" Text="No" GroupName="completion"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="rbYes"  runat="server" Text="Yes" GroupName="completion"  />
                        
                        </div>
                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbCompletionDate" runat="server" Text="Completion Date:" CssClass="detail_label"></asp:Label>
                        <asp:Calendar ID="calendarCompletionDate" runat="server" Height="78px" Width="181px"></asp:Calendar>
                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbFinishingTime" runat="server" Text="Finishing time:" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlFinishingHour" runat ="server" CssClass="detail_dropdownlist" Width="42px"></asp:DropDownList> :
                           <asp:DropDownList ID="ddlFinishingMinutes" runat ="server" CssClass="detail_dropdownlist" Width="48px"></asp:DropDownList>
                    </div>
                </div>
                <!-- End of div_right_DETAILS -->


                <div id="div_right_BUTTONS">
                    <asp:Button ID="btSaveResults" runat="server" Text="Save Results" Height="21px" style="margin-left: 0px" Width="117px" OnClick="btSaveResults_Click" />
                    <asp:Button ID="btCancel" runat="server" Text="Cancel" Height="22px" style="margin-left: 32px" Width="103px" OnClick="btCancel_Click" />
                </div>

                <br />
                <br /><
                <br />
                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

           
                </div>
                <!-- End of div_right_VALIDATORS -->
                <br />
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
