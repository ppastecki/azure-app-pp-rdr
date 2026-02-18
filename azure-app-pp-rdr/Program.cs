using azure_app_pp_rdr.Data;
using Microsoft.EntityFrameworkCore;

namespace azure_app_pp_rdr;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("az-webapp-db");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddRazorPages();
        builder.Services.AddApplicationInsightsTelemetry();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
            .WithStaticAssets();

        app.Run();
    }
}
