# Mars Rover

This project is an example of MarsRover using new technologies and best practices.


## Technologies

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [Mediatr](https://docs.microsoft.com/tr-tr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api)

## Practices

* Clean Code
* DDD (Domain-Driven Design)
* CQRS
* Logger
* Unit Test

## Run
 
#### Steps

1. Open **MarsRover.sln** directory in Visual Studio Code.
2. Set **MarsRover.Application** as startup project and Run.
3. Enter Plateau width and height . Example format 5 5
4. Enter Rover info. Example format 3 3 N
5. Enter Command info. Example format LMLMLMLMM

### The solution have three TestCase Project.

1. MarsRover.Scenario.Domain.Test project, we test only domain
2. MarsRover.Application.Test project, we test command handler and queries
3. MarsRover.Scenario.Tests project, we test general scenario test.

###Logger
Only use program class. because I want to explain on an interview.
