# DemoClienteBackend
DEMO Cliente Backend

nugets
1. EntityFramework
2. Microsoft.AspNetCore.MVC.NewtonsoftJson
3. Microsoft.EntityFrameworkCore
4. Microsoft.EntityFrameworkCore.Desing
5. Microsoft.EntityFrameworkCore.Sqlite 
6. Microsoft.EntityFrameworkCore.SqlServer
7. Microsoft.EntityFrameworkCore.Tools
8. Microsoft.VisualStudio.Web.CodeGeneration.Desing

Opcional
9. Newtonsoft.Json


Crear el contexto
public ModelContext(DbContextOptions<ModelContext> options) : base(options) {
}
public DbSet<Cliente> Clientes { get; set; }

Startup // ConfigureServices
string connection = Configuration.GetConnectionString("demo");
services.AddDbContext<ModelContext>(options => 
	options.UseSqlServer(connection)
	);

services.AddControllersWithViews()
	.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

Migrations
add-migration nameMigration -context NameContext
update-database -context NameContext