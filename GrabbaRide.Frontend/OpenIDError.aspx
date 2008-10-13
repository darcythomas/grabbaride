<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableViewState="true"
    CodeBehind="OpenIDError.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDError" Title="GrabbaRide | Error" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="OpenIDErrorDiv" runat="server" visible="false">
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
    openID.<div> 
    </div>
    <br />
   
    <br />
    </div>
    
    <div id="ChangeUserName" runat="server" visible="true">
        What would you like to be known as on this site
        
    </div>
      <asp:Label ID="newUserName" Text="New user name:" Visable= "true" runat="server" />
      <asp:TextBox ID="NewUserNameText" runat="server" Width="131px"></asp:TextBox>
      <asp:Label ID="usernameError" Text="Username is not available" Visible="false" runat="server" />
   
    <br />
   
    <asp:Label ID="FristNameLbl" Text="First Name" Visible="false" runat="server"/>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:TextBox ID="TxtBox_First" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Label ID="LastNameLbl" Text="Last Name" Visible="false" runat="server"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TxtBox_Last" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Label ID="GenderLbl" Text="Gender" Visible="false" runat="server"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="GenderList" runat="server" Visible="false">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
    <br />
      <asp:Label ID="EmailLbl" Text="Email" Visible="false" runat="server" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TxtBox_Email" runat="server" Visible=" false"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="SubmitBttn" runat="server" onclick="SubmitBttn_Click" 
        Text="Submit" />
    <br />
</asp:Content>
