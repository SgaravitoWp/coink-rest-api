# Coink Rest API

## Resumen

La Coink Rest API es una aplicación de interfaz de programación de aplicaciones (API) RESTful diseñada para facilitar el registro de usuarios y la consulta de información geográfica. Desarrollada utilizando tecnologías modernas, esta API proporciona una solución robusta y escalable para la gestión de datos de usuarios.

## Especificaciones Técnicas

- **Framework:** ASP.NET 8.0.401
- **Lenguaje de Backend:** C#
- **Tipo de Aplicación:** REST API
- **Sistema de Gestión de Base de Datos:** PostgreSQL 13.11
- **Arquitectura:** Diseño por capas
- **Infraestructura:** Docker

## Estructura del Proyecto

- **Solución C#:** CoinkRestAPI.sln
- **Proyecto C#:** CoinkRestAPI
- **Proyecto PostgreSQL:** postgres_db

## Funcionalidades Principales

1. **Registro de Usuarios:**
   La API permite el registro de usuarios con los siguientes campos:
   - `user_id`: Número de documento de identidad (identificador único)
   - `name`: Nombre del usuario
   - `phone`: Número telefónico
   - `country_id`: Identificador del país de residencia
   - `state_id`: Identificador del departamento o estado
   - `city_id`: Identificador de la ciudad

   Nota: Se garantiza un registro único por usuario basado en `user_id` y `country_id`.

2. **Consulta de Información Geográfica:**
   Proporciona endpoints para consultar los identificadores de países, departamentos/estados y ciudades/municipios, facilitando el proceso de registro. Se incluyen datos para Colombia y algunos de España con fines de prueba.

Para una documentación detallada de los endpoints y sus funcionalidades, por favor consulte la documentación Swagger disponible en la ruta `/swagger`.

## Instrucciones de Despliegue Local

### 1. Establecimiento de Variables de Entorno

Para configurar el entorno de la aplicación, es necesario crear un archivo `.env` que contenga las siguientes variables:

```
COINK_USERNAME 
COINK_PWD
```


Estas variables representan el nombre de usuario y la contraseña utilizados para crear el contenedor de PostgreSQL, así como para establecer la conexión desde la aplicación .NET.

### 2. Despliegue de Contenedores

El único requisito para ejecutar la aplicación es contar con Docker instalado en su sistema. Una vez que Docker esté configurado, ejecute el siguiente comando en el mismo directorio que el archivo `docker-compose.yml`:



```
docker compose up
```

Este comando iniciará los contenedores necesarios y pondrá en marcha la aplicación.

### 3. Acceso a la Aplicación

Una vez que los contenedores se hayan iniciado correctamente, podrá acceder a la aplicación y disfrutar de sus funcionalidades.


## Soporte y Contacto

Para consultas técnicas o soporte.
- Mi correo de contacto es sgaravito@unal.edu.co. 
- Mi perfil de [LinkedIn](https://linkedin.com/in/samuel-jacobo-garavito-segura).
- Mi perfil de [GitHub](https://github.com/SgaravitoWp)



