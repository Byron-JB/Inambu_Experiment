var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Inambu_Test_Web>("inambu-test");

builder.Build().Run();
