using DokanDar.Application.IServices.DBServices;
using DokanDar.Infrastructure.Context;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Services.DBServices
{
    public class ProcedureService : IProcedureService
    {

        private readonly DokanDbContext _context;

        public ProcedureService(DokanDbContext context)
        {
            _context = context;
        }

        public DataSet GetDataWithParameter(object parameterName, string procedureName)
        {
            var connectionString = _context.Database.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                var paramDictionary = new RouteValueDictionary(parameterName);
                var sqlParameters = string.Join(", ", paramDictionary.Select(p => $"@{p.Key} = '{p.Value}'"));

                using (var command = new SqlCommand($"EXEC {procedureName} {sqlParameters}", connection))
                {
                    connection.Open();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
        }

        public DataSet GetDataWithoutParameter(string procedureName)
        {
            var connectionString = _context.Database.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"EXEC {procedureName}", connection))
                {
                    connection.Open();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
        }
    }
}
