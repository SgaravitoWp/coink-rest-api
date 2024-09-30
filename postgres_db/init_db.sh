#!/bin/bash

echo "Esperando a que PostgreSQL esté listo..."

# Esperar hasta que PostgreSQL esté listo
until pg_isready -U "$COINK_USERNAME"; do
  echo "PostgreSQL aún no está listo, esperando 5 segundos..."
  sleep 5
done

echo "PostgreSQL está listo, continuando con la configuración..."

echo "Configuración de la base de datos ..."
echo "Database ..."
echo "Tables ..."
echo "Stored Procedures ..."
psql -U "$COINK_USERNAME" -f setup_tables.sql -f setup_sp.sql 
echo "Cargando datos de prueba..."
psql -U "$COINK_USERNAME" -f insert_countries.sql -f insert_states.sql -f insert_cities.sql

echo "Base de datos creada con éxito."