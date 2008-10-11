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
    <p>
        <strong>Recently Added Rides:</strong></p>
    <asp:ObjectDataSource ID="RecentRidesDataSource" runat="server" SelectMethod="GetRecentlyAddedRides"
        EnableCaching="true" TypeName="GrabbaRide.Database.GrabbaRideDBDataContext" OnObjectDisposing="RecentRidesDataSourceObjectDisposing">
    </asp:ObjectDataSource>
    <asp:GridView ID="RecentRidesGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="RecentRidesDataSource">
        <Columns>
            <asp:TemplateField HeaderText="User" SortExpression="UserID">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# String.Format("User.aspx?id={0}", Eval("User.Username")) %>'
                        runat="server"><%# Eval("User.Username") %></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreationDate" HeaderText="Created" SortExpression="CreationDate" DataFormatString="{0:ddd h:mm tt}" />
            <asp:BoundField DataField="NumSeats" HeaderText="Seats" SortExpression="NumSeats" />
            <asp:CheckBoxField DataField="RecurMon" HeaderText="Mon" SortExpression="RecurMon" />
            <asp:CheckBoxField DataField="RecurTue" HeaderText="Tue" SortExpression="RecurTue" />
            <asp:CheckBoxField DataField="RecurWed" HeaderText="Wed" SortExpression="RecurWed" />
            <asp:CheckBoxField DataField="RecurThu" HeaderText="Thu" SortExpression="RecurThu" />
            <asp:CheckBoxField DataField="RecurFri" HeaderText="Fri" SortExpression="RecurFri" />
            <asp:CheckBoxField DataField="RecurSat" HeaderText="Sat" SortExpression="RecurSat" />
            <asp:CheckBoxField DataField="RecurSun" HeaderText="Sun" SortExpression="RecurSun" />
            <asp:BoundField DataField="DepartureTime" HeaderText="Departing" SortExpression="DepartureTime" />
            <asp:BoundField DataField="JourneyDistanceKm" HeaderText="Distance" ReadOnly="True"
                SortExpression="JourneyDistanceKm" DataFormatString="{0:f2} km" />
        </Columns>
    </asp:GridView>
</asp:Content>
