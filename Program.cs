using DotRest2.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IItemRepository, MemoryItemRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  //  app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
