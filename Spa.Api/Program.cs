using Spa.Infraestructure;
using Spa.Application;
using Spa.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraestructureService(builder.Configuration);
builder.Services.AddApplicationServiceCollection(builder.Configuration);

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()   
        .AllowAnyMethod()   
        .AllowAnyHeader()); 
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();  

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    options.RoutePrefix = string.Empty; 
});
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();

