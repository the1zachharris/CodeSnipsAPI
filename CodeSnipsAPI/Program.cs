using CodeSnipsAPI.DbContexts;
using Microsoft.AspNetCore.StaticFiles;
using CodeSnipsAPI.Services;
using CodeSnipsAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// use dependency injection to register EncryptUtility as a Singleton service to be created once and used across the application when needed
builder.Services.AddSingleton<EncryptUtility>();
// add IdentityService for basic auth
//builder.Services.AddSingleton<IdentityService>();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

builder.Services.AddDbContext<UserInfoContext>();

builder.Services.AddScoped<ISnippetInfoRepository, SnippetInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options => options.AddPolicy(name: "ArticleGenerator",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ArticleGenerator");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();