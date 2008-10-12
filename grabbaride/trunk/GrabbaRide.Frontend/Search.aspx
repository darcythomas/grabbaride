<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm5" Title="GrabbaRide | Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        Search</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="gdiv" style="float: right;" class="gmap-search-large" runat="server">
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
                </td>
            </tr>
        </table>
    </div>
    Time:<br />
    <asp:DropDownList ID="drphours" runat="server">
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
        <asp:ListItem Value="12" />
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
    <asp:DropDownList ID="drpdayhalf" runat="server">
        <asp:ListItem Value="am" Text="a.m." />
        <asp:ListItem Value="pm" Text="p.m." />
    </asp:DropDownList>
    <br />
    On Days:<br />
    <asp:CheckBox ID="chkmon" runat="server" Text="Monday" />
    <br />
    <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" />
    <br />
    <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" />
    <br />
    <asp:CheckBox ID="chkthu" runat="server" Text="Thursday" />
    <br />
    <asp:CheckBox ID="chkfri" runat="server" Text="Friday" />
    <br />
    <asp:CheckBox ID="chksat" runat="server" Text="Saturday" />
    <br />
    <asp:CheckBox ID="chksun" runat="server" Text="Sunday" />
    <br />
    <asp:HiddenField ID="hfstart" runat="server" />
    <asp:HiddenField ID="hfend" runat="server" />
    <br />
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Rides" />
    <br />
    <div id="resultsViewStyle">
        <asp:ListView ID="ResultsListView" runat="server" DataKeyNames="RideID">
            <LayoutTemplate>
                <table runat="server" cellspacing="0">
                    <tr runat="server">
                        <th id="Th1" runat="server">
                            User
                        </th>
                        <th id="Th4" runat="server">
                            Seats
                        </th>
                        <th id="Th2" runat="server">
                            Departing
                        </th>
                        <th runat="server">
                            Mon
                        </th>
                        <th runat="server">
                            Tue
                        </th>
                        <th runat="server">
                            Wed
                        </th>
                        <th runat="server">
                            Thu
                        </th>
                        <th runat="server">
                            Fri
                        </th>
                        <th runat="server">
                            Sat
                        </th>
                        <th runat="server">
                            Sun
                        </th>
                        <th>
                            Details
                        </th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <table runat="server">
                    <tr>
                        <td>
                            No rides found!
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="UserLabel" runat="server" Text='<%# Eval("User.Username") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NumSeatsLabel" runat="server" Text='<%# Eval("NumSeats") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DepartureTimeLabel" runat="server" Text='<%# new DateTime((long)Eval("DepartureTime.Ticks")).ToString("t") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurMonCheckBox" runat="server" Checked='<%# Eval("RecurMon") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurTueCheckBox" runat="server" Checked='<%# Eval("RecurTue") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurWedCheckBox" runat="server" Checked='<%# Eval("RecurWed") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurThuCheckBox" runat="server" Checked='<%# Eval("RecurThu") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurFriCheckBox" runat="server" Checked='<%# Eval("RecurFri") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurSatCheckBox" runat="server" Checked='<%# Eval("RecurSat") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:CheckBox ID="RecurSunCheckBox" runat="server" Checked='<%# Eval("RecurSun") %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <a id="viewdetails1" runat="server" href='<%# String.Format("RideDetails.aspx?id={0}", Eval("RideID")) %>'>
                            details -> </a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
