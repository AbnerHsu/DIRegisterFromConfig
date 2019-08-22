using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace DIRegisterFromConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(GetContainer())
                .UseStartup<Startup>();

        private static IUnityContainer GetContainer()
        {
            var unitySection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            Dictionary<string, IUnityContainer> containers = new Dictionary<string, IUnityContainer>();
            InitiateContainers(unitySection, containers);
            return containers.Values.First();
        }

        private static void InitiateContainers(UnityConfigurationSection unitySection, Dictionary<string, IUnityContainer> containers)
        {
            foreach (var element in unitySection.Containers)
            {
                string name = string.IsNullOrEmpty(element.Name) ? "Default" : element.Name;
                if (!containers.ContainsKey(name))
                {
                    containers.Add(name, new UnityContainer());
                }
                unitySection.Configure(containers[name], element.Name);
            }
        }
    }
}
