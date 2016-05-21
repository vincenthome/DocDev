#Topshelf

A Windows service framework for the .NET platform. 
Topshelf makes it easy to create a Windows service, test the service, debug the service, and ultimately install it into the Windows Service Control Manager (SCM). 

When a developer uses Topshelf, creating a Windows service is as easy as creating a console application. Once the console application is created, the developer creates a single service class that has public Start and Stop methods. With a few lines of configuration using Topshelf’s configuration API, the developer has a complete Windows service that can be debugged using the debugger (yes, F5 debugging support for services) and installed using the Topshelf command-line support.

##Nuget: Topshelf

[http://topshelf-project.com/](http://topshelf-project.com/)

##Customize Project/Code:
    1. rename assembly: Project -> Properties -> AssemblyName -> "MyTopShelf" to "Something else"
    2. set service name, display name, description

[http://docs.topshelf-project.com/en/latest/overview/commandline.html](http://docs.topshelf-project.com/en/latest/overview/commandline.html)

##Install:

    MyTopShelf.exe install

##Uninstall:

    MyTopShelf.exe uninstall
