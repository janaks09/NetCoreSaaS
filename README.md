# NetCoreSaaS
Asp.Net Core multi-tenant application Sample using #SaaSKit

## .Net 6.0 Support!!!
This application is upgraded to support .Net 6.0.

## Known Issue
Currently `HTTPS` redirection is not supported.

## Application Architecture
Nothing Complex.

I followed separate database per tenant approach.

In `NetCoreSaaS.Data` project, there are two different contexts. 
+ `CatalogDbContext` holds global tenant level data like tenant configuration
+ `TenantDbContext` holds tenant specific data like tenant user, other tenant related data

## Steps to run application
+ Create migration file if not created (but its already created under `Data` folder of `NetCoreSaaS.WebHost`). If you want to re-create migration later check `TempFiles` folder in `NetCoreSaaS.WebHost` for migration scripts. Run `Catalog Database` migration only.
+ Run application. Application will itself migrate changes to database with seeding in `NetCoreSaaS_Catalogdb` with tenant data.
+ For testing purpose, I have configure application to listen request in host `http://*.localhost:6001` (you can find configuration in `Program.cs` file.) Default seeding has only added two tenant which hostname are `http://tenant1.localhost:6001` and `http://tenant2.localhost:6001`  therefore request from only these two hostname will be resolved else tenant will not resolve. You can find seeding in `NetCoreSaaS.WebHost > Infrastructures > Helpers > DbHelper` folder.
+ Once application is running, go to `http://tenant1.localhost:6001` and `http://tenant2.localhost:6001` you can find same site for two tenant.
+ You can also perform user signup and login operation with these tenants.
