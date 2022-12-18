using ChefApi.Core.Middleware;
using HackatonApi.Infrastructure.Model;

namespace HackatonApi.Core.Extensions;

public static class TimeExtension
{
    public static Time ToTime(this TimeSpan timeSpan) => new Time(timeSpan.Hours, timeSpan.Minutes);
}