using LojaProdutosCurso.Services.Sessao;
using LojaSuplementos.Data;
using LojaSuplementos.Services.Autenticacao;
using LojaSuplementos.Services.Categoria;
using LojaSuplementos.Services.Estoque;
using LojaSuplementos.Services.Produto;
using LojaSuplementos.Services.Sessao;
using LojaSuplementos.Services.Usuario;
using LojaSuplementos.Utils.EncontrarVogal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();
builder.Services.AddScoped<IEstoqueInterface, EstoqueService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoInterface, AutenticacaoService>();
builder.Services.AddScoped<ISessaoInterface, SessaoService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSession(options => {
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api", (string input) => {

    ConsultarString consultarString = new ConsultarString();
    var result = consultarString.EncontrarVogal(input);

    return Results.Ok(JsonSerializer.Deserialize<object>(result));
}).WithSummary("Encontra a primeira vogal ")
.WithDescription("Encontra o primeiro caractere Vogal, após uma consoante, onde a mesma é antecessora a uma vogal e que não se repita na string."); ;


if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
