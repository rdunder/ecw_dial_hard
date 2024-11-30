// See https://aka.ms/new-console-template for more information
using Lib.Main.Services.Services;

Console.WriteLine("Hello, World!");


UserService userService = new();
userService.Print();