<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetUserByUsername"
        TypeName="GrabbaRide.Database.GrabbaRideDBDataContext">
        <SelectParameters>
            <asp:QueryStringParameter Name="username" QueryStringField="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2 title="User Profile Page">
        User Page</h2>
    <asp:UpdatePanel ID="UserDetailsUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:DetailsView ID="UserDetailsView" runat="server" 
    AutoGenerateRows="False" DataSourceID="UserDataSource" 
    AutoGenerateEditButton="True">
                <Fields>
                    <asp:BoundField DataField="Username" HeaderText="Username" 
                SortExpression="Username" >
                        <ControlStyle Font-Bold="False" />
                        <ItemStyle Font-Bold="True" Font-Size="Large" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" 
                SortExpression="DateOfBirth" />
                    <asp:BoundField DataField="Occupation" HeaderText="Occupation" 
                SortExpression="Occupation" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" 
                SortExpression="PasswordQuestion" />
                    <asp:BoundField DataField="PasswordAnswer" HeaderText="PasswordAnswer" 
                SortExpression="PasswordAnswer" />
                    <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" 
                SortExpression="CreationDate" />
                    <asp:BoundField DataField="LastActvityDate" HeaderText="LastActvityDate" 
                SortExpression="LastActvityDate" />
                    <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" 
                SortExpression="LastLoginDate" />
                    <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
                SortExpression="IsApproved" />
                    <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" 
                SortExpression="IsLockedOut" />
                    <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" 
                SortExpression="LastLockoutDate" />
                    <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
                SortExpression="LastPasswordChangedDate" />
                    <asp:BoundField DataField="Comment" HeaderText="Comment" 
                SortExpression="Comment" />
                </Fields>
            </asp:DetailsView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
