using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace GrabbaRide.Database
{
    public partial class User
    {
        /// <summary>
        /// A constructor for the User class, which takes a username.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        public User(string username)
            : this()
        {
            this.Username = username;
        }

        /// <summary>
        /// The FirstName and LastName.
        /// </summary>
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        /// <summary>
        /// The sum of feedback ratings placed for this user.
        /// </summary>
        public int FeedbackScoreTotal
        {
            get
            {
                var query = from f in FeedbackRatingsReceived
                            select Convert.ToInt32(f.Rating);
                return query.Sum();
            }
        }

        /// <summary>
        /// The number of feedback ratings placed for this user.
        /// </summary>
        public int FeedbackScoreCount
        {
            get
            {
                return FeedbackRatingsReceived.Count;
            }
        }

        /// <summary>
        /// Generates a random valid password.
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomPassword()
        {
            const string passwordChars = "fjdksllreifjdlfpoqFHJDSLREQPUOVXMN47382109246520,.[]'-_";

            Random r = new Random();
            string password = String.Empty;

            for (int i = 0; i < 10; i++)
            {
                int z = r.Next(passwordChars.Length);
                password += passwordChars[z];
            }

            return password;
        }

        public string FeedbackString
        {
            get
            {
                return String.Format("{0}, created from {1} ratings.", this.FeedbackScoreTotal, this.FeedbackScoreCount);
            }
        }


        /// <summary>
        /// Calculates whether the user is currently signed in, based on whether their last activity
        /// was in the last 15 minutes.
        /// </summary>
        public bool IsSignedIn
        {
            get
            {
                // if there is no last activity date
                if (!this.LastActvityDate.HasValue)
                    return false;
                // if their last activity was more than 15 minutes ago
                else if (DateTime.Now.Subtract(this.LastActvityDate.Value).TotalMinutes > 15)
                    return false;
                // otherwise, must be logged in
                else return true;
            }
        }

        /// <summary>
        /// Emails a message to the user, using a template plus the message.
        /// </summary>
        /// <param name="message">The message to send</param>
        public void SendMessage(string message, User fromUser)
        {
            const string MESSAGE_TEMPLATE = "You have recieved a new message from GrabbaRide user {0}:\r\n" +
                "{1}\r\nThank you for using GrabbaRide!\r\nIf you have any queries, feel free to contact us " +
                "at grabbaride@gmail.com\r\nYou can reply to the user simply by selecting the \"Reply\"" +
                "option in your email client.";

            // get the from and to addresses
            MailAddress grabbarideAddress = new MailAddress("grabbaride@gmail.com", "GrabbaRide Team");
            MailAddress userAddress = new MailAddress(this.Email, this.FullName);

            // create the email
            MailMessage email = new MailMessage(grabbarideAddress, userAddress);
            email.ReplyTo = new MailAddress(fromUser.Email, fromUser.FullName);
            email.Subject = "New message from GrabbaRide user";
            email.Body = String.Format(MESSAGE_TEMPLATE, fromUser.Username, message);

            // send the message
            try
            {
                // if we are outside massey, won't be able to send email!
                SmtpClient client = new SmtpClient("smtp.massey.ac.nz");
                client.Send(email);
            }
            catch (SmtpException) { }
            catch (SocketException) { }
        }

        /// <summary>
        /// Sends a thank you for signing up email to the user.
        /// </summary>
        public void SendRegistrationEmail()
        {
            const string MESSAGE_TEMPLATE = "Thank you for signing up for GrabbaRide!\r\n" +
                "You're account details are as follows:\r\n\r\n" +
                "Username: {0}\r\n" +
                "Password: {1}\r\n" +
                "Security Question: {2}\r\n" +
                "Security Answer: {3}\r\n\r\n" +
                "If you have any queries, feel free to contact us at grabbaride@gmail.com\r\n";

            // get the from and to addresses
            MailAddress grabbarideAddress = new MailAddress("grabbaride@gmail.com", "GrabbaRide Team");
            MailAddress userAddress = new MailAddress(this.Email, this.FullName);

            // create the email
            MailMessage email = new MailMessage(grabbarideAddress, userAddress);
            email.Subject = "GrabbaRide Signup";
            email.Body = String.Format(MESSAGE_TEMPLATE, this.Username, "********",
                this.PasswordQuestion, this.PasswordAnswer);

            // send the message
            try
            {
                // if we are outside massey, won't be able to send email!
                SmtpClient client = new SmtpClient("smtp.massey.ac.nz");
                client.Send(email);
            }
            catch (SmtpException) { }
            catch (SocketException) { }
        }
    }
}
