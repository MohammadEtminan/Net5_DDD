namespace DDD.ProjectDescription
{
    internal class Description
    {
        #region [-  Step 1: Create SolutionFolders Based on DDD Architecture -]
        //01_PeresentationLayer
        //02_ApplicationLayer
        //03_DomainLayer
        //04_Infrastructure
        #endregion

        #region [-  Step 2: Adding Domain Layer projects -]

        #region [- Create ContractProject of the Domain Layer -]
        //  1-Project.Domain.Contract(Repository DesignPattern)
        //	1.1-Create IRepository interface 
        // 	1.2-Create all database tasks in the interface
        // 	1.3-Create SaveChanges() in the interface
        #endregion

        #region [- Create Domain of the Solution -]
        //2-Create Project.Domain
        //	2.1-AddRef[Project.Domain.Contract]
        //	2.2-Create project inner layers:
        //		1-Frameworks,2-Aggregates,3-Repositories,4-Factories
        //	2.3-Create IEntity in Frameworks/Abstracts
        //	2.4-Create Entity class in Frameworks/Bases
        //	2.5-Create Person AggregateRoot in Aggregates
        //	2.6-Install TanvirArjel.Extension.DependencyInjection  by nuget
        //	2.7-Create IPersonRepository  in Repositories with  [ScopedService] attribute
        //	2.8-Create PersonFactoryService in Factories for FactoryDesignPattern 
        #endregion

        #endregion

        #region [- Step 3: Create Infrastructure Layer projects -]

        //	1-Project.EntityFrameworkCore
        //		1.1-Create project inner layers:
        //			1-Frameworks,2-Configurations,3-Services
        //		1.2-AddRef[Project.Domain]
        //		1.3-Install Identity packages for EFCore by nuget
        //		    [Microsoft.AspNetCore.Identity.EntityFrameworkCore]
        //		    [Microsoft.EntityFrameworkCore]
        //		    [Microsoft.EntityFrameworkCore.Tools]
        //		    [Microsoft.EntityFrameworkCore.Design]
        //		    [Microsoft.EntityFrameworkCore.SQLServer]
        //		1.4-Create DbContext class [ProjectDbContext]
        //		1.5-Create PersonConfiguration class for FluentApi config
        //		1.6-Create BaseRepository class for Implementing tasks
        //		1.7-Create PersonRepository class for Implementing BaseRepository tasks & IPersonRepository tasks
        //		1.8- Add-Migration init
        //		1.9- Update-Database 

        #endregion

        #region [- Step 4: Create Application Layer projects -]

        #region [- 1-Project.Application.Contract ==> for Application Dto & all other Application contracts -]
        //  1.1-Create project inner layers:
        //			1-Abstracts,2-Base		
        //	1.2-Create IPersonDto in Abstracts/Dtos 
        //	1.3-Create PersonBaseDto in Base/Dtos
        #endregion

        #region [- 2- Project.Application -]
        //		2.1-Create project inner layers:
        //			1-Abstracts,2-Dtos,3-Profiles,4-Services
        //		2.2-Install TanvirArjel.Extension.Microsoft.DependencyInjection  by nuget
        //		2.3-Install AutoMapper.Extension.Microsoft.DependencyInjection by nuget
        //		2.4-AddRef[Project.Domain]
        //		2.5-AddRef[Project.Application.Contract]
        //		2.6-Create IPersonAppService in Abstracts for IOC
        //		2.7-Create PersonDto for Get Flow in Dtos
        //		2.8-Add up GetAsync(Guid id) & GetListAsync() in IPersonAppService
        //		2.9-Create CreatePersonDto for Post Flow in Dtos
        //		2.10-Add up CreateAsync(CreatePersonDto input) in IPersonAppService
        //		2.11-Create UpdatePersonDto for Put Flow in Dtos
        //		2.12-Add up UpdateAsync(Guid id, UpdatePersonDto input) in IPersonAppService
        //		2.13-Create AutoMapperProfile in Profiles
        //		2.14-Create PersonAppService in Services
        #endregion

        #endregion

        #region [- Step 5: Adding Presentation Layer projects -]
        //	1-Project.WebApi
        //		1.1-Create project inner layers:
        //			1-Middlewares
        //		1.2-Install Newtonsoft.json by nuget
        //		1.3-Install TanvirArjel.Extension.Microsoft.DependencyInjection by nuget
        //		1.4-Install AutoMapper.Extension.Microsoft.DependencyInjection by nuget
        //		1.5-Install EFCore.Design by nuget
        //		1.6-Install EFCore.SQLServer by nuget
        //		1.7-Install EFCore.Tools by nuget
        //		1.8-AddRef[Project.Application] & [Project.EntityFrameworkCore]
        //		1.9-Set up the ConnectionStrings in appsettings.json
        //		1.10-Create ApiExceptionHandler in Middlewares
        //		1.11-Config Startup.cs as EndPoint Headquarters
        //		1.12-Add up Services in request piple line in ConfigureServices():
        //			1-MVCCore
        //			2-DbContext
        //			3-AutoMapper
        //			4-Controller
        //			5-SwaggerGen
        //			6-AddServicesOfAllTypes()
        //			7-AddServicesWithAttributeOfType<ScopedServiceAttribute>()
        //		1.13-Add up Middlewares in request piple line in Configure():
        //            A-Development:
        //				1-OpenApi
        //				2-UseSwaggerUi3
        //				3-UseDeveloperExceptionPage
        //            B-RunTime:
        //				1-ApiExceptionMiddleware
        //            c-UseRouting()
        //            D-UseEndpoints()
        //		1.14-Create PersonController
        //		1.15-Create HttpVerbs
        //		1.16-Migrate & Update Database
        //		1.17-Run the Project
        #endregion
    }
}