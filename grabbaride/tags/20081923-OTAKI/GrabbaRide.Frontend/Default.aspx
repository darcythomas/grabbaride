<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GrabbaRide.Frontend.Default" Title="GrabbaRide Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2 style="color: #00cc00">
        Welcome to GrabbaRide!</h2>
    <p>
        GrabbaRide allows you to save petrol, money, and time, by sharing rides with others!</p>
    <p>
        To get started: <a href="Search.aspx">search for a ride</a>, or <a href="CreateRide.aspx">
            create a ride of your own</a>.</p>
</asp:Content>
