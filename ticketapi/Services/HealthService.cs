namespace Ticketapi.Services;

public class HealthService {
    public string GetHealth() 
    {
        return "healthy";
    }

    public string GetVersion()
    {
        return "1.0.0";
    }
}