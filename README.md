# LibraryA_01

Proyecto ASP.NET Core (API) que apunta a .NET 10.

Estado actual
- Tipo: Aplicación Web (Microsoft.NET.Sdk.Web).
- TargetFramework: net10.0
- ORM: Entity Framework Core (Microsoft.EntityFrameworkCore 10.0.9) con proveedor Npgsql para PostgreSQL (Npgsql.EntityFrameworkCore.PostgreSQL 10.0.2).
- Documentación API: Swagger / OpenAPI (Swashbuckle.AspNetCore 10.2.3 y Microsoft.AspNetCore.OpenApi 10.0.9).
- Migraciones: la carpeta `LibraryA_01/Migrations` contiene migraciones (por ejemplo `20260705214548_creaciondeTablaBook.cs`).

Requisitos
- .NET 10 SDK
- PostgreSQL (o un servidor compatible)

Configuración rápida
1. Configurar la cadena de conexión a la base de datos en `appsettings.json` (o usar User Secrets / variables de entorno):

   Ejemplo:

   ```
   "ConnectionStrings": {
	 "DefaultConnection": "Host=localhost;Port=5432;Database=LibraryA;Username=usuario;Password=contraseña"
   }
   ```

2. Restaurar paquetes:

   dotnet restore

3. Aplicar migraciones a la base de datos (requiere dotnet-ef):

   dotnet ef database update --project LibraryA_01

4. Ejecutar la aplicación:

   dotnet run --project LibraryA_01

Uso en Visual Studio
- Abrir la solución `LibraryA_01.slnx` en Visual Studio 2026 y ejecutar el proyecto `LibraryA_01` como perfil de inicio.

Notas de desarrollo
- Las versiones de paquetes principales están en `LibraryA_01/LibraryA_01.csproj`.
- Para generar nuevas migraciones: `dotnet ef migrations add NombreMigracion --project LibraryA_01`.

Contacto
- Repositorio: https://github.com/jose-angell/LibraryA_01
