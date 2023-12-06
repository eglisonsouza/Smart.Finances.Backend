using Smart.Finances.IoC;
using Smart.Finances.IoC.Config;
var AnyOriginCors = "AnyOriginCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettingsConfig(builder.Configuration);
builder.Services.AddInfraestructureApi(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureJwt();
builder.Services.AddCorsConfig(AnyOriginCors);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(AnyOriginCors);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
