using OrstedRestAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddCors(options => options.
AddPolicy("MyAllowSpecificOrigins", d => d.WithOrigins("http://localhost:3000").AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("MyAllowSpecificOrigins");

app.Run();
