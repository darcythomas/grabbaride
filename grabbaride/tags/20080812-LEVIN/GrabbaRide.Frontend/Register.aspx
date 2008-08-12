<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm4" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
        Height="319px" Style="text-align: center" Width="363px">
        <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
        <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
        <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
            Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <StepStyle Font-Size="0.8em" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server">
                <ContentTemplate>
                    <table border="0" style="font-family: Verdana; font-size: 100%; height: 319px; width: 363px;">
                        <tr>
                            <td align="center" colspan="2" style="color: White; background-color: #507CD1; font-weight: bold;">
                                Complete
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Your account has been successfully created.
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="ContinueButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                    BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                    Font-Names="Verdana" ForeColor="#284E98" Text="Continue" ValidationGroup="CreateUserWizard1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
