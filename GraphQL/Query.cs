using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseFiltering, UseSorting]
        public IQueryable<Platform> GetPlatform(AppDbContext context)
        {
            return context.Platforms;
        }

        [UseFiltering, UseSorting]
        public IQueryable<Command> GetCommand(AppDbContext context)
        {
            return context.Commands;
        }
    }
}