<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="GrabbaRide.Frontend.Login" Title="Login to GrabbaRide" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: Arial;
            font-size: xx-large;
            color: #000080;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <span class="style1">Login </span>
    <br />
    <p>
        <strong>Login with your GrabbaRide details</strong></p>
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
    <p>
        <strong>OR... Login with your OpenID details!</strong></p>
    <asp:Panel ID="OpenIDPanel" runat="server">
        <RP:OpenIdLogin ID="OpenIdLogin1" runat="server" OnFailed="OpenIdLogin1_Failed" OnCanceled="OpenIdLogin1_Canceled"
            OnLoggedIn="OpenIdLogin1_LoggedIn" OnSetupRequired="OpenIdLogin1_SetupRequired"
            RequestBirthDate="Require" RequestEmail="Require" RequestFullName="Require" RequestGender="Require" LabelText="OpenID:" />
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
