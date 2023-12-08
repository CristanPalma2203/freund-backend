using Infrastructure.Data;
using Infrastructure.Filters;
using WebApi.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//extras

builder.Services.AddHandlers();
builder.Services.AddMappers();
builder.Services.AddContextConfiguration(builder.Configuration);
builder.Services.AddScoped<UnitOfWorkFilter>();
builder.Services.AddCorsConfig();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddCors();
builder.Services.AddControllersWithViews(option =>

        option.Filters.Add(typeof(UnitOfWorkFilter))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("ApiCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
