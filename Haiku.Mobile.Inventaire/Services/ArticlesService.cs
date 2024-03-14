using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Haiku.Mobile.Inventaire.Services;

public class ArticlesService
{
    readonly HttpClient httpClient;
    public ArticlesService()
    {
        this.httpClient = new HttpClient();
    }

    List<Article> articleList;
    public async Task<List<Article>> GetArticles()
    {
        if (articleList?.Count > 0)
            return articleList;

        // Online
        var response = await httpClient.GetAsync("https://ashref.tn/articlesDummy.json");
        if (response.IsSuccessStatusCode)
        {
            articleList = await response.Content.ReadFromJsonAsync(ArticleContext.Default.ListArticle);
        }

        return articleList;
    }

    public struct ServiceResponse
    {
        public bool success;
        public string message;
        public ServiceResponse(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }
    }

    ServiceResponse Items = new()
    {
        success = false,
        message = "query failed"
    };

    public async Task<Boolean> Login(string qrCodeString, string password)
    {
        var url = $"https://localhost:7199/api/LoginQrCodes/login?targetQrString={qrCodeString}&password={password}";
        try
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<ServiceResponse>(content);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            Debug.WriteLine("exception ::::::", ex.Message);
        }
        return false;
    }
}