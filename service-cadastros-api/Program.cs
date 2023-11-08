using service_cadastros_application.Application;
using service_cadastros_application.Interfaces;
using service_cadastros_persistence.Context;
using service_cadastros_persistence.Interfaces;
using service_cadastros_persistence.Repositories;
using AutoMapper;
using service_cadastros_application.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Sample));
builder.Services.AddCors(delegate (CorsOptions options)
{
    options.AddPolicy("CorsPolicy", delegate (CorsPolicyBuilder policy)
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



//scopos
builder.Services.AddSingleton<IConnectionProvider, DbConnectionProvider>(cfg => new DbConnectionProvider());
builder.Services.AddScoped<ILoginApplication, LoginApplication>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IProdutoApplication, ProdutoApplication>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();








