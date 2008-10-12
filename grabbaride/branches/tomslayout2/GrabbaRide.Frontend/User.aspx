<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID=HelpContentPlaceHolder runat="server">
          <img alt="" src="themes/blue/help.gif" />&nbsp;&nbsp; You can edit your details 
by clicking the edit button below 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetUserByUsername"
        TypeName="GrabbaRide.Database.GrabbaRideDBDataContext">
        <SelectParameters>
            <asp:QueryStringParameter Name="username" QueryStringField="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ScriptManager ID="UserScriptManager" runat="server">
    </asp:ScriptManager>
    <h3 title="User Profile Page">
        User Page</h3>
            <asp:DetailsView ID="UserDetailsView" runat="server" 
        AutoGenerateRows="False" DataSourceID="UserDataSource"
                AutoGenerateEditButton="True">
                <Fields>
                    <asp:BoundField DataField="Username" HeaderText="User" 
                        SortExpression="Username" ReadOnly="True">
                        <ControlStyle Font-Bold="False" />
                        <ItemStyle Font-Bold="True" Font-Size="Large" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                        SortExpression="LastName" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" 
                        SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="Occupation" HeaderText="Occupation" 
                        SortExpression="Occupation" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="CreationDate" HeaderText="Member Since" 
                        SortExpression="CreationDate" ReadOnly="True" />
                    <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login" 
                        SortExpression="LastLoginDate" ReadOnly="True" />
                    <asp:BoundField DataField="LastActvityDate" HeaderText="Last Seen" 
                        SortExpression="LastActvityDate" ReadOnly="True" />
                    <asp:BoundField DataField="Comment" HeaderText="About Me" 
                        SortExpression="Comment" />
                </Fields>
            </asp:DetailsView>
    <asp:UpdatePanel ID="UserDetailsUpdatePanel" runat="server">
        <ContentTemplate>
            <div>
                Social Score:<br />
                This user&#39;s social score is
                <asp:Label ID="lblScore" runat="server" Text="0"></asp:Label>
                , based on
                <asp:Label ID="lblNoRatings" runat="server" Text="0"></asp:Label>
                &nbsp;ratings<br />
                <div id="rateButtons" runat="server">
                    <asp:ImageButton ID="ibtnRateNeg" runat="server" ImageUrl="~/Images/ratenegative.png"
                        OnClick="ibtnRateNeg_Click" />
                    <asp:ImageButton ID="ibtnRatePos" runat="server" ImageUrl="~/Images/ratepositive.png"
                        OnClick="ibtnRatePos_Click" />
                </div>
                <div id="currentRating" runat="server">
                    You have already rated this user<br />
                    <asp:Image ID="imgRating" runat="server" />
                    <br />
                    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                        Text="Delete this rating" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
