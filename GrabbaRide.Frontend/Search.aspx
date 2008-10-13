<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.Search" Title="GrabbaRide | Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/system-search.png" alt="Search" class="floatrightimg" />
    <h2>
        Search</h2>
    <div id="SearchResultsDiv" runat="server" visible="false">
        <h3>
            <asp:Label ID="SearchResultsLabel" runat="server">Search results</asp:Label></h3>
        <asp:GridView ID="ResultsGridView" runat="server" AutoGenerateColumns="False" CssClass="recent-rides-grid"
            GridLines="Horizontal">
            <Columns>
                <asp:TemplateField HeaderText="User" SortExpression="UserID">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("User.Username", "UserDetails.aspx?id={0}") %>'
                            runat="server"><%# Eval("User.Username") %></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NumSeats" HeaderText="Seats" SortExpression="NumSeats" />
                <asp:BoundField DataField="DaysAvailable" HeaderText="Days" SortExpression="DaysAvailable" />
                <asp:BoundField DataField="DepartureTimeString" HeaderText="Departing" SortExpression="DepartureTimeString" />
                <asp:BoundField DataField="JourneyDistanceKm" HeaderText="Distance" ReadOnly="True"
                    SortExpression="JourneyDistanceKm" DataFormatString="{0:f2} km" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("RideID", "RideDetails.aspx?id={0}") %>'
                            runat="server">
                    details &#187;
                        </asp:HyperLink>&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <h3>
        <asp:Label ID="SearchDetailsTitle" runat="server">What sort of ride were you looking for?</asp:Label>
    </h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <table class="search-ride-table">
        <tr>
            <th>
                Time
            </th>
            <td>
                <asp:DropDownList ID="drphours" runat="server">
                    <asp:ListItem Value="0" Text="12" />
                    <asp:ListItem Value="1" />
                    <asp:ListItem Value="2" />
                    <asp:ListItem Value="3" />
                    <asp:ListItem Value="4" />
                    <asp:ListItem Value="5" />
                    <asp:ListItem Value="6" />
                    <asp:ListItem Value="7" />
                    <asp:ListItem Value="8" />
                    <asp:ListItem Value="9" Selected="True" />
                    <asp:ListItem Value="10" />
                    <asp:ListItem Value="11" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpmins" runat="server">
                    <asp:ListItem Value="00" />
                    <asp:ListItem Value="05" />
                    <asp:ListItem Value="10" />
                    <asp:ListItem Value="15" />
                    <asp:ListItem Value="20" />
                    <asp:ListItem Value="25" />
                    <asp:ListItem Value="30" />
                    <asp:ListItem Value="35" />
                    <asp:ListItem Value="40" />
                    <asp:ListItem Value="45" />
                    <asp:ListItem Value="50" />
                    <asp:ListItem Value="55" />
                </asp:DropDownList>
                <asp:DropDownList ID="drpampm" runat="server">
                    <asp:ListItem Value="a.m." />
                    <asp:ListItem Value="p.m." />
                </asp:DropDownList>
            </td>
            <th>
                Days
            </th>
            <td>
                <asp:CheckBox ID="chkmon" runat="server" Text="Monday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chkthu" runat="server" Text="Thursday" Font-Names="Arial" />
            </td>
            <td>
                <asp:CheckBox ID="chkfri" runat="server" Text="Friday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chksat" runat="server" Text="Saturday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chksun" runat="server" Text="Sunday" Font-Names="Arial" />
            </td>
        </tr>
    </table>
    <table class="search-ride-table">
        <tr>
            <th>
                Location
            </th>
            <td>
                <div id="gdiv" class="gmap-search-large" runat="server">
                    <table>
                        <tr>
                            <td width="100%">
                                <input id="txtgeo" type="text" name="address" value="Palmerston North" style="width: 100%" />
                            </td>
                            <td>
                                <input id="btnsetstart" type="button" value="Set Start" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'start'); return false" />
                            </td>
                            <td>
                                <input id="btnsetend" type="button" value="Set End" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'end'); return false" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div id="searchmap">
                                </div>
                                <asp:HiddenField ID="hfstart" runat="server" />
                                <asp:HiddenField ID="hfend" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CustomValidator ID="StartEndLocationsValidator" runat="server" ErrorMessage="Please select start and end locations!"
                            OnServerValidate="StartEndLocationsValidator_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Rides &#187;" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
