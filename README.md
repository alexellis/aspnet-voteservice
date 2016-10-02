# aspnet-voteservice
Full ASP.NET for Windows and SQL Server backend

This example demonstrates the following:

* ASP.NET WebAPI voting back-end on Windows Containers
* SQL 2016 on Windows Containers

* Node.js results app voting for Cats/dogs running on Windows Containers.

None of the applications in the new voting app would access a database directly whether SQL Server, mysql or postgres. The ASP.NET application acts as a gateway for for voting.

Caveats:

* Linking between containers is not working on Windows 10, so docker-compose.yml is of little use
* IP addresses have to be manually hard-coded into web.config for ASP.NET because IIS does not allow Application Pools to read system or machine level environmental variables.

Wins:

* Everything's on Windows Containers
* ASP.NET for Windows works fully without any need to port existing business applications to Mono or .NET Core
