using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shakat.UI;
using Shakat.UI.Services;
using Shakat.UI.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredModal();

#region DI Start

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

builder.Services.AddScoped<ILogisticsOrderService, LogisticsOrderService>();
//builder.Services.AddScoped<IVehicleSubTypeService, VehicleSubTypeService>();
//builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();

builder.Services.AddScoped<IRouteInfoService, RouteInfoService>();
builder.Services.AddScoped<IRouteInfoService, RouteInfoService>();
 builder.Services.AddScoped<IRouteInfoService, RouteInfoService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
#endregion DI End

await builder.Build().RunAsync();
