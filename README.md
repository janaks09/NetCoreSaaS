# NetCoreSaaS
Asp.Net Core multi-tenant application Sample using #SaaSKit

## Application Architecture
Nothing Complex.

I followed separate database per tenant approach.

In `NetCoreSaaS.Data` project we have three different context. 
+ `SystemDbContext` holds application/system level data
+ `CatalogDbContext` holds tenant level data like tenant configuration
+ `TenantDbContext` holds tenant specific data like tenant user, other tenant data

## Steps to run application
+ Create migration file if not created (but its already created under `Data` folder of `NetCoreSaaS.WebHost`). If you want to re-create migration later check `TempFiles` folder in `NetCoreSaaS.WebHost` for migration scripts. Run `System Database` and `Catalog Database` migration only.
+ Run application. Application will itself migrate changes to database with seeding in `NetCoreSaaS_Catalogdb` with tenant data.
+ For testing purpose, I have explicitly configure application to run in two port (6001, 6002 you can find configuration in `Program.cs` file.) Also default seeding support request from those two port only else tenant will not resolve.
+ Once you run application you can go to `http://localhost:6001` and `http://localhost:6002` you can find same site for two virtual shop(tenants).

More documentation comming soon...
