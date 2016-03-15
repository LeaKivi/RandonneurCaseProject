using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Brevet
/// </summary>
public class Brevet
{
    private int brevetId;
    private int distance;
    private DateTime brevetDate;
    private String location;
    private int climbing;
    public Brevet()
    {
        brevetId = -1;
        brevetDate = new DateTime(1900, 1, 1);
        location = "";
        climbing = -1;
    }

    public int BrevetId
    {
        get { return brevetId;}
        set { brevetId = value;}
    }

    public DateTime BrevetDate
    {
        get {return brevetDate; }
        set { brevetDate = value; }
    }
    public String Location
    {
        get {return location; }
        set { location = value; }
    }
    public int Distance
    {
        get { return distance; }
        set { this.distance = value; }
    }

    public int Climbing
    {
        get {return climbing ; }
        set { climbing = value; }
    }
}