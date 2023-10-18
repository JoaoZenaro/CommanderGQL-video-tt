using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Subscription
    {
        [Topic, Subscribe]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}