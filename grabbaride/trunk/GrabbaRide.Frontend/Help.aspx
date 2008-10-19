<%@ Page Title="GrabbaRide | Help" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="GrabbaRide.Frontend.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<style type="text/css">
	.style1 {
		text-align: justify;
	}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        GrabbaRide Help</h2>
    <h3>
        <a id="search"></a>Searching for rides</h3>
    <p class="style1">
        Both registered and non-registered users can search for rides offered by other registered users. However, only registered users are permitted to view ride details or user details. This is to prevent spam and to safeguard the information from malicious people. 
		The details and pricing of the rides are up to the involved parties to discuss on. GrabbaRide does not get involved in the process of accepting/approving rides. This is to ensure the freedom and flexibility of user control.<br><br>
		To search for a ride:<br><br> &nbsp;&nbsp;&nbsp; 1) Select time<br> &nbsp;&nbsp;&nbsp; 2) Select day(s)<br> &nbsp;&nbsp;&nbsp; 3) Specific journey, by selecting starting point and ending point, on Google map<br><br>
		If any of the available rides match the search criteria, a list of the matching rides will be displayed for user to view. The user can then click on the ride “details” to view a more in depth description of the ride.
		If no matching rides are found, the search will return a “no rides found!” message. Users are then given the option to search again or create a ride.
	</p>
    <h3>
        <a id="createride"></a>Creating rides</h3>
    <p class="style1">
        This page allows registered users to a create ride. The rides created are available for both registered and non-registered users to view in search results and on the home page. However, only registered users are permitted to view the ride details.<br><br>
		To create a ride:<br><br> &nbsp;&nbsp;&nbsp; 1) Specify the journey, by selecting start and end points on a Google Map<br> &nbsp;&nbsp;&nbsp; 2) Select total number of seats available<br> &nbsp;&nbsp;&nbsp; 3) Select time and day(s) of ride(s)<br> &nbsp;&nbsp;&nbsp; 4) Select when the listing should become available and how long should the advertisement run for<br>
		&nbsp;&nbsp;&nbsp;
		5) Enter any additional information required, e.g. cost of the ride, exchange conditions, etc.<br><br>
		On successful creation of the ride(s), the user is redirected to the search page. Here, the user can view all rides that match the criteria of the ride that they have created. This allows them to see if there are already any rides similar to theirs that they may not have known about. 
		In addition, the user can edit the ride details, or delete the ride completely.
	</p>
    <h3>
        <a id="editride"></a>Editing rides</h3>
    <p class="style1">
        Users can edit the ride(s) they have created at the end of ride creation, when they are redirected to the search page, they can view and edit their ride details 
		here. Otherwise, the user can edit/delete their created rides in their profile page. In the profile page they can view/edit their personal details, as well as, 
		edit/delete existing rides.  
    </p>
    <h3>
        <a id="editprofile"></a>Editing your details</h3>
    <p class="style1">
    	In the profile page, registered users can view and edit their account details. This is essentially a record of who the user is to the team at GrabbaRide, and to other users who may wish to browse their details before choosing to accept a ride with them.<br>
		<br>The following information is held by GrabbaRide:<br>
		<br>&nbsp;&nbsp;&nbsp; - Name<br>&nbsp;&nbsp;&nbsp; - Location<br>&nbsp;&nbsp;&nbsp; - Occupation<br>&nbsp;&nbsp;&nbsp; - Member Since<br>&nbsp;&nbsp;&nbsp; - Last Seen<br>&nbsp;&nbsp;&nbsp; - Feedback Rating<br>&nbsp;&nbsp;&nbsp; - About<br>
		<br>The following are information available for the user to update:<br>
		<br>&nbsp;&nbsp;&nbsp; - Email<br>&nbsp;&nbsp;&nbsp; - First Name<br>&nbsp;&nbsp;&nbsp; - Last Name<br>&nbsp;&nbsp;&nbsp; - Occupation<br>&nbsp;&nbsp;&nbsp; - Location<br>&nbsp;&nbsp;&nbsp; - About Me<br>
		<br>In addition to displaying user details, there is also a feedback rating in the profile page. The feedback system is based on users rating each other, upon receiving/giving the ride(s) to other users.<br>
		<br>This social score assist users in making the decision, whether to accept/approve the ride or not, based on other users’ feedback ratings. This gives a sense of security and safety for all users, and gives them some ground on which to judge the safety of rides/passengers.<br>
		<br>Each user may rate each other user once, so a network of trust may be built up between friends, and people who have shared rides with each other.<br>
		<br>Finally, the profile page displays a list of creates that have been created by the user, if any. The user may like to review or confirm ride details, as well as edit ride fields when the situation changes.&nbsp;&nbsp;&nbsp;&nbsp; 
	</p>
    <h3>
        <a id="register"></a>Registering for GrabbaRide</h3>
    <p class="style1">
        The registration page is for non-registered users to sign up for an account with GrabbaRide so they can enjoy the services we provide. Registration is open to all members of the public.<br><br> To sign up for an account, the following details are required from the user:<br><br>
		&nbsp;&nbsp;&nbsp;
		1) Username<br> &nbsp;&nbsp;&nbsp; 2) Password<br> &nbsp;&nbsp;&nbsp; 3) Confirm password<br> &nbsp;&nbsp;&nbsp; 4) Email<br> &nbsp;&nbsp;&nbsp; 5) Security Question<br> &nbsp;&nbsp;&nbsp; 6) Security Answer<br><br>
		After creating an account with GrabbaRide, a confirmation message is displayed, informing the user that their registration is complete. From here, the user can click the “Continue” button to be taken to their profile page. The profile page displays and confirms the information they have provided during the registration process. 
		<br><br><strong>Note:</strong> Users cannot register more than one account with GrabbaRide using the same email address. 
	</p>
    <h3>
        <a id="openid"></a>Using OpenID</h3>
    <p class="style1">
        Users can log onto GrabbaRide by either using their GrabbaRide account or by using their OpenID account. This is an extra feature we have designed to allow users to log in using multiple authentication methods. This also allows GrabbaRide to integrate with other services that use OpenID, as well as the default Windows Forms Authentication which is handy for organisations such as Massey.<br><br>
		Users may create an account with GrabbaRide and/or OpenID at any given time.<br><br> 
		We support the decline of attribute exchange (when the OpenID provider will not give us all details about the user), but do require that if this is the case that the user needs to provide us with basic information such as their contact information. All new users logging in via OpenID must register a valid GrabbaRide user name. This user name is used by the database to identify the OpenID user, and the user isn’t required to remember this name. Like normal usernames, this username cannot be modified by the user after the account is created.
</p>
    <h3>
        <a id="safety"></a>Staying safe</h3>
    <p class="style1">
     	GrabbaRide is committed in keeping users and members of the public safe. Our safety measures includes users having to registered with GrabbaRide before they can view ride 
		details or/and to create rides. Upon receiving/giving rides to other registered 
		users, there is a feedback rating which 
        users rate each other, based on their satisfaction with the rides they have 
		received/given. <br><br> 
		The three possible feedback ratings are:<br><br> &nbsp;&nbsp;&nbsp; :) 	Good <br> &nbsp;&nbsp;&nbsp; 
		:| 	Average<br> &nbsp;&nbsp;&nbsp; :( 	Bad<br><br>
		This social score is design to help inform users of the good and bad users out there. Upon reading the user’s feedback ratings, it is up to the individuals to decide on whether to accept/approve the ride or not.<br><br> 
		This is the extent of how GrabbaRide will maintain user feedback. GrabbaRide do not want to get too involved in the processing of querying/approving ride details. This is left to the involved parties to decide and agree on. 
  	</p>
</asp:Content>
