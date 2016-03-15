/* *************************************************************************
 * LoginRole.cs  Original version: Kari Silpiö 20.3.2014 v1.0
 *               Modified by     : Katalina Kivinen
 * -----------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Class:       Business object class holding username and login role
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;

/// <summary>
/// LoginRole - Business object class
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Katalina Kivinen 16.11.2015
/// </summary>
public class LoginRole
{
    private String username;
    private String role;
    private String password;

    public LoginRole()
    {
        username = "";
        role = null;
        password = "";
    }

    public String Username
    {
        get { return username; }
        set { username = value; }
    }

    public String Role
    {
        get { return role; }
        set { role = value; }
    }
    public String Password
    {
        get { return password; }
        set { password = value; }
    }
}
// End