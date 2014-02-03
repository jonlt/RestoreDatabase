﻿# Restore Database

Small tool meant to make it (a lilte bit) easier to resore a .bak file to a database.

![screenshot](screenshot.png)

## Fields

* `Selected File`: The .bak file to restore.
* `Server`: The Sql server to restore the file on.
* `User`: If provided, the username to user to login to the Sql server.
* `Password`: If provided, the password to use to login to the Sql server.
* `Database Name`: The name of the new database.
* `Original Database Name`: If provided the name of the database in the .bak file, to restore. If nothing is provided the name of the file is used.
* `Database file location`: The location of the .mdf files on the system that is running the database server.
* `SQL`: The resulting Sql that is used to restore the database file.

If no credentials are provided, `Integrated Security` is used (i.e. the user that is running the tool is used a credentials for the Sql server)

## Features:

The main feature is to restore backups from .bak files. But the tool does a few other tings:

### Manage Permissions

If the Sql server service does not have permission to the file that you are pointing to, the tool can create a `Read` permission:

![screenshot-permission](screenshot-permission.png)

### Override Existing Database Files

The tool checks if the database file already exists on the system, and promts you to choose if you want to override the existing file:

![screenshot-replace](screenshot-replace.png)

### Automatic Database Naming

The tool asumes that the name of the selected .bak file, is the same as the database inside the .bak file. If this is not the case the tool promts you to specify the correct name (this is what the `Original Database Name` field is for):

![screenshot-badname](screenshot-badname.png)
