<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="RideDetails.aspx.cs" Inherits="GrabbaRide.Frontend.RideDetails" Title="GrabbaRide: Ride Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftNavContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="RideInvalidDiv" runat="server" visible="false">
        <asp:Label ID="NoRideIDLabel" runat="server" Text="Error: Invalid ride ID or no ride ID selected!" />
    </div>
    <div id="RideDetailsDiv" runat="server">
        <div id="searchmap" style="width: 400px; height: 400px; float:right;">
        </div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False">
            <Fields>
                <asp:BoundField DataField="RideID" HeaderText="RideID" ReadOnly="True" SortExpression="RideID" />
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" SortExpression="CreationDate" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                <asp:BoundField DataField="NumSeats" HeaderText="NumSeats" SortExpression="NumSeats" />
                <asp:CheckBoxField DataField="RecurMon" HeaderText="RecurMon" SortExpression="RecurMon" />
                <asp:CheckBoxField DataField="RecurTue" HeaderText="RecurTue" SortExpression="RecurTue" />
                <asp:CheckBoxField DataField="RecurWed" HeaderText="RecurWed" SortExpression="RecurWed" />
                <asp:CheckBoxField DataField="RecurThu" HeaderText="RecurThu" SortExpression="RecurThu" />
                <asp:CheckBoxField DataField="RecurFri" HeaderText="RecurFri" SortExpression="RecurFri" />
                <asp:CheckBoxField DataField="RecurSat" HeaderText="RecurSat" SortExpression="RecurSat" />
                <asp:CheckBoxField DataField="RecurSun" HeaderText="RecurSun" SortExpression="RecurSun" />
                <asp:BoundField DataField="LocationFromLat" HeaderText="LocationFromLat" SortExpression="LocationFromLat"
                    Visible="False" />
                <asp:BoundField DataField="LocationFromLong" HeaderText="LocationFromLong" SortExpression="LocationFromLong"
                    Visible="False" />
                <asp:BoundField DataField="LocationToLat" HeaderText="LocationToLat" SortExpression="LocationToLat"
                    Visible="False" />
                <asp:BoundField DataField="LocationToLong" HeaderText="LocationToLong" SortExpression="LocationToLong"
                    Visible="False" />
                <asp:CheckBoxField DataField="Available" HeaderText="Available" SortExpression="Available" />
                <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                <asp:BoundField DataField="JourneyDistance" HeaderText="JourneyDistance" ReadOnly="True"
                    SortExpression="JourneyDistance" />
            </Fields>
        </asp:DetailsView>
        <asp:HiddenField ID="hfstart" runat="server" />
        <asp:HiddenField ID="hfend" runat="server" />
    </div>
</asp:Content>
