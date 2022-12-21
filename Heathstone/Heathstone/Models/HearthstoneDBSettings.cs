namespace Heathstone.Models;

public class HearthstoneDBSettings
{

    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string  CardsCollectionName { get; set; } = null!;
    public string MetaDataCollection { get; set; } = null!;

}