using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SolomikovPod;
using SolomikovPod.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Регистрация компонентов
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Конфигурация HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7079/api/") });

// Регистрация сервисов
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserStateService>();


await builder.Build().RunAsync();
