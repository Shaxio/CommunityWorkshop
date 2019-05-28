using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using Dapper;


namespace Service
{
    /// test 
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        #region Reports
        /// <summary>
        /// Method for retrieving all currently checked out tools
        /// </summary>
        /// <returns>
        /// currently checked out tools
        /// </returns>
        [WebMethod]
        public List<RentedTools> getCheckedOut()
        {
            //creates and stores the query
            var query = "SELECT Tools.ToolID, Tools.ToolDescription, Brands.Brand, Rentals.RentalDate FROM Rentals INNER JOIN Tools ON Tools.ToolID = Rentals.ToolID INNER JOIN Brands ON Brands.BrandID = Tools.BrandID WHERE Rentals.RentalReturn IS null;";
            // uses the query and collects the result in the return
            return Model.Connection.GetConnection().Query<RentedTools>(query).ToList();
        }
        /// <summary>
        /// Retrieving all active tools
        /// </summary>
        /// <returns>
        /// all active tools
        /// </returns>
        [WebMethod]
        public List<Tools> getActive()
        {
            var query = "SELECT Tools.*, Brands.Brand FROM Tools INNER JOIN Brands ON Brands.BrandID = Tools.BrandID WHERE Active = 1";
            return Model.Connection.GetConnection().Query<Tools>(query).ToList();
        }
        /// <summary>
        /// retrieve all active tools sorted by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>
        /// active tools sorted by brand
        /// </returns>
        [WebMethod]
        public List<Tools> getActiveByBrand(int brand)
        {
            var query = "SELECT Tools.*, Brands.Brand FROM Tools INNER JOIN Brands ON Brands.BrandID = Tools.BrandID WHERE Active = 1 AND Tools.BrandID = @Brand";
            //creates stores the parameters
            var param = new { Brand = brand };
            //returns the result of the query using the parameters
            return Model.Connection.GetConnection().Query<Tools>(query, param).ToList();
        }
        /// <summary>
        /// retrieve all retired tools
        /// </summary>
        /// <returns>
        /// all inactive tools
        /// </returns>
        [WebMethod]
        public List<Tools> getInActive()
        {
            var query = "SELECT Tools.*, Brands.Brand FROM Tools INNER JOIN Brands ON Brands.BrandID = Tools.BrandID WHERE Active = 0";
            return Model.Connection.GetConnection().Query<Tools>(query).ToList();
        }
        /// <summary>
        /// retrieve all retired tools sorted by brand
        /// </summary>
        /// <param name="brand">
        /// brand ID to search for
        /// </param>
        /// <returns>
        /// all retired tools from a certain brand
        /// </returns>
        [WebMethod]
        public List<Tools> getInActiveByBrand(int brand)
        {
            var query = "SELECT Tools.*, Brands.Brand FROM Tools INNER JOIN Brands ON Brands.BrandID = Tools.BrandID WHERE Active = 0 AND Tools.BrandID = @Brand";
            var param = new { Brand = brand };
            return Model.Connection.GetConnection().Query<Tools>(query, param).ToList();
        }
        /// <summary>
        /// retrieve all rentals by tool id
        /// </summary>
        /// <param name="ToolID">
        /// tool ID to search for
        /// </param>
        /// <returns>
        /// all rentals from a specific tool
        /// </returns>
        [WebMethod]
        public List<Rentals> getRentalByTool(int ToolID)
        {
            var query = "SELECT Rentals.*, Tools.ToolDescription, Users.RentersName FROM Rentals INNER JOIN Tools ON Tools.ToolID = Rentals.ToolID INNER JOIN Users ON Users.UserID = Rentals.UserID WHERE Rentals.ToolID = @ID;";
            var param = new { ID = ToolID };
            return Model.Connection.GetConnection().Query<Rentals>(query, param).ToList();
        }
        /// <summary>
        /// retrieve rentals by patron
        /// </summary>
        /// <param name="UserID">
        /// patron ID to search for
        /// </param>
        /// <returns>
        /// rented tools by a user
        /// </returns>
        [WebMethod]
        public List<Rentals> getRentalByUser(int UserID)
        {
            var query = "SELECT Rentals.*, Tools.ToolDescription, Users.RentersName FROM Rentals INNER JOIN Tools ON Tools.ToolID = Rentals.ToolID INNER JOIN Users ON Users.UserID = Rentals.UserID WHERE Rentals.UserID = @ID;";
            var param = new { ID = UserID };
            return Model.Connection.GetConnection().Query<Rentals>(query, param).ToList();
        }
        /// <summary>
        /// Method for getting brands by id
        /// </summary>
        /// <param name="brandID">
        /// brand id to search for
        /// </param>
        /// <returns>
        /// a list of brand objects
        /// </returns>
        [WebMethod]
        public List<Brands> getBrandByID(int brandID)
        {
            var query = "SELECT * FROM Brands WHERE BrandID = @brandid";
            var param = new { brandid = brandID };
            return Model.Connection.GetConnection().Query<Brands>(query, param).ToList();
        }
        /// <summary>
        /// Method for getting tool by id
        /// </summary>
        /// <param name="id">
        /// id to search for
        /// </param>
        /// <returns>
        /// a list of tool objects
        /// </returns>
        [WebMethod]
        public List<Tools> getToolByID(int id)
        {
            var query = "SELECT * FROM Tools WHERE ToolID = @ID";
            var param = new { ID = id };
            return Model.Connection.GetConnection().Query<Tools>(query, param).ToList();
        }
        /// <summary>
        /// method for getting comments by id
        /// </summary>
        /// <param name="id">
        /// id to search for
        /// </param>
        /// <returns>
        /// a list of comments objects
        /// </returns>
        [WebMethod]
        public List<Comments> getCommentByID(int id)
        {
            var query = "SELECT * FROM Comments WHERE CommentID = @ID";
            var param = new { ID = id };
            return Model.Connection.GetConnection().Query<Comments>(query, param).ToList();
        }
        /// <summary>
        /// method for getting users by id
        /// </summary>
        /// <param name="id">
        /// id to search for
        /// </param>
        /// <returns>
        /// a list of users
        /// </returns>
        [WebMethod]
        public List<Users> getUserByID(int id)
        {
            var query = "SELECT * FROM Users WHERE UserID = @ID";
            var param = new { ID = id };
            return Model.Connection.GetConnection().Query<Users>(query, param).ToList();
        }
        /// <summary>
        /// Method for getting rentals by id
        /// </summary>
        /// <param name="id">
        /// id to search for
        /// </param>
        /// <returns>
        /// a list of rental objects
        /// </returns>
        [WebMethod]
        public List<Rentals> getRentalByID(int id)
        {
            var query = "SELECT * FROM Rentals WHERE RentalID = @ID";
            var param = new { ID = id };
            return Model.Connection.GetConnection().Query<Rentals>(query, param).ToList();
        }
        /// <summary>
        /// method for getting comments by tool ID
        /// </summary>
        /// <param name="ToolID">
        /// tool ID to search for
        /// </param>
        /// <returns>
        /// returns a list of comments by tool
        /// </returns>
        [WebMethod]
        public List<Comments> getCommentsByTool(int ToolID)
        {
            var query = "SELECT Comments.*, Tools.ToolDescription FROM Comments INNER JOIN Tools ON Tools.ToolID = Comments.ToolID WHERE Comments.ToolID = @ID";
            var param = new { ID = ToolID };
            return Model.Connection.GetConnection().Query<Comments>(query, param).ToList();
        }
        #endregion

