using BlazorShop.Api.Context;
using BlazorShop.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages(); //Diese war der urhsprungcode von Blazor, Ich habe das Kommentiert und kopiert Magoratti's conde addControllers, add endPoint...

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefautConnection"));
});

builder.Services.AddScoped<IProductRepository, ProdutoRepository>();
builder.Services.AddScoped<IShopCarRepository, ShopCarRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Ursprungcode
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7110", "https://localhost:7110")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType)
);


app.UseHttpsRedirection();
//app.UseStaticFiles(); //Ursprungcode

//app.UseRouting(); //Ursprungcode

app.UseAuthorization();

app.MapControllers();

//app.MapRazorPages(); //Ursprungcode

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.Run();
