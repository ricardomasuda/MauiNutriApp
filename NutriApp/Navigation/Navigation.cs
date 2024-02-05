namespace NutriApp.Navigation;

public class Navigation
{
    private static bool _isBusy;
    private static bool _isPopupBusy;
        
    public static async Task PushPageAsync(Page page)
    {
        if(_isBusy) return;
            
        _isBusy = true;
        // var load = new LoadPage();
        // await page.Navigation.PushPopupAsync(load);
        await App.NavPage.PushAsync(page);
        //load.Close();
        _isBusy = false;
    }

    // public static async Task PushPopupAsync(PopupPage page)
    // {
    //     if(_isPopupBusy) return;
    //         
    //     _isPopupBusy = true;
    //     await App.NavPage.Navigation.PushPopupAsync(page);
    //     _isPopupBusy = false;
    // }
}