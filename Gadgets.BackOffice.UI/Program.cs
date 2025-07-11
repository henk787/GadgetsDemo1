using Gadgets.BackOffice.UI.Components;
using Gadgets.BackOffice.UI.UiServices;
using Gadgets.Services;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Gadgets.BackOffice.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddFluentUIComponents();

            // our services
            builder.Services.AddServices(builder.Configuration);
            builder.Services.AddTransient<IScopedMediator, ScopedMediator>();   
            
            var app = builder.Build();

            // Demo: init Db
            {
                using var scope = app.Services.CreateScope();
                var initializer = scope.ServiceProvider.GetRequiredService<ServiceInitializer>();
                initializer.InitializeData(55);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
