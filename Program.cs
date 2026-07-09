using First;
using First.Interfaces;
using First.Models;
using First.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddSingleton<IMyService, MyServices>();
        builder.Services.AddCascadingValue(sp =>
        {
            //modell létrehozása:
            var model = new CascadingModel();
            //value feltöltése/megadása:
            model.SomeText = "Hello from CascadingValue!";
            //cascadingValue sorc létrehozása, nem fixre, mert akarjuk majd update-elni
            var source = new CascadingValueSource<CascadingModel>(model, isFixed: false);
            //figyelünk hogy van e változás
            model.PropertyChanged += (sender, arg) => source.NotifyChangedAsync();
            //visszatérünk a cascadingValue-val
            return source;
        });

        //ez minden felhasználónka megy/elérik
        builder.Services.AddSingleton<StateService>();
        builder.Services.AddScoped<LocalStorageService>();
        builder.Services.AddScoped<ProgrammingLangueageService>();
        builder.Services.AddScoped<Data>();
        builder.Services.AddScoped<ITodoApiService, TodoApiService>();
        builder.Services.AddScoped<ITodoItemService, TodoItemService>();
        builder.Services.AddScoped<ITodoCategoryService, CategoryService>();
        //builder.Services.AddHttpClient(); // no!
        

        await builder.Build().RunAsync();
    }
}