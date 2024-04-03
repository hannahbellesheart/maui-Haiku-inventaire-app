using System.Text.Json.Serialization;

namespace Haiku.Mobile.Inventaire.Model;

public class Article
{

    public string Name { get; set; } = "Default name";
    public string CodeNumber { get; set; } = "Default barcode value";
    public string Details { get; set; } = "default details string value";
    public string Image { get; set; } = "https://picsum.photos/300";

}

[JsonSerializable(typeof(List<Article>))]
internal sealed partial class ArticleContext : JsonSerializerContext
{

}