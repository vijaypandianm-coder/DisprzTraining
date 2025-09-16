using DisprzTraining.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using DisprzTraining.Converters; 

var builder = WebApplication.CreateBuilder(args);

// Add controllers with JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize enums as strings
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // Add custom converters for DateOnly & TimeOnly
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());

        // Keep property names as defined in the model (PascalCase)
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext for MySQL (Pomelo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Register DAL if used
builder.Services.AddScoped<IHelloWorldDAL, HelloWorldDAL>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS before other middleware
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DisprzTraining API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger at root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
