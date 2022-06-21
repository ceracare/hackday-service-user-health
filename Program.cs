using System.Data.SqlClient;
using serviceUserHealth.Data;
using serviceUserHealth.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "QA Rangers!");

//app.MapGet("/riskscore/123/trend", () =>
//{
//    var visitScores = new List<VisitScore>();
//    //to get the connection string 
//    var _config = app.Services.GetRequiredService<IConfiguration>();
//    var connectionstring = _config.GetConnectionString("DefaultConnection");
//    //build the sqlconnection and execute the sql command
//    using (SqlConnection conn = new SqlConnection(connectionstring))
//    {
//        conn.Open();
//        string commandtext = "select Id, VisitId from dev_riskscore.visit_score";

//        SqlCommand cmd = new SqlCommand(commandtext, conn);

//        var reader = cmd.ExecuteReader();

//        while (reader.Read())
//        {
//            var visitScore = new VisitScore()
//            {
//                Id = new Guid(),
//                VisitId = new Guid()
//            };

//            visitScores.Add(visitScore);
//        }
//    }
//    return visitScores;
//});

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

