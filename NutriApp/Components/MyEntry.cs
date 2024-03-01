namespace NutriApp.AppNutri.Componente;

public class MyEntry : Entry
{
    public static readonly BindableProperty CornerRadiusProperty =  
        BindableProperty.Create(nameof(CornerRadius),  
            typeof(double),typeof(MyEntry));  
    // Gets or sets CornerRadius value  
    public double CornerRadius  
    {  
        get =>(double)GetValue(CornerRadiusProperty);   
        set => SetValue(CornerRadiusProperty, value);   
    }
}