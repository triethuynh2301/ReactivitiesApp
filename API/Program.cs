using Api;
using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// add dependency injection from other projects
builder.Services.AddPresentation()
                .AddApplication()
                .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