        #region Overall collection Reports
        /// <summary>
        /// retrieve all brands
        /// </summary>
        /// <returns>
        /// all brands
        /// </returns> 
        [WebMethod]
        public List<Brands> getAllBrands()
        {
            var query = "SELECT * FROM Brands";
            return Model.Connection.GetConnection().Query<Brands>(query).ToList();
        }
        /// <summary>
        /// retrieve every rental ever done 
        /// </summary>
        /// <returns>
        /// every rental ever done
        /// </returns>
        [WebMethod]
        public List<Rentals> getAllRentals()
        {
            var query = "SELECT Rentals.*, Tools.ToolName, Tools.ToolDescription, Users.RentersName FROM Rentals INNER JOIN Tools ON Tools.ToolID = Rentals.ToolID INNER JOIN Users ON Users.UserID = Rentals.UserID;";
            //var query = "SELECT * FROM Rentals";
            return Model.Connection.GetConnection().Query<Rentals>(query).ToList();
        }
        /// <summary>
        /// retrieves all tools in the database
        /// </summary>
        /// <returns>
        /// all tools in the database
        /// </returns>
        [WebMethod]
        public List<Tools> getAllTools()
        {
            var query = "SELECT Tools.*, Brands.Brand FROM Tools INNER JOIN Brands ON Brands.BrandID = Tools.brandID";
            return Model.Connection.GetConnection().Query<Tools>(query).ToList();
        }
        /// <summary>
        /// method for getting all comments
        /// </summary>
        /// <returns>
        /// all comments by id
        /// </returns>
        [WebMethod]
        public List<Comments> getAllComments()
        {
            var query = "SELECT Comments.*, Tools.ToolDescription FROM Comments INNER JOIN Tools ON Tools.ToolID = Comments.ToolID";
            return Model.Connection.GetConnection().Query<Comments>(query).ToList();
        }
        /// <summary>
        /// retriefves all users from the databse
        /// </summary>
        /// <returns>
        /// all users in the database
        /// </returns>
        [WebMethod]
        public List<Users> getAllUsers()
        {
            var query = "SELECT * FROM Users";
            return Model.Connection.GetConnection().Query<Users>(query).ToList();
        }
        
