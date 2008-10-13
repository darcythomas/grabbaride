<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    CodeBehind="RideDetails.aspx.cs" Inherits="GrabbaRide.Frontend.RideDetails" Title="GrabbaRide | Ride Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        Ride Details</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="user-details-table">
        <tr>
            <th>
                User
            </th>
            <td>
                <asp:HyperLink ID="UserHyperLink" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <th>
                Created
            </th>
            <td>
                <asp:Label ID="CreatedLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Ad Expires
            </th>
            <td>
                <asp:Label ID="EndDateLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Seats
            </th>
            <td>
                <asp:Label ID="NumSeatsLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Days
            </th>
            <td>
                <asp:Label ID="RecurDaysLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Departing
            </th>
            <td>
                <asp:Label ID="DepartureTimeLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Distance
            </th>
            <td>
                <asp:Label ID="DistanceLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Details
            </th>
            <td>
                <asp:Label ID="RideDetailsLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Location
            </th>
            <td>
                <div id="searchmapread" style="width: 400px; height: 400px;">
                </div>
                <asp:HiddenField ID="hfstart" runat="server" />
                <asp:HiddenField ID="hfend" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                Calendar
            </th>
            <td>
                <asp:ImageButton ID="addToGcalender" runat="server" ImageUrl="http://www.google.com/calendar/images/ext/gc_button2_en-GB.gif"
                    ToolTip="Add ride to your Google Calendar" OnClick="addToGcalender_Click" />
                <asp:Label ID="addedToGcal" runat="server" Visible="false">This ride was successfully added to your Google Calender!</asp:Label>
            </td>
        </tr>
        <tr id="EmailUserRow" runat="server">
            <th>
                Contact
            </th>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="SendEmailDiv" runat="server">
                            Write an email to this user:<br />
                            <asp:TextBox ID="EmailMessage" runat="server" Rows="10" Columns="60" TextMode="MultiLine" />
                            <asp:Button ID="EmailMessageSend" runat="server" Text="Send!" OnClick="EmailMessageSend_Click" />
                        </div>
                        <div id="EmailSentDiv" runat="server" visible="false">
                            <span style="color: Green;">Your email was sent successfully!</span>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <th>
            </th>
            <td>
                <asp:HyperLink ID="EditRideHyperLink" runat="server" Text="Edit Ride Details" Visible="false"></asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
