using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_API.Services
{
    public abstract class BaseService
    {
        protected string _connectionString;

        protected BaseService(IConfiguration config, string csName) {
            _connectionString = config.GetConnectionString(csName);
        }
    }
}
