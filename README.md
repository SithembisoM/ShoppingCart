# ShoppingCart

Installing sendgrid:
dotnet add package SendGrid --version 9.28.0

Ui
https://localhost:7243/

APi
Base Url: http://localhost:5219
The default route for api is http://localhost:5219/api/product/
Swagger:  http://localhost:5219/swagger/index.html

Database Setup
ConnectionString: "Server=(LocalDB)\\.;Database=ShoppingCartDB;user id=ShoppingCartUser;password=Password!@#;Trusted_Connection=True;MultipleActiveResultSets=true"

You may need to isntlal the followung packages:
    Install-Package Microsoft.EntityFrameworkCore.SqlServer
    Install-Package Microsoft.EntityFrameworkCore.Tools

And run the data seed script:
   \.SeedData