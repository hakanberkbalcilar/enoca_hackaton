namespace HackatonApi.Core.Services.Logger;

public class ConsoleLoggerService : ILoggerService
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}