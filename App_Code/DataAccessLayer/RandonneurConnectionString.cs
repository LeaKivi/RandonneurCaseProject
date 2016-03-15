/* *************************************************************************
 * ModelCaseConnectionString.cs  
 * 
 * Original version: Kari Silpiö 20.3.2014 v1.0
 *                   Modified by: - Katalina Kivinen 19.11.2015
 * ------------------------------------------------------------------------
 *  Application: Randonneur Case
 *  Layer:       Data Access Layer
 *  Class:       Connection string for the database
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
/// <summary>
/// Connection string for the database
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Katalina Kivinen 17.11.2015
/// </summary>
public class RandonneurConnectionString
{
    //private static string text =
    //@"Data Source=(LocalDB)\v11.0;
    //    AttachDbFilename=|DataDirectory|RandonneurDatabase_School.mdf;
    //    Integrated Security=True;Connect Timeout=30";
    private static string text =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=|DataDirectory|\RandonneurDatabase_Home.mdf;
        Integrated Security=True;Connect Timeout=30";

    public static string Text
    {
       get { return text; }
    }
}
// End