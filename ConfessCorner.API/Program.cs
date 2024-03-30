using ConfessCorner.Core.Domain.RepositoryContracts;
using ConfessCorner.Core.ServiceContracts;
using ConfessCorner.Core.Services;
using ConfessCorner.Infrastructure.Context;
using ConfessCorner.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));
});

builder.Services.AddScoped<IConfessionsRepository, ConfessionsRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();

builder.Services.AddScoped<IConfessionsService, ConfessionsService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("prod"));
}, ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
        .WithOrigins(builder.Configuration.GetValue<string>("AllowedOrigin"))
        .WithHeaders("Origin", "Content-type")
        .WithMethods("GET", "POST");
    });
});

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors();

app.MapControllers();

app.Run();
