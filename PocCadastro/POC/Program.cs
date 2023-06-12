using POC.Factories;
using POC.Service;
using POC.Service.Cadastro;
using POC.Service.Cadastro.Regras;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<ICadastroServiceFactory, CadastroServiceFactory>();

#region Portal

builder.Services.AddScoped<IUsuarioCadastroPortalService, CadastrarUsuarioPersistenciaService>();
builder.Services.Decorate<IUsuarioCadastroPortalService, CadastrarUsuarioEnriquecimentoService>();
builder.Services.Decorate<IUsuarioCadastroPortalService, CadastrarUsuarioValidacaoService>();

#endregion

#region Chatbot

builder.Services.AddScoped<IUsuarioCadastroChatbotService, CadastrarUsuarioPersistenciaService>();
builder.Services.Decorate<IUsuarioCadastroChatbotService, CadastrarUsuarioValidacaoService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Portal
// Validação dos dados
// Assinar termo de uso
// Enriquecimento
// Realizar Pre cadastro (Envia link de confirmação)

//SSN
// Validação dos dados
// Assinar termo de uso
// Realizar cadastro

// ---------------------

// Confirmação de cadastro
// Realizar cadastro