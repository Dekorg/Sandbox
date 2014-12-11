BaseWindowsService
=======

This base windows service is a good starting point for a windows service that needs to run a task on a predetermined interval. The service provides a safe shut down process that allows tasks to complete when the stop command is issued.

The service also has a few handy switches such as debug mode, and auto install/uninstall.

To get started, simply inherit from BaseWindowsService, implement the constructor and override the DoYourMagic(string[] args) method which is your code that will be executed on the defined inteval.

In you app.config, you can define the value for ActionSleep which is the interval in ms in which you code will execute and the StopServiceWait which is the value in ms of how long you are willing to wait before the service stops when the stop command is issued.

Handy argument switches:

MyWindowsService.exe DEBUG - Runs as a console app for debugging.
MyWindowsService.exe I -Installs the service using SC.exe CREATE.
MyWindowsService.exe U -Uninstalls the service using SC.exe DELETE.