        #endregion

        #region user logins
        /// <summary>
        /// create a new staff account
        /// </summary>
        /// <param name="name">
        /// the Username for the staffmember
        /// </param>
        /// <param name="password">
        /// the Password for the staffmember
        /// </param>
        /// <returns>
        /// true or false depending on if the staff memgber was created without error
        /// </returns>
        [WebMethod]
        public bool createStaffMember(string name, string password)
        {
            //big thanks to Andrew for his help on making this work properly
            try
            {
                //creates a random cryptoserviceprovider
                var cryptoserv = new RNGCryptoServiceProvider();
                //sets the salt byte to an array of 32 characters
                byte[] salt = new byte[32];
                //fills the salt array with random characters, letters or numbers or really anything
                cryptoserv.GetBytes(salt);
                //terminates the cryptoserviceprovider
                cryptoserv.Dispose();
                //creates a hashing algorithm based on SHA256
                HashAlgorithm algorithm = new SHA256Managed();
                //sets the byte array to the users new password as bytes
                byte[] plainText = Encoding.UTF8.GetBytes(password);
                //sets the byte array to the size of the password bytes plus the salt bytes
                byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

                //loops through each character of the plaintext byte array
                for (int i = 0; i < plainText.Length; i++)
                {
                    //sets one byte arrays character to the value of the other
                    plainTextWithSaltBytes[i] = plainText[i];
                }

                //loops through each character in the salt byte array
                for (int i = 0; i < salt.Length; i++)
                {
                    //sets one byte arrays character to the value of the other
                    plainTextWithSaltBytes[plainText.Length + i] = salt[i];
                }
                var query = "INSERT INTO Staff (UserName, Hash, Salt) VALUES (@UserName, @Hash, @Salt)";
                var param = new { UserName = name, Hash = algorithm.ComputeHash(plainTextWithSaltBytes), Salt = salt };
                //runs the query
                Model.Connection.GetConnection().Execute(query, param);
                //returns true
                return true;
            }
            // catches any errors, hope there is none
            catch (Exception)
            {
                //returns false if there was any errors
                return false;
            }
        }
        /// <summary>
        /// Checking if the users password is right
        /// </summary>
        /// <param name="password">
        /// the users password
        /// </param>
        /// <param name="name">
        /// the users name
        /// </param>
        /// <returns>
        /// true or false depending on if they entered correctly or not
        /// </returns>
        [WebMethod]
        public bool login(string password, string name)
        {
            var query = "SELECT * FROM Staff WHERE UserName = @Name";
            var param = new { Name = name };
            List<Staff> memberToCheck = Model.Connection.GetConnection().Query<Staff>(query, param).ToList();
            //creates variable to the value of membertocheck.salt
            var usersalt = memberToCheck[0].Salt;
            //creates variable to the value of membertocheck.hash
            var userhash = memberToCheck[0].Hash;
            HashAlgorithm algorithm = new SHA256Managed();
            // sets the byte array to the users password as bytes
            byte[] plainText = Encoding.UTF8.GetBytes(password);
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + usersalt.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < usersalt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = usersalt[i];
            }
            //creates the hash based on the byte list provided
            var hashToCompare = algorithm.ComputeHash(plainTextWithSaltBytes);
            //if the length of the two hashes dont match, a quick way to tell if its wrong
            if (userhash.Length != hashToCompare.Length)
            {
                //return false
                return false;
            }
            //if any of the characters in the two hashes dont match
            for (int i = 0; i < userhash.Length; i++)
            {
                if (userhash[i] != hashToCompare[i])
                {
                    //return false
                    return false;
                }
            }
            //if all the characters match and the length is the same
            return true;
        }
        #endregion

        #region Management
        /// <summary>
        /// method for creating a new brand
        /// </summary>
        /// <param name="name">
        /// The brand name
        /// </param>
        /// <returns>
        /// true if the brand was added succesfully, false if not
        /// </returns>
        [WebMethod]
        public bool newBrand(string name)
        {
            try
            {
                var query = "INSERT INTO Brands (Brand) VALUES (@Name)";
                var param = new { Name = name };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Method for adding a new tool
        /// </summary>
        /// <param name="brandID">
        /// the brand ID
        /// </param>
        /// <param name="tooldescription">
        /// the tools description
        /// </param>
        /// <param name="active">
        /// just a precaution, but is the tool active
        /// </param>
        /// <returns>
        /// true if the tool is succesfully added, false if it fails
        /// </returns>
        [WebMethod]
        public bool newTool(int brandID, string toolname, string tooldescription, bool active)
        {
            try
            {
                var query = "INSERT INTO Tools (BrandID, ToolName, ToolDescription, Active) VALUES (@BrandID, @ToolName, @ToolDescription, @Active)";
                var param = new { BrandID = brandID, ToolName = toolname, ToolDescription = tooldescription, Active = active };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// method for creating a new comment
        /// </summary>
        /// <param name="ToolID">
        /// the tool ID bound to the comment
        /// </param>
        /// <param name="Comment">
        /// the comment bount to the comment
        /// </param>
        /// <returns>
        /// returns a bool for validation
        /// </returns>
        [WebMethod]
        public bool newComment(int ToolID, string Comment)
        {
            try
            {
                var query = "INSERT INTO Comments (ToolID, Comment) VALUES (@ID, @comment)";
                var param = new { ID = ToolID, comment = Comment };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// method for adding a new renter
        /// </summary>
        /// <param name="name">
        /// the name of the renter
        /// </param>
        /// <returns>
        /// true if the user was added succesfully or false if not
        /// </returns>
        [WebMethod]
        public bool newRenter(string name)
        {
            try
            {
                var query = "INSERT INTO Users (RentersName) VALUES (@Name)";
                var param = new { Name = name };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// method for creating a new rental
        /// </summary>
        /// <param name="toolID">
        /// tool id bound to the rental
        /// </param>
        /// <param name="UserID">
        /// user id bound to the rental
        /// </param>
        /// <param name="rentaldate">
        /// rented date of the rental
        /// </param>
        /// <returns>
        /// true if success false if fail
        /// </returns>
        [WebMethod]
        public bool newRental(int toolID, int userID, string rentaldate)
        {
            try
            {
                var query = "INSERT INTO Rentals (ToolID, UserID, RentalDate) VALUES (@ToolID, @UserID, @RentalDate)";
                var param = new { ToolID = toolID, UserID = userID, RentalDate = rentaldate };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// a method for adding a return date to a rental
        /// </summary>
        /// <param name="rentalID">
        /// the rental id being returned
        /// </param>
        /// <param name="datetime">
        /// the date and time of the return
        /// </param>
        /// <returns>
        /// true if success, false if fail
        /// </returns>
        [WebMethod]
        public bool returnRental(int rentalID, string datetime)
        {
            try
            {
                var query = "UPDATE Rentals SET RentalReturn = @RentalReturn WHERE RentalID = @ID";
                var param = new { RentalReturn = datetime, ID = rentalID };
                Model.Connection.GetConnection().Execute(query, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// method for editing brands
        /// </summary>
        /// <param name="id">
        /// id of the brand
        /// </param>
        /// <param name="name">
        /// brand name to be updated
        /// </param>
        [WebMethod]
        public void editBrand(int id, string name)
        {
            try
            {

                var query = "UPDATE Brands SET Brand = @Name WHERE BrandID = @ID";
                var param = new { Name = name, ID = id };
                Model.Connection.GetConnection().Execute(query, param);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// editing a tool
        /// </summary>
        /// <param name="id">
        /// the tools ID
        /// </param>
        /// <param name="brandid">
        /// the brands id
        /// </param>
        /// <param name="description">
        /// the tools description
        /// </param>
        /// <param name="active">
        /// if the tool is active
        /// </param>
        [WebMethod]
        public void editTool(int id, int brandid, string toolname, string tooldescription, bool active)
        {
            try
            {
                var query = "UPDATE Tools SET BrandID = @BrandID, ToolName = @ToolName, ToolDescription = @ToolDescription, Active = @Active WHERE ToolID = @ID";
                var param = new { ID = id, BrandID = brandid, ToolName = toolname, ToolDescription = tooldescription, Active = active };
                Model.Connection.GetConnection().Execute(query, param);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// editing a comment
        /// </summary>
        /// <param name="id">
        /// the comments ID
        /// </param>
        /// <param name="toolid">
        /// the tools ID
        /// </param>
        /// <param name="comment">
        /// the comment
        /// </param>
        [WebMethod]
        public void editComment(int id, int toolid, string comment)
        {
            try
            {
                var query = "UPDATE Comments SET ToolID = @ToolID, Comment = @Comment WHERE CommentID = @ID";
                var param = new { ID = id, ToolID = toolid, Comment = comment };
                Model.Connection.GetConnection().Execute(query, param);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// method for editing a users name
        /// </summary>
        /// <param name="id">
        /// the ID of the user
        /// </param>
        /// <param name="name">
        /// the name of the user to be editing
        /// </param>
        [WebMethod]
        public void editRenter(int id, string name)
        {
            try
            {
                var query = "UPDATE Users SET RentersName = @Name WHERE UserID = @ID";
                var param = new { Name = name, ID = id };
                Model.Connection.GetConnection().Execute(query, param);
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// editing a rental
        /// </summary>
        /// <param name="id">
        /// the rental id
        /// </param>
        /// <param name="toolid">
        /// the tools id
        /// </param>
        /// <param name="userid">
        /// the users ID
        /// </param>
        /// <param name="rented">
        /// the date of the rental start
        /// </param>
        /// <param name="rentalreturn">
        /// the end date of the rental
        /// </param>
        [WebMethod]
        public void editRental(int id, int toolid, int userid, string rentaldate, string rentalreturn)
        {
            try
            {
                var query = "UPDATE Rentals SET ToolID = @ToolID, UserID = @UserID, RentalDate = @RentalDate, RentalReturn = @RentalReturn WHERE RentalID = @ID";
                var param = new { ID = id, ToolID = toolid, UserID = userid, RentalDate = rentaldate, RentalReturn = rentalreturn };
                Model.Connection.GetConnection().Execute(query, param);
            }
            catch (Exception)
            {
            }
        }
        #endregion

    }
}
