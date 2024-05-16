using Fintech.Application.Repositories;
using Fintech.Application.Services.Implementation;
using Fintech.Application.Services.Interface;
using Fintech.Infrastructure.Data;
using Fintech.Infrastructure.Helper;
using Fintech.Infrastructure.Repositories;
using Fintech.Server;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*var client = new BoltGraphClient(new Uri("neo4j+s://72c6518a.databases.neo4j.io"), "neo4j", "FBZnhbygrxjl1AJl7WrRgNLCNM7N6c0iaR2ydAARnuw");
client.ConnectAsync();
builder.Services.AddSingleton<IGraphClient>(client);*/

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));

builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<INeo4jRepository, Neo4jRepository>();
builder.Services.AddScoped<INeo4jDemoRepository, Neo4jDemoRepository>();
builder.Services.AddScoped<IFaqRepository, FaqRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

// Register Services
builder.Services.AddScoped<IFaqService, FaqServices>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
