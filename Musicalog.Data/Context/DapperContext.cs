using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Musicalog.Data.Context;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
    }

    public IDbConnection CreateMasterConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("MasterConnection"));
    }
}