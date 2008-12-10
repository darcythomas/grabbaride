<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="GrabbaRide.Frontend.Register" Title="GrabbaRide | Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        Register for GrabbaRide</h2>
    <asp:CreateUserWizard ID="CreateUserWizard" runat="server" UserNameLabelText="Username"
        PasswordLabelText="Password" ConfirmPasswordLabelText="Confirm Password" EmailLabelText="Email"
        QuestionLabelText="Security Question" AnswerLabelText="Answer" DuplicateUserNameErrorMessage="That username is taken!"
        CssClass="register-form" TitleTextStyle-Font-Bold="true" CompleteSuccessText="Your account was created successfully!"
        EmailRegularExpression="^([^ ])+@([^ ])+$" EmailRegularExpressionErrorMessage="Your email address is not valid!">
        <LabelStyle HorizontalAlign="Left" />
        <TitleTextStyle Font-Bold="True"></TitleTextStyle>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" Title="" />
            <asp:CompleteWizardStep runat="server" Title="Complete!" />
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
