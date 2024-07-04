using DroughtProject.Data;
using DroughtProject.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalHost5174, 3000, 5176",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http//localhost:5174",
                    "http//localhost:30000",
                    "http//localhost:5176"
                    
                )
                .AllowAnyMethod().AllowCredentials().AllowAnyHeader();
        });
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalHost5174, 3000, 5176");
app.MapControllers();
app.UseHttpsRedirection();

app.Run();