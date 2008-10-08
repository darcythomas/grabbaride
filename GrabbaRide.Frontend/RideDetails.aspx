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
        <div id="searchmap" style="width: 400px; height: 400px; float: right;">
        </div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False">
            <Fields>
                <asp:TemplateField HeaderText="User" SortExpression="User">
                    <ItemTemplate>
                        <asp:HyperLink ID="Label1" runat="server" Text='<%# Eval("User.Username") %>' NavigateUrl='<%# String.Format("User.aspx?id={0}", Eval("User.Username")) %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreationDate" HeaderText="Created" SortExpression="CreationDate" />
                <asp:BoundField DataField="StartDate" HeaderText="Available From" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" HeaderText="Available Until" SortExpression="EndDate" />
                <asp:BoundField DataField="NumSeats" HeaderText="Seats" SortExpression="NumSeats" />
                <asp:TemplateField HeaderText="Distance" SortExpression="JourneyDistance">
                    <ItemTemplate>
                        <asp:Label ID="DistanceLabel" runat="server" Text='<%# String.Format("{0:f} km", Eval("JourneyDistanceKm")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="RecurMon" HeaderText="Monday" SortExpression="RecurMon" />
                <asp:CheckBoxField DataField="RecurTue" HeaderText="Tuesday" SortExpression="RecurTue" />
                <asp:CheckBoxField DataField="RecurWed" HeaderText="Wednesday" SortExpression="RecurWed" />
                <asp:CheckBoxField DataField="RecurThu" HeaderText="Thursday" SortExpression="RecurThu" />
                <asp:CheckBoxField DataField="RecurFri" HeaderText="Friday" SortExpression="RecurFri" />
                <asp:CheckBoxField DataField="RecurSat" HeaderText="Saturday" SortExpression="RecurSat" />
                <asp:CheckBoxField DataField="RecurSun" HeaderText="Sunday" SortExpression="RecurSun" />
                <asp:BoundField DataField="Details" HeaderText="More Info" SortExpression="Details" />
            </Fields>
        </asp:DetailsView>
        <asp:ImageButton ID="addToGcalender" runat="server" Style="padding: 5px" ImageUrl="http://www.google.com/calendar/images/ext/gc_button2_en-GB.gif"
            ToolTip="Add to your Google calendar" OnClick="addToGcalender_Click" />
        <div>
            <p>
                Email this user:</p>
            <asp:TextBox ID="EmailMessage" runat="server" Rows="10" Columns="60" TextMode="MultiLine" />
            <asp:Button ID="EmailMessageSend" runat="server" Text="Send!" 
                onclick="EmailMessageSend_Click" />
        </div>
        <asp:HiddenField ID="hfstart" runat="server" OnValueChanged="hfstart_ValueChanged" />
        <asp:HiddenField ID="hfend" runat="server" />
    </div>
</asp:Content>
