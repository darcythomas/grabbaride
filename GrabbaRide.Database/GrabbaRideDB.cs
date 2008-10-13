

namespace GrabbaRide.Database
{

    //There is a bug with VS2008 SP1 which means that the GrabbaRideDB.designer.cs file gets deleted
    //See here for details on the workaround: http://connect.live.com/VisualStudio/feedback/Workaround.aspx?FeedbackID=361577
    // That is the reason why the using statements are in this weird place
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using GrabbaRide.Database.Properties;


    partial class GrabbaRideDBDataContext
    {
        protected const string APPLICATION_NAME = "GrabbaRide";

        /// <summary>
        /// Default constructor which will choose a connection string
        /// based on whether it is a debug or release build
        /// </summary>
        public GrabbaRideDBDataContext() :
#if (DEBUG)
            base(Settings.Default.GrabbaRideDBConnectionStringLocalhost, mappingSource)
#else
            base(Settings.Default.GrabbaRideDBConnectionStringMassey, mappingSource)
#endif
        {
            OnCreated();
        }

        #region RideMappings

        public void AttachRide(Ride newRide)
        {
            newRide.CreationDate = DateTime.Now;
            this.Rides.InsertOnSubmit(newRide);
            this.SubmitChanges();
        }

        public void DetachRide(Ride oldRide)
        {
            this.Rides.DeleteOnSubmit(oldRide);
            this.SubmitChanges();
        }

        //update a ride record
        public void UserEditRide(Ride newRide)
        {
            Ride oldrecord = this.GetRideByID(newRide.RideID);
            oldrecord.NumSeats = newRide.NumSeats;
            oldrecord.DepartureTime = newRide.DepartureTime;
            oldrecord.RecurMon = newRide.RecurMon;
            oldrecord.RecurTue = newRide.RecurTue;
            oldrecord.RecurWed = newRide.RecurWed;
            oldrecord.RecurThu = newRide.RecurThu;
            oldrecord.RecurFri = newRide.RecurFri;
            oldrecord.RecurSat = newRide.RecurSat;
            oldrecord.RecurSun = newRide.RecurSun;
            oldrecord.Details = newRide.Details;

            this.SubmitChanges();
        }

        public void UpdateUserDetails(User user)
        {
            User oldUser = this.GetUserByID(user.UserID);

            oldUser.Email = user.Email;
            oldUser.DateOfBirth = user.DateOfBirth;
            oldUser.Comment = user.Comment;
            oldUser.Location = user.Location;
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;

            this.SubmitChanges();
        }

