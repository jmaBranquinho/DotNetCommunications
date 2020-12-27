# DotNetCommunications

tech used:

Bogus: generate fake data
Help: https://github.com/bchavez/Bogus

gRpc: service-service communication example
To test start both GrpcServer (first) and GrpcClient (after) and check the client's console 

graphQL: client-server communication 
To test open the playground (if unchanged it is set to: http://localhost:3000/ui/playground). Check the schema and type the query into the playground.
Help: https://graphql.org/learn/queries/
Example:
//search in the context for an actor contaiting the name "". Since I'm using Bogus no real search is being made. Returns the fullname and email of the actor found
{
  actor(fullName: "") {
    email,
    fullName
  }
}

