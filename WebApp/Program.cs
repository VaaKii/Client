using System.Globalization;

namespace WebApp;

public class Program
{
  public static void Main(string[] args)
  {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

    CreateHostBuilder(args)
      .Build()
      .Run();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) => Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}