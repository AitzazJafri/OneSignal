


# OneSignalApp
Asp.net MVC OneSignal for App create,view and update

## Do Not Forget 
Change connection string in web.config to run this project.

1. replace {Server-Name} with your server name.
2. replace {User-ID} with your user id.
3. replace {Password} with your password.

```

<add name="DefaultConnection" connectionString="Data Source={Server-Name};Initial Catalog=OneSignalAssignment;user id={User-ID};password={Password};MultipleActiveResultSets=True;" providerName="System.Data.SqlClient"/>

```
## After Running
Two roles will be created automatically in db
1. Admin
2. DEO (Data Entry Operator)

 Two users also will be created agains each role
 ### 1. admin@mail.com (**ADMIN**)
#### login credentials
username | password
:-------:|:--------------:
admin@mail.com | abc123

### 2. deo@mail.com (DEO)
#### login credentials
username | password
:-------:|:--------------:
deo@mail.com | abc123

