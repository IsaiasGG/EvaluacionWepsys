using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApiPersona.Entities;
using WebApiPersona.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddDbContext<ApiDbContext>();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WEB API",
        Version = "v1"
    });
});
//Enable CORS
builder.Services.AddCors(c => {
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//JSON Serializer
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
        c.DocumentTitle = "WEB API";
        c.DocExpansion(DocExpansion.List);
    });
    app.UseDeveloperExceptionPage();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
