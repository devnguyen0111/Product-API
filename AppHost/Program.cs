var builder = DistributedApplication.CreateBuilder(args);

// Add services to the container.
builder.AddProject<Projects.ProductAPI>("product-api");

builder.Build().Run();
