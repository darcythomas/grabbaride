<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="GrabbaRide.Frontend.Login" Title="Login to GrabbaRide"  %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <script type="text/javascript">


    
    
            function showHideContent(id, show) {
            var elem = document.getElementById(id);
            if (elem) {
                if (show) {
                    elem.style.display = 'block';
                    elem.style.visibility = 'visible';
                }
                else {
                    elem.style.display = 'none';
                    elem.style.visibility = 'hidden';
                }
            }
        }

        function Radio_NormalLogIn_onclick() {
            document.getElementById("Radio_OpenID").checked = false;
     //       showHideContent("openIDDiv", false);
      //      showHideContent("NormalLogInDiv", true);
            
        }

        function Radio_OpenID_onclick() {
            document.getElementById("Radio_NormalLogIn").checked = false;
       //     showHideContent("openIDDiv", true);
        //    showHideContent("NormalLogInDiv",false);
        }

    </script>

	<style type="text/css">
.style1 {
	font-family: Arial;
	font-size: xx-large;
	color: #000080;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <span class="style1">Login</span><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <br />
	<br />
            <input id="Radio_NormalLogIn"  checked="checked" type="radio"  
                onclick="return Radio_NormalLogIn_onclick()" />
                Log In To GrabbaRide
                <br />
                <input 
                id="Radio_OpenID" type="radio" ; onclick="return Radio_OpenID_onclick()" /> 
	OR...Log In With OpenID<br />
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;<div id="NormalLogInDiv" runat="server" >
                <asp:Login ID="GrabbaRideLogin" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    Font-Size="0.8em" ForeColor="#333333" Style="text-align: center" Width="291px"
                    CreateUserText="Create Account" CreateUserUrl="Register.aspx">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
            </div>
     
              <div id="openIDDiv"  >
                    <br />
                    <RP:OpenIdLogin ID="OpenIdLogin1" runat="server" OnFailed="OpenIdLogin1_Failed" OnCanceled="OpenIdLogin1_Canceled" 
                    OnLoggedIn="OpenIdLogin1_LoggedIn"  OnSetupRequired="OpenIdLogin1_SetupRequired" OnLoggingIn="OpenIDLogin1_LogginIn"
                     RequestBirthDate="Require" RequestEmail="Require" RequestFullName="Require" RequestGender="Require"/>
                    <br />
                    <asp:Label ID="loginFailedLabel" runat="server" EnableViewState="False" Text="Login failed" Visible="False" />
	                <asp:Label ID="loginCanceledLabel" runat="server" EnableViewState="False" Text="Login canceled" Visible="False" />
                    <asp:Label ID="LogginInLable" runat="server" Text="Contacting your OpenID provider...." Visible="False"></asp:Label>
                    <asp:Label ID="LoggedInLabel" runat="server" Text="Login Sucsessful!!" Visible="False"></asp:Label>
                </div>
    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
