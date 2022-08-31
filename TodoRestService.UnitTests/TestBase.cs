using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoRestService.Models;

namespace TodoRestService.UnitTests
{
    public abstract class TestBase
    {
        protected TodoContext GetDbContext()
        {

            var options = new DbContextOptionsBuilder<TodoContext>()

             .UseMySql("server=localhost;userid=;password=;database=", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.25-mysql"))
             .Options;

            return new TodoContext(options);

        }
    }
}
