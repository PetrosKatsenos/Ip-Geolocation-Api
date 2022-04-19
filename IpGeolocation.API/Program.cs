using CommonLibraries;
using CommonLibraries.Interfaces;
using IpGeolocation.Core.DataAccess;
using IpGeolocation.Core.DataAccess.Interfaces;
using IpGeolocation.Core.Services;
using IpGeolocation.Core.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IHttpHelper, HttpHelper>();
builder.Services.AddTransient<IGeolocationApiService, GeolocationApiService>();
builder.Services.AddTransient<IGeolocationsCollectionRepository, GeolocationsCollectionRepository>();
builder.Services.AddTransient<IGeolocationsCollectionService, GeolocationsCollectionService>();


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

    //app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1")); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
