using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Creating DB");
    var appContext = scope.ServiceProvider.GetRequiredService<AppContext>();
    appContext.Database.EnsureCreated();;
    //context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api", () => "Awesome Leads Manager");
app.MapGet("/", () => "200 OK");

app.Run();
