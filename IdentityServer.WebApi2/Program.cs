using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
    {
        configureOptions.Authority = "https://localhost:7078";
        configureOptions.Audience = "resource_api2";
    });

builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("ReadPicture", policy =>
    {
        policy.RequireClaim("scope", "api1.read");
    });
    configure.AddPolicy("UpdateOrCreate", policy =>
    {
        policy.RequireClaim("scope", new[] { "api1.write", "api1.update" });
    });
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
