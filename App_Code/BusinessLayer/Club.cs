/* *************************************************************************
 * Department.cs    Original version: Kari Silpiö 20.3.2014 v1.0
 *                  Modified by     : Katalina Kivinen 19.11.2015
 * -----------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Layer:       Business Logic Layer
 *  Class:       Business object class describing a single Department
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;

/// <summary>
/// Department - Business object class
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Katalinta Kivinen 17.11.2015
/// </summary>
public class Club
{
    private int clubno;
    private String clubname;
    private String clubcity;
    private String email;

    public Club()
    {
        clubno = -1;
        clubname = "";
        clubcity = "";
        email = "";
    }

    public int Clubno
    {
        get { return clubno; }
        set { clubno = value; }
    }

    public String ClubName
    {
        get { return clubname; }
        set { clubname = value; }
    }
    
    public String ClubCity
    {
        get {return clubcity;}
        set {clubcity = value;}
    }
    
   
    public String ClubEmail
    {
        get { return email; }
        set { email = value; }
    }


}
// End