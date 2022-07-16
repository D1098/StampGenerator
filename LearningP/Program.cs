using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //StampInfoContext db = new StampInfoContext();
            //db.Add(new StampInfo("FIO_TEST")); //{ Reason="AAA", Time = DateTime.Now, StampGuid = Guid.NewGuid()});
            //db.SaveChanges();
            StampInfoContext db = new StampInfoContext();
            TestClass testClass = new TestClass { StampGuid = Guid.NewGuid() };
            db.Tests.Add(testClass);
            db.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
