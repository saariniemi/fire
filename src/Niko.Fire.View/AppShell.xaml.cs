using System.Windows.Input;

namespace Niko.Fire.View;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
        BindingContext = this;
        
        void RegisterRoutes()
        {
            Routes.Add("monkeydetails", typeof(MainPage));
            Routes.Add("beardetails", typeof(MainPage));
            Routes.Add("catdetails", typeof(MainPage));
            Routes.Add("dogdetails", typeof(MainPage));
            Routes.Add("elephantdetails", typeof(MainPage));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }

    

    //protected override void OnNavigating(ShellNavigatingEventArgs args)
    //{
    //    base.OnNavigating(args);

    //    // Cancel any back navigation
    //    //if (e.Source == ShellNavigationSource.Pop)
    //    //{
    //    //    e.Cancel();
    //    //}
    //}

    //protected override void OnNavigated(ShellNavigatedEventArgs args)
    //{
    //    base.OnNavigated(args);

    //    // Perform required logic
    //}
}

