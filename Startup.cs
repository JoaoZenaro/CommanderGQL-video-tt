using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework#dbcontextkindpooled

            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnStr")
            ));

            services
                .AddGraphQLServer()
                .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddFiltering()
                .AddSorting()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGraphQLVoyager("graphql-voyager");
            });
        }
    }
}