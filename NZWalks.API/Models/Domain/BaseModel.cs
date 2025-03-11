namespace NZWalks.API.Models.Domain;
/// <summary>
/// BaseModel holds common properties present in its derived class
/// </summary>
public class BaseModel
{
    public Guid Id
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }
}
