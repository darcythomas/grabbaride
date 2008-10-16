<%@ Page Title="GrabbaRide | Delete Ride" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeBehind="RideDelete.aspx.cs" Inherits="GrabbaRide.Frontend.RideDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/edit-delete.png" alt="Delete Ride" class="floatrightimg" />
    <h2>
        Delete Ride</h2>
    <h3>
        Are you sure you wish to delete this ride?</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="user-details-table">
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
            </th>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="DeleteConfirmNo" runat="server" Text="No, Keep the Ride!" OnClick="DeleteConfirmNo_Click" />
                        <asp:Button ID="DeleteConfirmYes" runat="server" Text="Yes, I'm Sure" OnClick="DeleteConfirmYes_Click" />
                        <asp:Label ID="DeleteSuccessLabel" runat="server" Text="Your ride was deleted successfully!"
                            Visible="false" ForeColor="Green" />
                        <asp:Button ID="DeleteSuccessContinue" runat="server" Text="Continue &#187;" Visible="false"
                            OnClick="DeleteSuccessContinue_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
