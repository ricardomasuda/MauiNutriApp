namespace NutriApp.AppNutri.Componente;

public class HyperlinkSpan : Span
{
    public static readonly BindableProperty UrlProperty =
        BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan), null);

    public string Url
    {
        get => (string)GetValue(UrlProperty);
        set => SetValue(UrlProperty, value);
    }

    public HyperlinkSpan()
    {
        try
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Color.Parse("#0000FF");
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Launcher.OpenAsync(Url.Trim()))
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
            
    }
}