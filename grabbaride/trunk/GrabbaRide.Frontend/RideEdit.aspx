<%@ Page Title="GrabbaRide | Edit Ride" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeBehind="RideEdit.aspx.cs" Inherits="GrabbaRide.Frontend.RideEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/ride-edit.png" alt="Edit Ride" class="floatrightimg" />
    <h2>
        Edit Ride</h2>
    <h3>
        Please fill in the new details</h3>
    <table class="user-details-table">
        <tr>
            <th>
                Seats
            </th>
            <td>
                <asp:DropDownList ID="SeatsDropDown" runat="server">
                    <asp:ListItem Value="1" />
                    <asp:ListItem Value="2" />
                    <asp:ListItem Value="3" />
                    <asp:ListItem Value="4" />
                    <asp:ListItem Value="5" />
                    <asp:ListItem Value="6" />
                    <asp:ListItem Value="9" />
                    <asp:ListItem Value="12" />
                </asp:DropDownList>
            </td>
        </tr>
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
                <asp:DropDownList ID="drpdayhalf" runat="server">
                    <asp:ListItem Value="a.m." />
                    <asp:ListItem Value="p.m." />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <th>
                Days
            </th>
            <td>
                <asp:CheckBox ID="chkmon" runat="server" Text="Monday" Checked="true" />
                <br />
                <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" Checked="true" />
                <br />
                <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" Checked="true" />
                <br />
                <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" Checked="true" />
                <br />
                <asp:CheckBox ID="chkfri" runat="server" Text="Friday" Checked="true" />
                <br />
                <asp:CheckBox ID="chksat" runat="server" Text="Saturday" />
                <br />
                <asp:CheckBox ID="chksun" runat="server" Text="Sunday" />
            </td>
        </tr>
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
            <th>
            </th>
            <td>
                <asp:Button ID="UpdateRideButton" runat="server" Text="Update Ride Details" OnClick="UpdateRideButton_Click" />
                <asp:Button ID="DeleteRideButton" runat="server" Text="Delete Ride" 
                    onclick="DeleteRideButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
