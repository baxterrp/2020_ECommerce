# 2020_ECommerce

to run you must 
1) have .net core 3.1 sdk installed https://dotnet.microsoft.com/download
2) have sql server https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver15
3) run command 
> CREATE DATABASE eComm;
4) modify ConnectionConfiguration section in appsettings.json in directory ~/BaxterCommerce.Web/
    ```
    DataSource : your sql server name
    Catalog : name of database you intend to use - should be eComm
    IntegratedSecurity : leave as True
    ```
to build application

in root directory
> dotnet build BaxterCommerceWebApi.sln

to run application
navigate to ~/BaxterCommerce.Web/bin/debug/netcoreapp3.1/
> dotnet BaxterCommerce.Web.dll
