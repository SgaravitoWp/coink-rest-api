\c userregistration;

-- Función para obtener todos los países
CREATE OR REPLACE FUNCTION GetCountries()
RETURNS TABLE(id VARCHAR(3), name VARCHAR(200)) AS $$
BEGIN
    RETURN QUERY SELECT * FROM countries;  -- Devuelve todos los registros de la tabla 'countries'
END;
$$ LANGUAGE plpgsql;

-- Función para obtener todos los departamentos de un país específico
CREATE OR REPLACE FUNCTION GetStates(id_country VARCHAR(3))
RETURNS TABLE(id INT, name VARCHAR(100), country_id VARCHAR(3)) AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM states s
    WHERE s.country_id = id_country;  -- Filtra los departamentos por el ID del país proporcionado
END;
$$ LANGUAGE plpgsql;

-- Función para obtener todas los municipios de un departamento específico
CREATE OR REPLACE FUNCTION GetCities(id_state INT)
RETURNS TABLE(id INT, name VARCHAR(100), state_id INT) AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM cities c
    WHERE c.state_id = id_state;  -- Filtra las municipios por el ID del departamento proporcionado
END;
$$ LANGUAGE plpgsql;

-- Función para insertar un nuevo usuario
CREATE OR REPLACE FUNCTION InsertUser(
    id_user VARCHAR(12),
    name VARCHAR(100),
    phone VARCHAR(15),
    address VARCHAR(255),
    id_country VARCHAR(3),
    id_state INT,
    id_city INT
) 
RETURNS VARCHAR AS $$
DECLARE
    new_id VARCHAR(36);  -- Variable para almacenar el ID del nuevo usuario
BEGIN
    -- Verificar si el país, departamento y municipio existen
    IF EXISTS (SELECT 1 FROM countries c WHERE c.id = id_country) AND
       EXISTS (SELECT 1 FROM states s WHERE s.id = id_state AND s.country_id = id_country) AND
       EXISTS (SELECT 1 FROM cities ci WHERE ci.id = id_city AND ci.state_id = id_state) THEN
            -- Insertar usuario si todas las validaciones son exitosas
        INSERT INTO users (user_id, name, phone, address, country_id, state_id, city_id)
        VALUES (id_user, name, phone, address, id_country, id_state, id_city)
        RETURNING id INTO new_id;  -- Retorna el ID del nuevo usuario   
        RETURN new_id;  -- Retornar el ID del nuevo registro
    ELSE
        RAISE USING ERRCODE = '40000';  -- Retorno  si la validación falla
    END IF;
END;
$$ LANGUAGE plpgsql;
