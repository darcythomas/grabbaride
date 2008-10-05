<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="OpenIDError.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDError" Title="Login to GrabbaRide" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    Opps. It seems either you have refused, or your provider doesnt support, attribute
    exchange.
    <br />
    To allow you to log on using your openID, we need to know a few things about you.
    Dont<br />
    worry, we are very trustworthy!
    <br />
    <br />
    Promis!!<br />
    <br />
    Ok so just fill in this form, and then you will be able to log in to grabbaride
    using your
    <br />
    openID.<br />
   
    <br />
    <asp:Label ID="FristNameLbl" Text="First Name" Visible="false" runat="server"/>
    
    <asp:TextBox ID="TxtBox_First" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Label ID="LastNameLbl" Text="Last Name" Visible="false" runat="server"/>
    <asp:TextBox ID="TxtBox_Last" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Label ID="GenderLbl" Text="Gender" Visible="false" runat="server"/>
    <asp:DropDownList ID="GenderList" runat="server" Visible="false">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
    <br />
      <asp:Label ID="EmailLbl" Text="Email" Visible="false" runat="server" />
    <asp:TextBox ID="TxtBox_Email" runat="server" Visible=" false"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="SubmitBttn" runat="server" onclick="SubmitBttn_Click" 
        Text="Submit" />
    <br />
</asp:Content>
