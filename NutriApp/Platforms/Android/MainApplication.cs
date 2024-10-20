using Android.App;
using Android.Content.Res;
using Android.Runtime;

namespace NutriApp;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership): base(handle, ownership)
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        {
            if (view is Entry)
            {
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

                handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Red));
            }
        });
        
        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(Picker), (handler, view) =>
        {
            if (view is Picker)
            {
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Red));
            }
        });
        
        Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping(nameof(TimePicker), (handler, view) =>
        {
            if (view is TimePicker)
            {
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                 handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Red));
            }
        });
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}