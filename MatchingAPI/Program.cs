using MatchingAPI.Data;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using MatchingAPI.Services;
using MatchingAPI.StoreProcedure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string ConnectionString = string.Empty;
builder.Services.AddControllers();

ConnectionString = builder.Configuration.GetConnectionString("PeopleDeskARLConnection");

builder.Services.AddDbContext<iBOSDDDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("iBOSDDDConnection")));

builder.Services.AddDbContext<PeopleDeskContext>(options => options.UseSqlServer(ConnectionString));
Connection.PeopleDeskARLConnection = ConnectionString;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmployeeService,EmployeeService>();
builder.Services.AddTransient<IProfileInfo, ProfileInfo>();
builder.Services.AddTransient<IPreferenceInfo, Preference>();
builder.Services.AddTransient<ISucbcriptionPlan, SucbcriptionPlan>();
builder.Services.AddTransient<IUserProfileInformation, UserProfileInformation>();
builder.Services.AddTransient<IGeneralLedger, GeneralLedger>();
builder.Services.AddTransient<IBusinessTransaction, BusinessTransaction>();
builder.Services.AddTransient<ICashJournal, CashJournal>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
