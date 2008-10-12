<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GrabbaRide.Frontend.Default" Title="GrabbaRide | Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        Welcome to GrabbaRide!</h2>
    <p>
        GrabbaRide allows you to save petrol, money, and time, by sharing rides with others!</p>
    <p>
        <strong>To get started</strong>, you can <a href="Search.aspx">search for a ride</a>,
        or <a href="CreateRide.aspx">create a ride</a> of your own!</p>
    <h3>
        Recently Added Rides</h3>
    <asp:ObjectDataSource ID="RecentRidesDataSource" runat="server" SelectMethod="GetRecentlyAddedRides"
        EnableCaching="true" TypeName="GrabbaRide.Database.GrabbaRideDBDataContext" OnObjectDisposing="RecentRidesDataSourceObjectDisposing">
    </asp:ObjectDataSource>
    <asp:GridView ID="RecentRidesGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="RecentRidesDataSource" CssClass="recent-rides-grid" GridLines="Horizontal">
        <Columns>
            <asp:TemplateField HeaderText="User" SortExpression="UserID">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# Eval("User.Username", "User.aspx?id={0}") %>' runat="server"><%# Eval("User.Username") %></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreationDate" HeaderText="Created" SortExpression="CreationDate"
                DataFormatString="{0:ddd h:mm tt}" />
            <asp:BoundField DataField="NumSeats" HeaderText="Seats" SortExpression="NumSeats" />
            <asp:BoundField DataField="DaysAvailable" HeaderText="Days" SortExpression="DaysAvailable" />
            <asp:BoundField DataField="DepartureTimeString" HeaderText="Departing" SortExpression="DepartureTimeString" />
            <asp:BoundField DataField="JourneyDistanceKm" HeaderText="Distance" ReadOnly="True"
                SortExpression="JourneyDistanceKm" DataFormatString="{0:f2} km" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# Eval("RideID", "RideDetails.aspx?id={0}") %>' runat="server">
                    details &#187;
                    </asp:HyperLink>&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
