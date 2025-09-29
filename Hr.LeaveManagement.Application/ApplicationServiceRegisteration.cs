using Hr.LeaveManagement.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Hr.LeaveManagement.Application
{
    public static class ApplicationServiceRegisteration
    {
        //An extention method to > Service > Service.ConfigureApplicationService()
        //Service is the DI container it is ServiceCollection type
        public static void ConfigureApplicationService(this IServiceCollection service)
        {
            //    service.AddAutoMapper(typeof (MappingProfile)); //explicitly add a specific profile.

              service.AddAutoMapper(Assembly.GetExecutingAssembly());  //scan the whole assembly (project) for all profiles automatically.

        }
    }
}

# region Explaination
/*
 1️⃣ service

This is your DI container (IServiceCollection).
You’re saying: “Hey DI, please add AutoMapper to my services.”

2️⃣ AddAutoMapper(...)

This method comes from the AutoMapper.Extensions.Microsoft.DependencyInjection package.

It registers AutoMapper in DI so you can inject IMapper anywhere in your app.

But AutoMapper needs to know:
👉 Where are my mapping rules (Profiles)?

3️⃣ Assembly.GetExecutingAssembly()

This is just a reflection trick in .NET.

Assembly = a loaded project (DLL/exe).

GetExecutingAssembly() = the current project where this code is running.

So here you’re saying:
👉 “AutoMapper, scan this assembly (my Application layer) and look for all classes that inherit from Profile (your mapping rules).”

4️⃣ Putting it all together

That line means:

👉 “Register AutoMapper as a service, and load all mapping profiles from this project automatically.”
 */
#endregion
