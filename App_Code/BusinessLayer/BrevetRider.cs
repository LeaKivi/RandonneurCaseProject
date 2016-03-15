using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BrevetRider
/// </summary>
public class BrevetRider
{
    private Rider rider;
    private Brevet brevet;
    private String isCompleted;
    private DateTime finishingDate;
    private TimeSpan finishingTime;
    

	public BrevetRider()
	{
        rider = new Rider();
        brevet = new Brevet();
        isCompleted = "N";
        FinishingDate = brevet.BrevetDate;
        finishingTime = new TimeSpan(0, 0, 0);
    }
    public Rider Rider
    {
        get { return rider; }
        set { rider = value; }
    }
    public Brevet Brevet
    {
        get { return brevet; }
        set { brevet = value; }
    }
    public String IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public TimeSpan FinishingTime
    {
        get { return finishingTime; }
        set { finishingTime = value;  }
    }

    public DateTime FinishingDate
    {
        get { return finishingDate; }
        set { finishingDate = value; }
    }
    public String FinishingTimeAsString
    {
        get 
        {
            return finishingTime.ToString(@"hh\:mm"); 
        }
        set 
        {
           //finishingTime = TimeSpan.ParseExact(value, "hh:mm", );
           String[] parts = value.Split(':');
           if (parts.Length == 2)
           {
               finishingTime = new TimeSpan(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), 0);
           }
           else
           {
               finishingTime = new TimeSpan(0, 0, 0);
           }

        }
    }
}   