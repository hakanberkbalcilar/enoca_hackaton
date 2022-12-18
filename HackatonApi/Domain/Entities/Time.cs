using System.ComponentModel.DataAnnotations;

namespace HackatonApi.Infrastructure.Model;

public class Time : IEquatable<Time>
{
    public Time(int hour, int minute){
        Hour = hour;
        Minute = minute;
    }

    [Range(0, 23, ErrorMessage = "Hour must be between 0 - 23")]
    public int Hour { get; set; }

    [Range(0, 59, ErrorMessage = "Hour must be between 0 - 23")]
    public int Minute { get; set; }

    public bool Equals(Time? other) => Hour == other?.Hour && Minute == other?.Minute;
    

    public static bool operator >= (Time obj1, TimeSpan obj2) => obj1.Hour >= obj2.Hours && obj1.Minute >= obj2.Minutes;

    public static bool operator <= (Time obj1, TimeSpan obj2) => obj1.Hour <= obj2.Hours && obj1.Minute <= obj2.Minutes;

    public TimeSpan ToTimeSpan() => new TimeSpan(Hour, Minute, 0);
    
}