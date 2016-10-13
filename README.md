# Docker Voting App on Windows Containers

This solution ports the Docker Voting App to Windows Containers using an ASP.NET WebAPI project connected to SQL Server 2016 to submit and query votes.

### Architecture

![Windows Containers](http://blog.alexellis.io/content/images/2016/10/windows_containers.png)

This example demonstrates the following:

* ASP.NET WebAPI voting back-end on Windows Containers
* SQL 2016 on Windows Containers

* Node.js results app voting for Cats/dogs running on Windows Containers.

None of the applications in the new voting app would access a database directly whether SQL Server, mysql or postgres. The ASP.NET application acts as a gateway for for voting.

### Getting started video

Check out the video for a demo of launching and running the project:

http://blog.alexellis.io/docker-does-sql2016-aspnet/

Caveats:

* Linking between containers is not working on Windows 10, so start the containers manually and link with environmental variables etc. Linking via DNS does work on Windows 2016 Server - if you happen to have a VM handy.
* IP addresses have to be manually hard-coded into web.config for ASP.NET because IIS does not allow Application Pools to read system or machine level environmental variables. This will not be an issue once DNS linking works on Windows 10.

Wins:

* Everything's on Windows Containers
* ASP.NET for Windows works fully without any need to port existing business applications to Mono or .NET Core