        /// <summary>
        /// Gets the ride owned by the id
        /// </summary>
        /// <param name="rideID"></param>
        /// <returns></returns>
        public Ride GetRideByID(int rideID)
        {
            var query = from r in Rides
                        where r.RideID == rideID
                        select r;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Returns all rides avalible
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ride> GetAllAvalibleRides()
        {
            var rides = from r in Rides
                        where r.NumSeats > 0 && r.Available
                        select r;

            return rides;
        }

        public IEnumerable<Ride> GetRecentlyAddedRides()
        {
            var rides = (from r in Rides
                         where r.NumSeats > 0 &&
                               r.Available &&
                               r.StartDate < DateTime.Now &&
                               r.EndDate > DateTime.Now
                         orderby r.CreationDate descending
                         select r).Take(15);

            return rides;
        }

        /// <summary>
        /// Returns all rides belonging to userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IEnumerable<Ride> GetRidesByUserID(int userID)
        {
            var rides = from r in Rides
                        where r.UserID == userID
                        select r;

            return rides;
        }

        #endregion

        #region UserMappings

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="newUser"></param>
        public void AttachNewUser(User newUser)
        {
            if (GetUserByID(newUser.UserID) != null)
            {
                throw new InvalidOperationException("A user with id '{0}' already exists!");
            }
            else if (GetUserByUsername(newUser.Username) != null)
            {
                throw new InvalidOperationException("A user with username '{0}' already exists!");
            }
            else if (GetUserByEmail(newUser.Email) != null)
            {
                throw new InvalidOperationException("A user with email '{0}' already exists!");
            }


            this.Users.InsertOnSubmit(newUser);

            // set the CreationDate to now
            newUser.CreationDate = DateTime.Now;

            this.SubmitChanges();
        }

        /// <summary>
        /// Removes an existing user from the database.
        /// </summary>
        /// <param name="deleteUser"></param>
        public void DetachUser(User deleteUser)
        {
            this.Users.DeleteOnSubmit(deleteUser);
            this.SubmitChanges();
        }

        /// <summary>
        /// Finds a user by their user ID.
        /// </summary>
        /// <param name="userID">The user ID to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByID(int userID)
        {
            var query = from u in Users
                        where u.UserID == userID &&
                              u.ApplicationName == APPLICATION_NAME
                        select u;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Finds a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByUsername(string username)
        {
            var query = from u in Users
                        where u.Username == username &&
                              u.ApplicationName == APPLICATION_NAME
                        select u;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Finds a user by the email address.
        /// </summary>
        /// <param name="email">The email of the user to search for.</param>
        /// <returns>The User object, or null if no user was found.</returns>
        public User GetUserByEmail(string email)
        {
            // is it an email?
            if (!Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)"))
            {
                throw new ArgumentException("Not a valid email address: emails must be \"user@host.something\"");
            }
            else
            {
                var query = from u in this.Users
                            where u.Email == email &&
                                  u.ApplicationName == APPLICATION_NAME
                            select u;

                if (query.Count() == 0) { return null; }
                else { return query.Single(); }
            }
        }

        /// <summary>
        /// Updates a user's last activity date to now, based on their username.
        /// </summary>
        /// <param name="username"></param>
        public void UpdateLastActivityByUsername(string username)
        {
            User u = GetUserByUsername(username);
            if (u != null)
            {
                u.LastActvityDate = DateTime.Now;
                SubmitChanges();
            }
        }

        /// <summary>
        /// Checks if a user is valid, returns true or false
        /// </summary>
        /// <param name="username">username - the user's username</param>
        public Boolean CheckUser(String username)
        {
            User u = GetUserByUsername(username);
            if (u != null)
                return true;
            else
                return false;
        }

        public void PlaceFeedbackRating(string userRaterUsername, string userRatedUsername, short rating)
        {
            User userRater = GetUserByUsername(userRaterUsername);
            User userRated = GetUserByUsername(userRatedUsername);
            PlaceFeedbackRating(userRater, userRated, rating);
        }

        /// <summary>
        /// Places feedback for a user.
        /// </summary>
        /// <param name="userRater">The user placing the feedback.</param>
        /// <param name="userRated">The user that is being rated.</param>
        /// <param name="rating">The rating for the user. Must be between -1 and 1.</param>
        public void PlaceFeedbackRating(User userRater, User userRated, short rating)
        {
            // check that the rating is valid
            if (rating < -1 || rating > 1)
            {
                throw new ArgumentOutOfRangeException("Rating must be between -1 and 1!");
            }

            // users can't rate themselves
            if (userRater.UserID == userRated.UserID)
            {
                throw new ArgumentException("User's can't rate themselves!");
            }

            // the feedback we are going to place
            FeedbackRating feedback;

            // check whether a rating for this combination of users already exists
            var query = from f in FeedbackRatings
                        where f.UserRater == userRater &&
                              f.UserRated == userRated
                        select f;

            if (query.Count() == 0)
            {
                // no rating exists, create a new one
                feedback = new FeedbackRating();
                feedback.UserRater = userRater;
                feedback.UserRated = userRated;
                feedback.Rating = rating;
                feedback.DatePlaced = DateTime.Now;
                this.FeedbackRatings.InsertOnSubmit(feedback);
            }
            else
            {
                // overwrite the existing rating
                feedback = query.Single();
                feedback.Rating = rating;
                feedback.DatePlaced = DateTime.Now;
            }

            // send to database
            this.SubmitChanges();
        }

        /// <summary>
        /// Gets a FeedbackRating placed on a user.
        /// </summary>
        /// <param name="userRater">The user placing the feedback.</param>
        /// <param name="userRated">The user that is being rated.</param>
        /// <returns>The FeedbackRating if found, otherwise null.</returns>
        public FeedbackRating GetFeedbackRating(User userRater, User userRated)
        {
            //return an existing feedbackrating
            // users can't rate themselves
            if (userRater.UserID == userRated.UserID)
            {
                throw new ArgumentException("User's can't rate themselves!");
            }

            // check whether a rating for this combination of users already exists
            var query = from f in FeedbackRatings
                        where f.UserRater == userRater &&
                              f.UserRated == userRated
                        select f;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        /// <summary>
        /// Removes feedback placed on a user. If no feedback exists, do nothing.
        /// </summary>
        /// <param name="userRater">The user placing the feedback.</param>
        /// <param name="userRated">The user that is being rated.</param>
        public void RemoveFeedbackRating(User userRater, User userRated)
        {
            // users can't rate themselves
            if (userRater.UserID == userRated.UserID)
            {
                throw new ArgumentException("User's can't rate themselves!");
            }

            // check whether a rating for this combination of users already exists
            var query = from f in FeedbackRatings
                        where f.UserRater == userRater &&
                              f.UserRated == userRated
                        select f;

            // if there is no feedback for these users, no need to worry
            if (query.Count() > 0)
            {
                FeedbackRating feedback = query.Single();
                FeedbackRatings.DeleteOnSubmit(feedback);
                SubmitChanges();
            }
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return from u in this.Users
                   where u.ApplicationName == APPLICATION_NAME
                   select u;
        }

        /// <summary>
        /// Finds a user by their OpenID Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public User GetUserByOpenIDUrl(string url)
        {
            int id = GetOpenIDByUrl(url).UserID;
            var user = from u in this.Users
                       where u.UserID == id
                       select u;
            return user.Single();

        }

        public bool HasUserName(string username)
        {
            return (GetUserByUsername(username) != null) && !String.IsNullOrEmpty(username);
        }

        #endregion

        #region OpenIDMappings

        /// <summary>
        /// Aelect user_id from user_openids where openid_url = openid_url 
        /// </summary>
        /// <param name="?">The url to search for</param>
        /// <returns>The unique user id mapped to the url </returns>
        public int GetUserIDByOpenIDUrl(string openIDUrl)
        {
            return GetOpenIDByUrl(openIDUrl).UserID;
        }

        /// <summary>
        /// Checks whether a given OpenID Url exists in our database.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsOpenIDRegistered(string url)
        {
            OpenID openID = GetOpenIDByUrl(url);
            return openID != null;
        }

        /// <summary>
        /// select openid_url from user_openids where user_id = user_id 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<OpenID> GetOpenIDsByUserID(int userID)
        {
            var query = from o in OpenIDs
                        where o.UserID == userID
                        select o;

            return query.AsEnumerable();
        }

        /// <summary>
        /// Insert new open ID into the database
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        public void AttachOpenID(string openid_url, int user_id)
        {
            //check if url is valid
            if (!Uri.IsWellFormedUriString(openid_url, UriKind.Absolute))
            {
                //throw some sweet exception
                throw new ArgumentException("Not a valid Url provided for OpenID");
            }
            else
            {
                OpenID id = new OpenID(openid_url, user_id);
                this.OpenIDs.InsertOnSubmit(id);
                this.SubmitChanges();
            }
        }

        /// <summary>
        /// delete from user_openids where openid_url = openid_url and user_id = user_id 
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        public void DetachOpenID(String openid_url, int user_id)
        {
            // not sure yet why userID is required for this ... just leave please
            this.OpenIDs.DeleteOnSubmit(this.GetOpenIDByUrl(openid_url));
            this.SubmitChanges();
        }

        /// <summary>
        /// delete from user_openids where user_id = user_id
        /// </summary>
        /// <param name="user_id"></param>
        public void DetachOpenIDsByUser(int userID)
        {
            this.OpenIDs.DeleteAllOnSubmit(this.GetOpenIDsByUserID(userID));
            this.SubmitChanges();
        }

        /// <summary>
        /// Finds an OpenID by its Url
        /// </summary>
        /// <param name="openid_url"></param>
        /// <returns></returns>
        public OpenID GetOpenIDByUrl(string url)
        {
            var query = from o in OpenIDs
                        where o.OpenIDUrl == url
                        select o;

            if (query.Count() == 0) { return null; }
            else { return query.Single(); }
        }

        #endregion
    }

    public enum Gender
    {
        Female,
        Male,
    }
}
