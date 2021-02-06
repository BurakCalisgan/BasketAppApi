# ToDoApi

## Architectural Approaches
 * Clean Architecture, details: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
 * CQRS, details: https://martinfowler.com/bliki/CQRS.html#:~:text=CQRS%20stands%20for%20Command%20Query,you%20use%20to%20read%20information.
 * Mediatr, details: https://refactoring.guru/design-patterns/mediator
 * Event handling demostration for microservices.

## How To Run
 * It is a Swagger implemented api, so when you run the application swagger page will ve opened. You can check out the endpoints.
 * I used SQLite to prevent any database connection problems, it is in persistence layer and there are already some records. If you want to take it from the top, delete the .db file and run **dotnet ef database update** at persistence layer.
 
## Task Notes
 * I haven't built any ui because you are testing me for my backend skills. As Şifa said, there will be frontend developers. If you really want to know how I code frontend, we can do it pair online, It would be fun :). 
 * As you know the task is piece of cake, so I tried to apply some good architecture and demonstration of a microservice. I capsulated business, publish events and logging. I would do more but I think that is enough, we can talk the rest.
 
 ### Harun Reşit Heybet
