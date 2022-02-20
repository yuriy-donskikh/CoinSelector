const string CORS_POLICY = "default";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddCors(context =>
        {
            context.AddPolicy(CORS_POLICY, options =>
            {
                options
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            });
        })
        .AddDbContextPool<CoinDbContext>(o =>
        {
            var connectionSting = builder.Configuration.GetConnectionString("CoinDbConnection");
            if (string.IsNullOrEmpty(connectionSting))
            {
                o.UseInMemoryDatabase("CoinDb");
            }
            else
            {
                o.UseSqlServer(connectionSting);
            }
        })
        .AddAutoMapper(typeof(MapperProfile))
        .AddTransient<ISeeder, SeederService>()
        .AddTransient<IGetUserService, UserService>()
        .AddTransient<ISetUserService, UserService>()
        .AddTransient<IPricesProxyService, PricesProxyService>()
        ;

builder.Services.AddRefitClient<IThirdPartyPrices>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["priceUrl"]));
    


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seader = scope.ServiceProvider.GetRequiredService<ISeeder>();
    await seader.Seed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseCors(CORS_POLICY)
    .UseAuthorization();

app.MapControllers();

await app.RunAsync();
