\c userregistration;

-- Habilitación del uso de uuid.
CREATE EXTENSION IF NOT EXISTS pgcrypto;

-- Creación de la tabla de países
CREATE TABLE IF NOT EXISTS countries  (
    id VARCHAR(3) PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Creación de la tabla de departamentos
CREATE TABLE IF NOT EXISTS states  (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    country_id VARCHAR(3) NOT NULL,
    FOREIGN KEY (country_id) REFERENCES countries(id)
);

-- Creación de la tabla de municipios
CREATE TABLE IF NOT EXISTS cities (
    id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    state_id INT NOT NULL,
    FOREIGN KEY (state_id) REFERENCES states(id)
);

-- Creación de la tabla de usuarios
CREATE TABLE IF NOT EXISTS users  (
    id VARCHAR(36) PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id VARCHAR(12) NOT NULL,
    name VARCHAR(100) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    address VARCHAR(255) NOT NULL,
    country_id VARCHAR(3) NOT NULL,
    state_id INT NOT NULL,
    city_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES countries(id),
    FOREIGN KEY (state_id) REFERENCES states(id),
    FOREIGN KEY (city_id) REFERENCES cities(id),
    CONSTRAINT unique_user UNIQUE (user_id, country_id)
);