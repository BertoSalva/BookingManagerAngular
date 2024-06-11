using System.Text.Json.Serialization;
using gateway;
using gateway.Filters;
using gateway.Mailer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Uncomment if you need to handle JSON reference cycles
// .AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
// });

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Adjust this to match your Angular app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();  // Allow credentials if necessary
        }
    );
});

builder.Services.AddScoped<ExceptionFilter>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<BookingDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // Use CORS here before UseAuthorization

app.UseAuthorization();

app.UseExceptionHandler("/error");

// app.UseExceptionHandler(errorApp =>
// {
//     errorApp.Run(async context =>
//     {
//         // Your custom exception handling logic here
//         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//         context.Response.ContentType = "application/json";
//         await context.Response.WriteAsync("An unexpected error occurred.");
//     });
// });

app.MapControllers();

app.Run();
