using DroughtProject.Data;
using DroughtProject.Repositories;
using DroughtProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
    options.AddPolicy(name: "AllowLocalHost5173", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
            .AllowAnyMethod().AllowCredentials().AllowAnyHeader();
    });
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<SequiaDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowLocalHost5173");
app.MapControllers();
app.UseHttpsRedirection();

app.Run();