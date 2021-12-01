using APIAuthorizeFrontend;
using System;

AuthConfig config = AuthConfig.ReadFromJsonFile("appsettings.json");

Console.WriteLine($"Authority: {config.Authority}");
