<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GrabbaRide.Frontend.Default" Title="GrabbaRide Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="searchcol">
        <h2>Search rides...</h2>
                    <p>From:&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    To:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<br />
    <br />
    Date:<br />
    <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
        Text="Search Rides" />
    <br />
                    </p>
    </div>
    <div class="centercol">
    <p>put a cool map here</p>
    </div>
</asp:Content>
