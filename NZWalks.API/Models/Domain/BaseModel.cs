namespace NZWalks.API.Models.Domain;
/// <summary>
/// BaseModel holds common properties present in its derived class
/// </summary>
public class BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the model.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the model.
    /// </summary>
    public string Name { get; set; }
}
