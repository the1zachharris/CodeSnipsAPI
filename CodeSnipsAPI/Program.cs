using CodeSnipsAPI.DbContexts;
using Microsoft.AspNetCore.StaticFiles;
using CodeSnipsAPI.Services;
using CodeSnipsAPI.Utilities;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// use dependency injection to register EncryptUtility as a Singleton service to be created once and used across the application when needed
builder.Services.AddSingleton<EncryptUtility>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuth0WebAppAuthentication(options =>
{
	IConfigurationSection auth0Config = builder.Configuration.GetSection("Auth0");

	options.Domain = auth0Config["Domain"] ?? throw new Exception("Missing 'Domain' setting in Auth0 configuration");
	options.ClientId = auth0Config["ClientId"] ?? throw new Exception("Missing 'ClientId' setting in Auth0 configuration"); ;
	options.ClientSecret = auth0Config["ClientSecret"] ?? throw new Exception("Missing 'ClientSecret' setting in Auth0 configuration"); ;
	options.Scope = "openid profile email";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();