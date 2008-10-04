<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GrabbaRide.Frontend.Default" Title="GrabbaRide Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<style type="text/css">
.style1 {
	font-family: Arial;
}
.style2 {
	font-size: small;
}
.style3 {
	text-align: left;
}
.style4 {
	font-size: small;
	text-align: left;
}
.style5 {
	font-size: xx-large;
	text-align: left;
	color: #000080;
}
.style6 {
	color: #000000;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
	<h2 class="style5">
        <span class="style1">Welcome to GrabbaRide!</h2>
    <p class="style4">
        GrabbaRide allows you to save petrol, money, and time, by sharing rides with others!</p>
    <p class="style3">
        <span class="style2">To get started: </span> <a href="Search.aspx">
		<span class="style2">search for a ride</span></a><span class="style2"><span class="style6">,</span> or
		</span> <a href="CreateRide.aspx">
            <span class="style2">create a ride of your own</span></a><span class="style2">.</span></span></p>
</asp:Content>
