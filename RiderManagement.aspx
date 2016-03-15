<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiderManagement.aspx.cs" Inherits="RiderManagement" %>

<!DOCTYPE>

<html>
<head id="Head1" runat="server">
    <meta charset="utf-8"/>
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" />
    <title>Rider Management Case Assignment</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Rider Management</h1>
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
                    Riders
                </div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxRiders" runat="server"   CssClass="listbox_main" AutoPostBack="True" OnSelectedIndexChanged="listBoxRiders_SelectedIndexChanged" Height="292px" Width="275px"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="brevetRider_image" src="images/rider.png" alt="Rider management image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Rider Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbRiderId" runat="server" Text="Rider ID:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbRiderId" runat="server" CssClass="detail_textbox" MaxLength="4"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbSurname" runat="server" Text="Surname:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbSurname" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbGivenName" runat="server" Text="Given Name:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbGivenName" runat="server" CssClass="detail_textbox" MaxLength="10"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="Gender" runat="server" Text="Gender:" CssClass="detail_label"></asp:Label>
                        <asp:RadioButton ID="rbFemale"  runat="server" Text="Female" GroupName="gender"  />
                        <asp:RadioButton ID="rbMale"  runat="server" Text="Male" GroupName="gender"  />
                        </div>

                   <div class="div_right_details_ROW">
                        <asp:Label ID="lbPhone" runat="server" Text="Phone:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbPhone" runat="server" CssClass="detail_textbox" MaxLength="100"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbRiderEmail" runat="server" Text="Email:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbRiderEmail" runat="server" CssClass="detail_textbox" MaxLength="100"></asp:TextBox>

                    </div>
                <div class="div_right_details_ROW">
                        <asp:Label ID="lbClubName" runat="server" Text="Club Name:" CssClass="detail_label"></asp:Label>
                        <asp:DropDownList ID="ddlClubName" runat ="server" CssClass="detail_dropdownlist" Height="16px" Width="127px"></asp:DropDownList>
                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbUsername" runat="server" Text="Username:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbUsername" runat="server" CssClass="detail_textbox" MaxLength="100"></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbPassword" runat="server" Text="Password:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="detail_textbox" TextMode="Password" MaxLength="100"  ></asp:TextBox>

                    </div>

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbCheckPassword" runat="server" Text="Re-enter pwd:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbCheckPassword" runat="server" CssClass="detail_textbox" TextMode="Password" MaxLength="100" ></asp:TextBox>

                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbRiderRole" runat="server" Text="Rider role:" CssClass="detail_label"></asp:Label>
                        <asp:RadioButton ID="rbNormalUser"  runat="server" Text="Normal user" GroupName="riderRole"  />
                        <asp:RadioButton ID="rbAdministrator"  runat="server" Text="Administrator" GroupName="riderRole"  />
                        </div>
                </div>


                <!-- End of div_right_DETAILS -->


                <div id="div_right_BUTTONS">
                    <asp:Button ID="btNew" runat="server" Text="New"  CausesValidation="False"  CssClass="div_right_buttons_button" OnClick="btNew_Click" />
                    <asp:Button ID="btAdd" runat="server" Text="Add"  CausesValidation="True" CssClass="div_right_buttons_button" OnClick="btAdd_Click" />
                    <asp:Button ID="btUpdate" runat="server" Text="Update" CausesValidation="True" CssClass="div_right_buttons_button" OnClick="btUpdate_Click" />
                    <asp:Button ID="btDelete" runat="server" Text="Delete"  CausesValidation="False"  CssClass="div_right_buttons_button" OnClick="btDelete_Click" />
                </div>


                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:RangeValidator ID="RangeValidator_Deptno" runat="server"
                        ControlToValidate="tbRiderId" ErrorMessage="Rider id should be between 10 and 99999"
                        Type="Integer" MinimumValue="10" MaximumValue="99999"
                        SetFocusOnError="True" CssClass="validatorMessage">
                    </asp:RangeValidator>
                    <br />

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email" runat="server"
                        ControlToValidate="tbRiderEmail" ErrorMessage="Email is not correct"
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
                UTHOR">
                   Katalina Kivinen 17.11.2015 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
