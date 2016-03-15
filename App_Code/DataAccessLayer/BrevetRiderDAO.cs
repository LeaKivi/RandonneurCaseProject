/* *************************************************************************
 * ClubDAO.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *                    Modified by     : Katalina Kivinen 19.11.2015
 * ------------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Layer:       Data Access Layer
 *  Class:       SQL Server specific DAO class for Club entity objects
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
/// Summary description for BrevetRiderDAO
/// </summary>
public class BrevetRiderDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public BrevetRiderDAO()
	{
        myConnectionString = RandonneurConnectionString.Text;
        myDatabase = new Database();
    }

    /// <summary>
    /// Retrieves all Brevet_rider rows in alphabetical order by the database by brevetid.
    /// </summary>
    /// <returns>A List of Riders</returns>
    public List<BrevetRider> GetRiderListForRiderListbyBrevetId(int brevetId)
    {
        List<BrevetRider> brevetRiderList = new List<BrevetRider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"select rider.familyName, rider.givenName, club.clubName
                from Brevet_Rider
                join rider on rider.riderId = Brevet_Rider.riderID
                join club on club.clubId = Rider.clubId 
                where Brevet_Rider.brevetID = {0}", brevetId);
            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();
                BrevetRider brevetRiderItem = new BrevetRider();

                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Club.ClubName = (String)resultSet["clubName"];

                brevetRiderItem.Rider = rider;
                brevetRiderList.Add(brevetRiderItem);

            }
        
            resultSet.Close();

        return brevetRiderList;
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

    public List<BrevetRider> GetRiderListForBrevetListbyBrevetId(int brevetId)
    {
        List<BrevetRider> brevetRiderList = new List<BrevetRider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"select rider.riderId, rider.familyName, rider.givenName, club.clubName, Brevet_Rider.isCompleted, Brevet_Rider.finishingTime, Brevet.brevetDate  
                from Brevet_Rider
                join rider on rider.riderId = Brevet_Rider.riderID
                join club on club.clubId = Rider.clubId 
                join brevet on brevet.brevetID = Brevet_Rider.brevetID
                where Brevet_Rider.brevetID = {0}", brevetId);
            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();
                BrevetRider brevetRiderItem = new BrevetRider();

                rider.RiderId = (int)resultSet["riderId"];
                rider.FamilyName = (String)resultSet["familyName"];
                rider.GivenName = (String)resultSet["givenName"];
                rider.Club.ClubName = (String)resultSet["clubName"];
          
                brevetRiderItem.FinishingTimeAsString = (String)resultSet["finishingTime"];
                brevetRiderItem.IsCompleted = (String)resultSet["isCompleted"];

                brevetRiderItem.Rider = rider;
                brevetRiderList.Add(brevetRiderItem);

            }

            resultSet.Close();

            return brevetRiderList;
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

    public BrevetRider GetBrevetRiderByRiderId(int riderId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"SELECT riderID, brevetID, isCompleted, finishingTime 
                FROM brevet_Rider
                Where riderID= {0}", riderId);

            resultSet = myDatabase.ExecuteQuery(sqlText);
            BrevetRider brevetRider = new BrevetRider();
            if (resultSet.Read() == true)
            {
                brevetRider.Rider.RiderId = (int)resultSet["riderId"];
                brevetRider.Brevet.BrevetId = (int)resultSet["brevetId"];
                brevetRider.IsCompleted = (String)resultSet["isCompleted"];
                brevetRider.FinishingTimeAsString = (String)resultSet["finishingTime"];
                resultSet.Close();

                return brevetRider;
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

    public int UpdateBrevetRider(BrevetRider brevetRider)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE brevet_rider
                SET isCompleted = '{0}', 
                    finishingTime = '{1}' 
                    WHERE brevetID = {2}",
                     brevetRider.IsCompleted,
                     brevetRider.FinishingTimeAsString,
                    brevetRider.Brevet.BrevetId);

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

    public int InsertBrevetRider (BrevetRider brevetRider)
    {
       try
        {
            myDatabase.Open(myConnectionString);
            if (brevetRiderExistsAlready(brevetRider.Brevet.BrevetId, brevetRider.Rider.RiderId) == true)
            {
                return 1;
            }
            String sqlText = String.Format(
                 @"INSERT INTO brevet_rider (riderId, brevetId, isCompleted, finishingTime) 
                VALUES ({0}, {1}, '{2}', '{3}')",
                 brevetRider.Rider.RiderId,
                 brevetRider.Brevet.BrevetId,
                 brevetRider.IsCompleted,
                 brevetRider.FinishingTimeAsString);
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
    private bool brevetRiderExistsAlready(int brevetId, int riderId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
            @"Select riderID
               FROM brevet_rider
                WHERE brevetID = {0} AND riderId = {1}", brevetId, riderId);
        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

}