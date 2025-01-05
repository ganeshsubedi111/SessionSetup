# SessionSetup

add session in aspdotnet project:(EF)
Step 1:
Add below line before build in program.cs, "builder.Services.Add Session();"
Add below line after build in program.cs, "app.UseSession();"

step2:Download these 3 packages:
 Microsoft.EntityFrameworkCore.SqlServer,Microsoft.EntityFrameworkCore.Tools,
Microsoft.EntityFrameworkCore..Design

Step:3 Execute a command for Scaffold  DbContext in package manager Console
Scaffold-DbContext "Server=ServerName; database=DatabaseName; 
trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


---This will automatically genertae model class and DbContect class


step 4: move Connection String From DbContext Class To appsettings.json file

Create action method for login and logout 
