# MiAppTresCapas

**MiAppTresCapas** es una aplicación de consola desarrollada en C# que implementa una arquitectura en tres capas: Datos, Negocio y Presentación. La aplicación gestiona entidades como `Clientes`, `Vendedores`, `Facturas`, `Empresas` y `Productos`, permitiendo operaciones CRUD a través de una interfaz de consola.

## Características

- **CRUD de Clientes**: Crear, consultar, modificar y eliminar clientes.
- **CRUD de Vendedores**: Crear, consultar, modificar y eliminar vendedores.
- **CRUD de Facturas**: Crear, consultar, modificar y eliminar facturas.
- **CRUD de Productos**: Crear, consultar, modificar y eliminar productos.
- **CRUD de Empresas**: Crear, consultar, modificar y eliminar empresas.

## Tecnologías Utilizadas

- **Lenguaje**: C# (.NET 8.0)
- **Base de Datos**: SQL Server utilizando Entity Framework Core
- **Arquitectura**: Patrón de Arquitectura en Tres Capas (Datos, Negocio, Presentación)
- **Control de Versiones**: Git y GitHub

## Requisitos Previos

Para ejecutar este proyecto en tu máquina local, asegúrate de tener instalado lo siguiente:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)

## Configuración del Proyecto

### Clonar el Repositorio

Clona el repositorio a tu máquina local usando Git:

```bash
git clone https://github.com/juandax03/MiAppTresCapas.git
cd MiAppTresCapas
Migraciones y Base de Datos
Este proyecto utiliza Entity Framework Core para la gestión de la base de datos. Si es la primera vez que configuras la base de datos, sigue estos pasos:

Ejecuta las migraciones para crear las tablas necesarias en tu base de datos:

bash
Copiar código
dotnet ef database update
Configura la cadena de conexión en el archivo appsettings.json si es necesario, apuntando a tu instancia de SQL Server.

Ejecutar la Aplicación
Una vez que el proyecto esté configurado correctamente, puedes ejecutarlo utilizando el siguiente comando:

bash
Copiar código
dotnet run
Operaciones CRUD
La aplicación te guiará a través de menús interactivos donde podrás realizar operaciones de creación, consulta, modificación y eliminación sobre las entidades del sistema.

Contribuir
Si deseas contribuir a este proyecto, sigue estos pasos:

Haz un fork del repositorio.
Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).
Realiza los cambios necesarios y haz commit (git commit -m 'Añadir nueva funcionalidad').
Empuja los cambios a la rama (git push origin feature/nueva-funcionalidad).
Abre un Pull Request.
