using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SolomikovPod;
using SolomikovPod.Services; // Ensure you have this using directive for your services
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add the main app component to the root
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with the base address of your API
// Replace "https://localhost:7079/api/" with the correct base address for your API project
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7079/api/") });

// Register your custom services for dependency injection
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

// Build and run the Blazor WebAssembly application
await builder.Build().RunAsync();
