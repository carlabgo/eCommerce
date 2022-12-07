
using eCommerce.DataModel;
using eCommerce.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceDB"));
});

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();
