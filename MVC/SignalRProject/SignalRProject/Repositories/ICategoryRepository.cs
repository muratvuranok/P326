using Microsoft.AspNetCore.SignalR;
using SignalRProject.Models;
using System.Data;
using System.Data.SqlClient;

namespace SignalRProject.Repositories;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll(); 
}

public class CategoryRepository : ICategoryRepository
{

    private readonly IConfiguration _configuration;
    private readonly IHubContext<SignalRServer> _signalRServerContext;
    public CategoryRepository(
        IConfiguration configuration,
        IHubContext<SignalRServer> signalRServerContext)
    {
        this._configuration = configuration;
        this._signalRServerContext = signalRServerContext;
    }



    public async Task<IEnumerable<Category>> GetAll()
    {
        //var cmd = string.Format(_configuration["SqlCommands:Categories:add"], "deneme", "denemememeeeee"); 
        // cmd = $"insert into Categories values ('{degisen}', '{degisen1}')"
        var categories = new List<Category>();

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("default"));
        if (connection.State == ConnectionState.Closed) connection.Open();
        SqlDependency.Start(_configuration.GetConnectionString("default"));

        SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
        SqlDependency dependency = new SqlDependency(command);
        dependency.OnChange += Dependency_OnChange;

        SqlDataReader dr = command.ExecuteReader();
        while (dr.Read())
        {
            Category category = new();
            category.Id = (int)dr["ID"];
            category.Name = dr["Name"].ToString();
            category.Description = dr["Description"].ToString();
            categories.Add(category);
        }

        return categories;
    }

   

    private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        _signalRServerContext.Clients.All.SendAsync("getCategories");
    }
     
}

