# Usar la imagen base de PostgreSQL 13 desde el registro de Docker Hub
FROM postgres:13

# Establecer el directorio de trabajo en el contenedor
WORKDIR /docker-entrypoint-initdb.d/

# Definir argumentos que se pueden pasar durante la construcción de la imagen
ARG COINK_USERNAME
ARG COINK_PWD

# Establecer variables de entorno a partir de los argumentos proporcionados
ENV COINK_USERNAME=${COINK_USERNAME}
ENV COINK_PWD=${COINK_PWD}

# Copiar todos los archivos SQL y scripts de shell al directorio de trabajo
COPY *.sql *.sh ./

# Exponer el puerto 5432 para conexiones a PostgreSQL
EXPOSE 5432
