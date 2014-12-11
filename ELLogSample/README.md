My Enterprise Library Default Logging Configuration
=======
Install EL6+, replace the following place holders and you are good to go.

[company]
[app]
[env]
[smtp]
[toaddress]
[fromaddress]

Defaults to rolling file only Information level for Debug. All other environments e-mail on Error level, and log to the Event Logs on Warning.

Logs roll at 10mb and keeps the last 25.

Make sure to create your Sources and Logs for the Event Logs to work!
