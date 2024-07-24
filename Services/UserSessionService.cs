using Hospital.Models;

public class UserSessionService
{
    private static UserSessionService _instance;

    public UserSessionService() { }

    public Guid LoggedInId { get; set; }
    public string LoggedInUsername { get; set; }
    public UserRole LoggedInRole { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
