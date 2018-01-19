# NetCoreSaaS
Asp.Net Core multi-tenant application Sample using #SaaSKit

## .Net Core 2.0 Support!!!
This application is upgraded to .Net Core 2.0. You can find latest releases for both .Net Core 1.x and .Net Core 2.0 in release tab.

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
+ For testing purpose, I have configure application to listen request in host `http://*.localhost:6001` (you can find configuration in `Program.cs` file.) Default seeding has only added two tenant which hostname are `http://tenant1.localhost:6001` and `http://tenant2.localhost:6001`  therefore request from only these two hostname will be resolved else tenant will not resolve. You can find seeding in `NetCoreSaaS.WebHost > Infrastructures > Helpers > DbHelper` folder.
+ Once application is running, go to `http://tenant1.localhost:6001` and `http://tenant2.localhost:6001` you can find same site for two virtual shop(tenants).
+ You can also perform user signup and login operation with these tenants.

More feature and documentation are comming...
