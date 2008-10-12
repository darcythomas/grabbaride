<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="GrabbaRide.Frontend.Login" Title="GrabbaRide | Login" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID=HelpContentPlaceHolder runat="server">
          <img alt="" src="themes/blue/help.gif" />&nbsp;&nbsp; Login Here
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/login_icon.jpg" alt="Login" style="float: right;" />
    <h3>
        Login</h3>
    <h2>
        Login with your GrabbaRide details</h2>
    <asp:Login ID="GrabbaRideLogin" runat="server" UserNameLabelText="Username"
        CssClass="login-form" UserNameRequiredErrorMessage="You must enter a username!"
        PasswordRequiredErrorMessage="You must enter your password!" PasswordLabelText="Password"
        TitleText="" LoginButtonText="Login &#187;">
        <TitleTextStyle Height="0" BackColor="#507CD1" Font-Bold="True" 
            Font-Size="0.9em" ForeColor="White" />
        <LabelStyle HorizontalAlign="Left" />
    </asp:Login>
    <p>
        Don't have an account? <strong><a href="Register.aspx">Register</a> for GrabbaRide!</strong></p>
    <h2>
        OR... Login with your OpenID!</h2>
    <asp:Panel ID="OpenIDPanel" runat="server">
        <RP:OpenIdLogin ID="OpenIdLogin1" runat="server" OnFailed="OpenIdLogin1_Failed" OnCanceled="OpenIdLogin1_Canceled"
            OnLoggedIn="OpenIdLogin1_LoggedIn" OnSetupRequired="OpenIdLogin1_SetupRequired"
            RequestBirthDate="Require" RequestEmail="Require" RequestFullName="Require" RequestGender="Require"
            LabelText="OpenID" />
        <br />
        <asp:Label ID="loginFailedLabel" runat="server" EnableViewState="False" Text="Login failed"
            Visible="False" />
        <asp:Label ID="loginCanceledLabel" runat="server" EnableViewState="False" Text="Login canceled"
            Visible="False" />
        <asp:Label ID="LogginInLable" runat="server" Text="Contacting your OpenID provider...."
            Visible="False"></asp:Label>
        <asp:Label ID="LoggedInLabel" runat="server" Text="Login Sucsessful!!" Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>
