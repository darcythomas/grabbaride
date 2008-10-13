<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    CodeBehind="UserDetails.aspx.cs" Inherits="GrabbaRide.Frontend.UserDetails" Title="GrabbaRide | User Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/system-users.png" alt="User" class="floatrightimg" />
    <h2 title="User Profile Page">
        User Page</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <label id="InvalidUserLabel" runat="server" visible="false">
    </label>
    <div id="UserDetailsDiv" runat="server">
        <h3>
            <asp:Label ID="UsernameLabel" runat="server" /></h3>
        <table class="user-details-table">
            <tr>
                <th>
                    Name
                </th>
                <td>
                    <asp:Label ID="NameLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Location
                </th>
                <td>
                    <asp:Label ID="LocationLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Occupation
                </th>
                <td>
                    <asp:Label ID="OccupationLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Member Since
                </th>
                <td>
                    <asp:Label ID="MemberSinceLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Last Seen
                </th>
                <td>
                    <asp:Label ID="LastSeenLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    Feedback Rating
                </th>
                <td>
                    <asp:Label ID="RatingLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="PlaceRatingTr" runat="server">
                <th>
                </th>
                <td>
                    <span id="ExistingRatingSpan" runat="server" visible="false">
                        <asp:Label ID="ExistingRatingLabel" runat="server">You rate this user </asp:Label>
                        <asp:Image ID="ExistingRatingPositiveImage" runat="server" ImageUrl="Images/face-smile.png"
                            Visible="false" AlternateText=":-)" ToolTip=":-)" />
                        <asp:Image ID="ExistingRatingNeutralImage" runat="server" ImageUrl="Images/face-plain.png"
                            Visible="false" AlternateText=":-|" ToolTip=":-|" />
                        <asp:Image ID="ExistingRatingNegativeImage" runat="server" ImageUrl="Images/face-sad.png"
                            Visible="false" AlternateText=":-(" ToolTip=":-(" /><br />
                        <asp:Label ID="ChangeRatingLabel" runat="server">Click a face to change your rating:</asp:Label>
                    </span>
                    <asp:Label ID="PlaceRatingLabel" runat="server">Click a face to rate this user:</asp:Label>
                    <asp:ImageButton ID="PlaceRatingPositiveButton" runat="server" ImageUrl="Images/face-smile.png"
                        OnClick="PlaceRatingPositiveButton_Click" AlternateText=":-)" ToolTip=":-)" />&nbsp;
                    <asp:ImageButton ID="PlaceRatingNeutralButton" runat="server" ImageUrl="Images/face-plain.png"
                        OnClick="PlaceRatingNeutralButton_Click" AlternateText=":-|" ToolTip=":-|" />&nbsp;
                    <asp:ImageButton ID="PlaceRatingNegativeButton" runat="server" ImageUrl="Images/face-sad.png"
                        OnClick="PlaceRatingNegativeButton_Click" AlternateText=":-(" ToolTip=":-(" />
                </td>
            </tr>
            <tr>
                <th>
                    About
                </th>
                <td>
                    <asp:Label ID="CommentLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:HyperLink ID="EditUserHyperlink" runat="server" Text="Edit My Details" NavigateUrl="UserEdit.aspx"
                        Visible="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
