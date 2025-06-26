# Biblioteca API - Web API con .NET 9

Este proyecto es una práctica de creación de una API RESTful utilizando **ASP.NET Core 9** y **Entity Framework Core** para la gestión de una biblioteca simple con entidades `Author` y `Book`. 

## Descripción del Proyecto

La API permite gestionar autores y libros, ofreciendo operaciones básicas CRUD (Crear, Leer, Actualizar y Eliminar) para ambas entidades. 

- Los libros están relacionados con autores mediante una relación uno a muchos.
- Se usa una base de datos SQL Server configurada mediante Entity Framework Core.
- El proyecto implementa controladores separados para `Authors` y `Books`.
- Se configuran las opciones JSON para evitar ciclos de referencia en las respuestas.

## Funcionalidades principales

- Listar todos los autores o libros.
- Obtener un autor o libro por su ID.
- Crear nuevos autores o libros (validando existencia y evitando duplicados).
- Actualizar autores o libros existentes.
- Eliminar autores o libros por ID.

## Tecnologías utilizadas

- ASP.NET Core 9
- Entity Framework Core
- SQL Server (local)
- Visual Studio / VS Code
- Postman para pruebas de API

## Instrucciones para ejecutar el proyecto

1. Clonar este repositorio.
2. Configurar localmente el archivo `appsettings.Development.json` con la cadena de conexión a tu base de datos.
3. Ejecutar las migraciones para crear la base de datos.
4. Ejecutar la API y probar los endpoints con Postman o cualquier cliente HTTP.

## Nota importante

⚠️ **El archivo `appsettings.Development.json` no está incluido en este repositorio y debe ser configurado localmente** para definir la cadena de conexión a la base de datos y otras configuraciones sensibles.


## .gitignore relevante

El archivo `.gitignore` del proyecto incluye exclusiones para:

- Archivos y carpetas temporales de Visual Studio.
- Carpetas de binarios y objetos (`bin/`, `obj/`).
- Archivos de configuración local y de usuario (`*.user`, `.vs/`).
- El archivo `appsettings.Development.json` para proteger configuraciones sensibles.
- Carpetas y archivos generados por herramientas comunes como ReSharper, Rider, NuGet, y VS Code.

---

¡Gracias por revisar este proyecto! Cualquier duda o sugerencia es bienvenida.
