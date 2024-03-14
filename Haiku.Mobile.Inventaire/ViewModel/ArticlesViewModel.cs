using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Haiku.Mobile.Inventaire.ViewModel;

public partial class ArticlesViewModel : BaseViewModel
{
    public ObservableCollection<Article> Articles { get; } = new();


    ArticlesService articleService;
    public ArticlesViewModel(ArticlesService articleService)
    {
        Title = "Inventory list";
        this.articleService = articleService;
    }


    [RelayCommand]
    async Task GetArticlesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var articles = await articleService.GetArticles();

            if (Articles.Count != 0)
                Articles.Clear();

            foreach (var article in articles)
                Articles.Add(article);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }



    [RelayCommand]
    async Task AddArticleAsync(string articleData)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            Article articleToBeAdded = new()
            {
                Name = articleData.Split('_')[0],
                CodeNumber = articleData.Split('_')[1]
            };
            Articles.Add(articleToBeAdded);

        }
        catch (Exception ex)
        {
       
            await Shell.Current.DisplayAlert("Unable to add article", ex.Message, "OK");
            await Shell.Current.GoToAsync("//ArticlesPage",true);
        }
        finally
        {
            IsBusy = false;
            await Shell.Current.DisplayAlert("Success", "Article added successfully", "OK");
            await Shell.Current.GoToAsync( "//ArticlesPage",true);
        }

    }
}