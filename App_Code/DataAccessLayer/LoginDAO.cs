/* *************************************************************************
 * LoginDAO.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *               Modified by     : Katalina Kivinen 19.11.2015
 * ------------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Layer:       Data Access Layer
 *  Class:       DAO class for database services for login functionality
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * - No password security etc.
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
/// LoginDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Katalina Kivinen 16.11.2015
/// </summary>>
public class LoginDAO
{
    private Database myDatabase;
    private String myConnectionString;


    public LoginDAO()
    {
        myConnectionString = RandonneurConnectionString.Text;
        myDatabase = new Database();

    }

 
    public string LoginRoleCheck(string username, string password)
    {
        IDataReader resultSet = null;

        LoginRole loginRole = new LoginRole();
        String sqlText;

        try
        {
            myDatabase.Open(myConnectionString);

            sqlText = "select username, password, role " +
            "from Rider";
            resultSet = myDatabase.ExecuteQuery(sqlText);

            while (resultSet.Read() == true)
            {
                if (username == (string)resultSet["username"] && password == (string)resultSet["password"])
                {
                    if ((string)resultSet["role"] == "user")
                    {
                        loginRole.Role = "user";
                        break;
                    }
                    if((string)resultSet["role"] == "admin")
                    {
                        loginRole.Role = "administrator";
                        break;
                    }
                }
                else
                {
                    loginRole.Role = null;
                }                
            }
            
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            if (resultSet != null && !resultSet.IsClosed)
            {
                resultSet.Close();
            }
            myDatabase.Close();

        }
              
         
        return loginRole.Role;
    }
}


// End
