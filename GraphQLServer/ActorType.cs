using DataGenerator;
using GraphQL.Types;

namespace GraphQLServer
{
    public class ActorType : ObjectGraphType<Person>
    {
        public ActorType()
        {
            Name = "Actor";

            Field(h => h.Id, nullable: true).Description("The id of the person.");
            Field(h => h.FullName).Description("The name of the person.");
            Field(h => h.Email, nullable: true).Description("The email of the person.");
            Field(h => h.BirthDate, nullable: true).Description("The birth date of the person.");
        }
    }
}
