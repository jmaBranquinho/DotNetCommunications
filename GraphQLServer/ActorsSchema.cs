using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQLServer
{
    public class ActorsSchema : Schema
    {
        public ActorsSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<ActorQuery>();
        }
    }
}
