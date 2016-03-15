using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Rider
/// </summary>
public class Rider
{
    private int riderId;
    private String familyName;
    private String givenName;
    private String gender;
    private String phone;
    private String email;
    private Club club;
    private String username;
    private String password;
    private String role;

	public Rider()
	{
        club = new Club();
        riderId = -1;
        familyName = "";
        givenName = "";
        gender = "";
        phone = "";
        email = "";
        club.Clubno = -1;
        username = "";
        password = "";
        role = "";
	}
    public int RiderId
    {
        get { return riderId; }
        set { riderId = value; }
    }
    public String FamilyName
    {
        get { return familyName; }
        set { familyName = value; }
    }
    public String GivenName
    {
        get { return givenName; }
        set { givenName = value; }
    }
    public String Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public String Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public Club Club
    {
        get { return club; }
        set { club = value; }
    }
    public String Password
    {
        get { return password; }
        set { password = value; }
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

    public String RiderEmail
    {
        get { return email; }
        set { email = value; }
    }
}