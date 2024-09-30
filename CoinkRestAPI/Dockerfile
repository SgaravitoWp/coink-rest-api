# Usar la imagen base del SDK de .NET 8.0 desde el registro de Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Establecer el directorio de trabajo en el contenedor
WORKDIR /home/dotnet-coink

# Copiar todos los archivos del contexto de construcción al directorio de trabajo
COPY . .

# Definir argumentos que se pueden pasar durante la construcción de la imagen
ARG COINK_USERNAME
ARG COINK_PWD

# Establecer variables de entorno a partir de los argumentos proporcionados
ENV COINK_USERNAME=${COINK_USERNAME}
ENV COINK_PWD=${COINK_PWD}

# Restaurar las dependencias, inicializar los secretos de usuario y establecer sus valores
RUN dotnet restore \  
&& dotnet user-secrets init \  
&& dotnet user-secrets set "HOST" "postgres-coink" \  
&& dotnet user-secrets set "PORT" "5432" \  
&& dotnet user-secrets set "USERNAME" "$COINK_USERNAME" \  
&& dotnet user-secrets set "PWD" "$COINK_PWD" \  
&& dotnet build  
# Compila el proyecto con sus respectivas variables de conexion a postgres. 

# Comando por defecto para ejecutar la aplicación cuando el contenedor se inicia
CMD ["dotnet", "run"]
