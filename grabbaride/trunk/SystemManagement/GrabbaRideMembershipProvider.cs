using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace SystemManagement
{
    public sealed class GrabbaRideMembershipProvider //: MembershipProvider
    {

        #region Class Variables

        private int newPasswordLength = 8;
        private string connectionString;
        private string applicationName;
        private bool enablePasswordReset;
        private bool enablePasswordRetrieval;
        private bool requiresQuestionAndAnswer;
        private bool requiresUniqueEmail;
        private int maxInvalidPasswordAttempts;
        private int passwordAttemptWindow;
        private MembershipPasswordFormat passwordFormat;
        private int minRequiredNonAlphanumericCharacters;
        private int minRequiredPasswordLength;
        private string passwordStrengthRegularExpression;


        #endregion

        #region Enums

        private enum FailureType
        {
            Password = 1,
            PasswordAnswer = 2
        }

        #endregion

        #region Properties

       

        #endregion

        #region Initialization

        
        #endregion

    }
}
