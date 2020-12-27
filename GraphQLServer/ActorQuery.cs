using GraphQL;
using GraphQL.Types;

namespace GraphQLServer
{
    public class ActorQuery : ObjectGraphType<object>
    {
        public ActorQuery(MovieActorsData data)
        {
            Name = "Query";

            var partialActorName = "";//part of the name of the person/actor or nothing for any actor
            //Field<ActorType>("actor", resolve: context => data.GetPersonByNameAsync(partialActorName));
            Field<ActorType>(
                "actor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "fullName", Description = "part of the name of the actor (or empty for any)" }
                ),
                resolve: context => data.GetPersonByNameAsync(context.GetArgument<string>("fullName"))
            );
        }
    }
}
