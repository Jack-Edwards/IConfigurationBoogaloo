using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace TestProject1;

[TestFixture]
public class Tests
{
    private WebApplicationFactory<Program>? factory;
    
    [SetUp]
    public void Setup()
    {
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;

        DirectoryInfo directory = new DirectoryInfo(assemblyLocation);
        do
        {
            directory = directory.Parent ?? throw new Exception("Directory has no parent.");
        } while (directory.Name != Assembly.GetExecutingAssembly().GetName().Name);
        
        string testSettings = Path.Join(directory.Parent!.FullName, "TestProject1", "appsettings.Test.json");
        if (!Path.Exists(testSettings))
        {
            throw new FileNotFoundException("Failed to find ./TestProject1/appsettings.Test.json.");
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile(testSettings)
            .Build();
        
        factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder
                    .UseConfiguration(configuration)
                    .UseEnvironment("Test");
            });
    }

    [Test]
    public async Task Test1()
    {
        var client = factory!.CreateClient();
        await client.GetAsync("weatherforecast");
        Assert.Pass();
    }
}