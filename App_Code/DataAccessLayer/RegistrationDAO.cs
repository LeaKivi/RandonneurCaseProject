/* *************************************************************************
 * RegistrationDAO.cs   Original version: Katalina Kivinen 21.11.2015
 *                    
 * ------------------------------------------------------------------------
 *  Application: Randonneur Case Assignment
 *  Layer:       Data Access Layer
 *  Class:       SQL Server specific DAO class for database access
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Karis.DatabaseLibrary;
/// <summary>
/// Summary description for RegistrationDAO
/// </summary>
public class RegistrationDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public RegistrationDAO()
    {
        myConnectionString = RandonneurConnectionString.Text;
        myDatabase = new Database();
    }
    /// <summary>
    /// Retrieves a Brevet_rider row from the database by username.
    /// </summary>
    /// <returns>A Rider raw</returns>
    public Rider RegisterBrevetRider (String username)
    {
        Rider rider = new Rider();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"select rider.familyName, rider.givenName, club.clubName
                from Brevet_Rider
                join rider on rider.riderId = Brevet_Rider.riderID
                join club on club.clubId = Rider.clubId 
                where rider.username = '{0}'", username);
            resultSet = myDatabase.ExecuteQuery(sqlText);
            if (resultSet.Read() == true)
            {
                
                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Club.ClubName = (String)resultSet["clubName"];                           

            }

            resultSet.Close();

            return rider;
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
}