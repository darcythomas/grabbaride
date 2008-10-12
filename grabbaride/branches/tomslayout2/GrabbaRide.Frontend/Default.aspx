<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GrabbaRide.Frontend.Default" Title="GrabbaRide Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID=HelpContentPlaceHolder runat="server">
          <img alt="" src="themes/blue/help.gif" />&nbsp;&nbsp; Grabbaride is a car-pooling website designed to help you save the planet! 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h3>
        Welcome to GrabbaRide!</h3>
    <div>
    <p>
        GrabbaRide allows you to save petrol, money, and time, by sharing rides with 
        others!</p>
    <p>
        To get started: <a href="Search.aspx">search for a ride</a>, or <a href="CreateRide.aspx">
            create a ride of your own</a>.</p>
    </div>
</asp:Content>


