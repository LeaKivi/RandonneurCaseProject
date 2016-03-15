/* *************************************************************************
 * BrevetDAO.cs   Original version: Katalina Kivinen 19.11.2015 
                   with help of the model by Kari Silpiö 2014
 * ------------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Layer:       Data Access Layer
 *  Class:       SQL Server specific DAO class for Brevet entity objects
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
/// Summary description for BrevetDAO
/// </summary>
public class BrevetDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public BrevetDAO()
    {
        myConnectionString = RandonneurConnectionString.Text;
        myDatabase = new Database();
    }
    /// <summary>
    /// Deletes a single Department row by DepartmentId from the database.
    /// </summary>
    /// <param name="BrevetId"></param>
    /// <returns>0 = OK, 1 = delete not allowed, -1 = error</returns>
    public int DeleteBrevet(int brevetId)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if(brevetRiderExistsForBrevet(brevetId) == true)
                {
                return 1;
            }

            String sqlText = String.Format(
              @"DELETE FROM brevet
                WHERE brevetID = {0}", brevetId);
            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch(Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }
    /// <summary>
    /// Retrieves all Brevet rows in alphabetical order by Brevet location from the database.
    /// </summary>
    /// <returns>A List of Brevets</returns>
    public List<Brevet> GetallBrevetsOrderedByDisDateLoc()
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText =
              @"SELECT brevetID, distance, brevetDate, location, climbing
                FROM brevet
                ORDER BY distance, brevetDate, location";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.BrevetId = (int)resultSet["brevetID"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.BrevetDate = (DateTime)resultSet["brevetDate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];
                

                brevetList.Add(brevet);
            }
       

            resultSet.Close();

        return brevetList;
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

    public List<Brevet> GetallBrevetsOrderedBySearchConditions(int distance, string location, int date)
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        string conditionTexts = " ";

        if (distance == -1)
        {
            conditionTexts = "1 = 1";
        }
        else
        {
            conditionTexts += " distance = " + distance;
        }

        if (location != null)
        {
            conditionTexts += " AND location = '" + location + "'";
        }
       
        if (date != -1)
        {
            conditionTexts += " AND YEAR(brevetDate) = " + date;
        }
     

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT brevetID, distance, brevetDate, location, climbing
                FROM brevet
                WHERE {0}
                ORDER BY distance, brevetDate, location", conditionTexts);

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.BrevetId = (int)resultSet["brevetID"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.BrevetDate = (DateTime)resultSet["brevetDate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];


                brevetList.Add(brevet);
            }


            resultSet.Close();

            return brevetList;
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

    public List<Brevet> GetallBrevetsOrderedByDistance(int distance)
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT brevetID, distance, brevetDate, location, climbing
                FROM brevet
                WHERE distance = {0}
                ORDER BY distance, brevetDate, location", distance);

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.BrevetId = (int)resultSet["brevetID"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.BrevetDate = (DateTime)resultSet["brevetDate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];


                brevetList.Add(brevet);
            }


            resultSet.Close();

            return brevetList;
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
    /// Retrieves a single Brevet row by BrevetId from the database.
    /// </summary>
    /// <param name="BrevetId"></param>
    /// <returns>A single Brevet object</returns>
   public Brevet GetBrevetByBrevetId(int brevetId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
                @"SELECT brevetID, distance, brevetDate, location, climbing
                FROM brevet
                Where brevetID= {0}", brevetId);

            resultSet = myDatabase.ExecuteQuery(sqlText);
            Brevet brevet = new Brevet();
            if (resultSet.Read() == true)
            {
                brevet.BrevetId = (int)resultSet["brevetID"];
                brevet.Distance = (int)resultSet["distance"];
                brevet.BrevetDate = (DateTime)resultSet["brevetDate"];
                brevet.Location = (String)resultSet["location"];
                brevet.Climbing = (int)resultSet["climbing"];
                resultSet.Close();

                return brevet;
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
    /// Inserts a single Brevet row into the database.
    /// </summary>
    /// <param name="Brevet"></param>
    /// <returns>0 = OK, 1 = insert not allowed, -1 = error</returns>
    public int InsertBrevet(Brevet brevet)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            if(brevetExists(brevet.BrevetId)== true)
            {
                return 1;
            }
            String sqlText = String.Format(
              @"INSERT INTO brevet (brevetID, distance, brevetDate, location, climbing)
               VALUES ({0}, {1},'{2}','{3}',{4})",
                brevet.BrevetId,
                brevet.Distance,
                brevet.BrevetDate.ToString("yyyy-MM-dd"),
                brevet.Location,
                brevet.Climbing);
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
    /// Updates an existing Brewet row in the database.
    /// </summary>
    /// <param name="Brevet"></param>
    /// <returns>0 = OK, -1 = error</returns>
    public int UpdateBrevet(Brevet brevet)
    {
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE brevet
                SET distance = {0}, 
                    brevetDate = '{1}', 
                    location = '{2}',
                    climbing = {3}
                    WHERE brevetID = {4}",
                     brevet.Distance,
                     brevet.BrevetDate.ToString("yyyy-MM-dd"), 
                     brevet.Location, 
                     brevet.Climbing, 
                     brevet.BrevetId);

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

    public List<Brevet> GetaDistinctLocation()
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = 
              @"SELECT distinct location
                FROM brevet
                ORDER BY location ASC";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.Location = (String)resultSet["location"];
              
                brevetList.Add(brevet);
            }
            
            resultSet.Close();

            return brevetList;
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

    public List<Brevet> GetaDistinctYear()
    {
        List<Brevet> brevetList = new List<Brevet>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText =
              @"SELECT distinct brevetDate
                FROM brevet
                ORDER BY brevetDate desc";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Brevet brevet = new Brevet();

                brevet.BrevetDate = (DateTime)resultSet["brevetDate"];

                brevetList.Add(brevet);
            }

            resultSet.Close();

            return brevetList;
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
    /// Checks if a Brevet row with the given Brevet id exists in the database.
    /// </summary>
    /// <param name="brevetId"></param>
    /// <returns>true = row exists, otherwise false</returns>
    private bool brevetExists(int brevetId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT brevetID
            FROM brevet
            WHERE brevetID = {0}", brevetId);
        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
    /// <summary>
    /// Checks if the Brevet row is being referenced by another row. 
    /// </summary>
    /// <param name="brevetId"></param>
    /// <returns>true = a child row exists, otherwise false</returns>
    private bool brevetRiderExistsForBrevet (int brevetId)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
            @"Select riderID
               FROM brevet_rider
                WHERE brevetID = {0}", brevetId);
        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }
}
// End