# Restore Database

Small tool meant to make it (a lilte bit) easier to resore a .bak file to a database.

![screenshot](screenshot.png)

## Fields

* `Selected Files`: The .bak files to restore.
* `Server`: The Sql server to restore to.
* `DB login Credentials`: If provided, credentials to login to the server with.
* `Database Name`: The name of the new database.
* `Original Database Name`: If provided the name of the database in the .bak file, to restore. (automatically detected)
* `New login Credentials`: If provided, this is used to create a new login for the database, on the server.
* `Database file location`: The location of the .mdf files on the system that is running the database server. (automatically detected)
* `SQL`: The resulting Sql that is used to restore the database file.

If no login credentials are provided, `Integrated Security` is used.

## Features:

The main feature is to restore backups from .bak files. But the tool does a few other tings:

### Manage Permissions

If the Sql server service does not have permission to the file that you are pointing to, the tool can create a `Read` permission:

![screenshot-permission](screenshot-permission.png)

### Override Existing Database Files

The tool checks if the database file already exists on the system, and promts you to choose if you want to override the existing file:

![screenshot-replace](screenshot-replace.png)
