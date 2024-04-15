namespace NutriApp.Components;

public class MyEntry : Microsoft.Maui.Controls.Entry {
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MyEntry));

    public double CornerRadius {
        get => (double)GetValue(CornerRadiusProperty);
        init => SetValue(CornerRadiusProperty, value);
    }
}