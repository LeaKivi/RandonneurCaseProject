 //* ------------------------------------------------------------------------
 //*  Application: Randonneur Case
 //*  Layer:       Data Access Layer
 //*  Class:       SQL Server specific DAO class for Class entity objects
 //* -------------------------------------------------------------------------
 //* NOTICE: This is an over-simplified example for an introductory course. 
 //* - Error processing is not robust (some error are not handled)
 //* - No multi-user considerations, no transaction programming 
 //* - No protection for attacks of type 'SQL injection'
 //* -------------------------------------------------------------------------
 //* NOTE: This file can be included in your solution.
 //*   If you modify this file, write your name & date after "Modified by:"
 //*   DO NOT REMOVE THIS COMMENT.
 //************************************************************************* */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// RiderDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Katalina Kivinen 11.2015
///          modified by: </remarks>
/// </summary>
public class RiderDAO
{
    private Database myDatabase;
    private String myConnectionString;
    public RiderDAO()
    {
        myConnectionString = RandonneurConnectionString.Text;
        myDatabase = new Database();
    }

    /// <summary>
    /// Deletes a single Rider row byRiderId from the database.
    /// </summary>
    /// <param name="DepartmentId"></param>
    /// <returns>0 = OK, 1 = delete not allowed, -1 = error</returns>
    /// 
    public int DeteleRider(int riderId)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if (riderExistsForBrevetRider(riderId) == true)
            {
                return 1;
            }

            String sqlText = String.Format(
                @"DELETE FROM rider
                  where riderId = {0}", riderId);
            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }
    /// <summary>
    /// Retrieves all Rider rows in alphabetical order by Rider name from the database.
    /// </summary>
    /// <returns>A List of Riders</returns>

    public List<Rider> GetAllRidersOrderedByName()
    {
        List<Rider> riderList = new List<Rider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = 
                @"select riderId, familyName, givenName, gender, phone, email, clubId,
                   username, password, role 
                   from rider
                   order by familyName ASC, givenName ASC";
           
            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();

                rider.RiderId = (int)resultSet["riderId"];
                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Gender = (String)resultSet["gender"];
                rider.Phone =(String)resultSet["phone"];
                rider.RiderEmail =(String)resultSet["email"];
               //club number refference???
                rider.Username =(String)resultSet["username"];
                rider.Password =(String)resultSet["password"];
                rider.Role = (String)resultSet["role"];

                riderList.Add(rider);
            }
            resultSet.Close();

            return riderList;
            }
        catch (Exception)
        {
            return null; // An error occured
        }
        finally
        {
            myDatabase.Close();
        }
    }
    /// <summary>
    /// Retrieves a single Rider row by RiderId from the database.
    /// </summary>
    /// <param name="RiderId"></param>
    /// <returns>A single Rider object</returns>
   
    public Rider GetRiderByRiderId(int riderId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"select riderId, familyName, givenName, gender, phone, email, clubId,
                   username, password, role 
                   from rider
                    where riderId = {0}", riderId);
            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            { Rider rider = new Rider();

                rider.RiderId = (int)resultSet["riderId"];
                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Gender = (String)resultSet["gender"];
                rider.Phone =(String)resultSet["phone"];
                rider.RiderEmail =(String)resultSet["email"];
                rider.Club.Clubno = (int)resultSet["clubId"];
                rider.Username =(String)resultSet["username"];
                rider.Password =(String)resultSet["password"];
                rider.Role = (String)resultSet["role"];
                resultSet.Close();

                return rider;
            }
                                  
            else
            {
                return null; // Not found
            }
        }
        catch (Exception)
        {
            return null;  // An error occurred
        }
        finally
        {
            
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Inserts a single Rider row into the database.
    /// </summary>
    /// <param name="Rider"></param>
    /// <returns>0 = OK, 1,2 = insert not allowed, -1 = error</returns>
    public int InsertRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);
            if (riderExistsForRider(rider.RiderId) == true)
            {
                return 1;
            }
            else if (usernameExistsForRider(rider.Username) == true)
            {
                return 2;
            }
            String sqlText = String.Format(
                 @"INSERT INTO rider (riderId, familyName, givenName, gender, phone, email, clubId,
                   username, password, role) 
                VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}', '{8}', '{9}')",
                 rider.RiderId,
                 rider.FamilyName,
                 rider.GivenName,
                 rider.Gender,
                 rider.Phone,
                 rider.RiderEmail,
                 rider.Club.Clubno,
                 rider.Username,
                 rider.Password,
                 rider.Role);
            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
        
    }

    /// <summary>
    /// Updates an existing Rider row in the database.
    /// </summary>
    /// <param name="Rider"></param>
    /// <returns>0 = OK, -1 = error</returns>
    /// 
    public int UpdateRider(Rider rider)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"UPDATE rider
                  SET  
                        familyName = '{1}', 
                        givenName = '{2}', 
                        gender = '{3}', 
                        phone = '{4}', 
                        email = '{5}', 
                        clubId = {6},
                        username = '{7}', 
                        password = '{8}', 
                        role = '{9}' 
                 WHERE riderId = {0}",
                 rider.RiderId,
                 rider.FamilyName,
                 rider.GivenName,
                 rider.Gender,
                 rider.Phone,
                 rider.RiderEmail,
                 rider.Club.Clubno,
                 rider.Username,
                 rider.Password,
                 rider.Role);
            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    private bool riderExistsForBrevetRider(int riderId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderId
            From brevet_rider
            Where riderID = {0}", riderId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

         /// <summary>
    /// Checks if a Rider row with the given Rider id exists in the database.
    /// </summary>
    /// <param name="riderId"></param>
    /// <returns>true = row exists, otherwise false</returns>
    /// 
        private bool riderExistsForRider(int riderId)
        {
            IDataReader resultSet;
            bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderId
            From rider
            Where riderId = {0}", riderId);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    private bool usernameExistsForRider (string username)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
            @"select username  
                   from rider 
                   where username = '{0}'", username);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
    /// <summary>
    /// looks for Rider row in the database by rider username.
    /// </summary>
    /// <param name="username"></param>
    /// <returns>rider row</returns>
    /// 

    public Rider FindRiderByUserName(string username)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"select riderId, familyName, givenName, gender, phone, email, clubId,
                   username, password, role 
                   from rider
                   where username = '{0}'", username);
            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Rider rider = new Rider();

                rider.RiderId = (int)resultSet["riderId"];
                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Gender = (String)resultSet["gender"];
                rider.Phone = (String)resultSet["phone"];
                rider.RiderEmail = (String)resultSet["email"];
                rider.Club.Clubno = (int)resultSet["clubId"];
                rider.Username = (String)resultSet["username"];
                rider.Password = (String)resultSet["password"];
                rider.Role = (String)resultSet["role"];
                resultSet.Close();

                return rider;
            }

            else
            {
                return null; // Not found
            }
        }
        catch (Exception)
        {
            return null;  // An error occurred
        }
        finally
        {

            myDatabase.Close();
        }
    }
}
// End

