--
-- File generated with SQLiteStudio v3.4.4 on ¬т май 23 10:38:57 2023
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: animal_availability
CREATE TABLE animal_availability (id INTEGER PRIMARY KEY, title TEXT);

-- Table: animals
CREATE TABLE animals (id INTEGER PRIMARY KEY, photo_path TEXT, name TEXT (45), description TEXT, description_extra TEXT, history TEXT, admission_date TEXT, height REAL (3, 2), weight REAL (3, 2), kinds_id INTEGER REFERENCES kinds ON UPDATE CASCADE ON DELETE CASCADE, availability_id INTEGER REFERENCES animal_availability ON UPDATE CASCADE ON DELETE CASCADE);

-- Table: events
CREATE TABLE events (id INTEGER PRIMARY KEY, description TEXT, photo_path TEXT, link TEXT);

-- Table: kinds
CREATE TABLE kinds (id INTEGER PRIMARY KEY, name TEXT (45));

-- Table: lucky_animals
CREATE TABLE lucky_animals (id INTEGER PRIMARY KEY, photo_path TEXT, comment TEXT, date TEXT, animal_id REFERENCES animals (id) ON DELETE CASCADE ON UPDATE CASCADE UNIQUE);

-- Table: orders
CREATE TABLE orders (id INTEGER PRIMARY KEY, phone TEXT, email TEXT, planned_date TEXT, animal_id INTEGER REFERENCES animals (id) ON DELETE CASCADE ON UPDATE CASCADE, comment TEXT);

-- Table: subscriptions
CREATE TABLE subscriptions (id INTEGER PRIMARY KEY, email TEXT);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
