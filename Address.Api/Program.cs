using System.Reflection;
using Address.Api.Configurations;
using Address.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection(""));

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AddressRequester", configurePolicy =>
	{
		configurePolicy.RequireClaim(ClaimConstants.Scope, "addressrequester.access");
	});
});

//builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddAppConfiguration(builder.Configuration);
builder.Services.AddLoggingService();
builder.Services.AddDataService();

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Address Check API",
		Description = "API to Check Addresses",
		Contact = new OpenApiContact
		{
			Name = "ArgO492",
			Email = String.Empty,
			Url = new Uri("https://twitter.com/url"),
		},
		License = new OpenApiLicense
		{
			Name = "Use under MIT"
		}
	});

	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the bearer scheme"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			Array.Empty<string>()
		}
	});
});

var BagAPIkey = builder.Configuration["AddressApi.BagApiKey"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	await app.MigrateDatabase();
    app.UseSwagger();
    app.UseSwaggerUI();
	
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
