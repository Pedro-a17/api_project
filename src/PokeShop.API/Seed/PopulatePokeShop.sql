USE PokeShopDb;
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE Transactions; TRUNCATE TABLE PokemonCenter; TRUNCATE TABLE PokemonElement; TRUNCATE TABLE Pokemons; TRUNCATE TABLE Elements; TRUNCATE TABLE Rarities; TRUNCATE TABLE Users;
SET FOREIGN_KEY_CHECKS = 1;

-- Rarities
INSERT INTO Rarities (Id, Name, Price) VALUES (1, 'Common', 20), (2, 'Uncommon', 40), (3, 'Rare', 60), (4, 'Legendary', 80);

-- Elements
INSERT INTO Elements (Id, Name) VALUES (1, 'Normal');
INSERT INTO Elements (Id, Name) VALUES (2, 'Fire');
INSERT INTO Elements (Id, Name) VALUES (3, 'Water');
INSERT INTO Elements (Id, Name) VALUES (4, 'Electric');
INSERT INTO Elements (Id, Name) VALUES (5, 'Grass');
INSERT INTO Elements (Id, Name) VALUES (6, 'Ice');
INSERT INTO Elements (Id, Name) VALUES (7, 'Fighting');
INSERT INTO Elements (Id, Name) VALUES (8, 'Poison');
INSERT INTO Elements (Id, Name) VALUES (9, 'Ground');
INSERT INTO Elements (Id, Name) VALUES (10, 'Flying');
INSERT INTO Elements (Id, Name) VALUES (11, 'Psychic');
INSERT INTO Elements (Id, Name) VALUES (12, 'Bug');
INSERT INTO Elements (Id, Name) VALUES (13, 'Rock');
INSERT INTO Elements (Id, Name) VALUES (14, 'Ghost');
INSERT INTO Elements (Id, Name) VALUES (15, 'Dragon');
INSERT INTO Elements (Id, Name) VALUES (16, 'Dark');
INSERT INTO Elements (Id, Name) VALUES (17, 'Steel');
INSERT INTO Elements (Id, Name) VALUES (18, 'Fairy');

-- Users
INSERT INTO Users (Id, UserName, PasswordHash, Coins, FirstLogin) VALUES ('ea128a93-f0cd-4bcf-9d72-bcd50babf4fa', 'admin','37b01d52-7bfb-4ec4-94e0-f2c38d6df11c', 0, 0);

-- Pokémons and PokemonElements
INSERT INTO Pokemons (Id, Name, RarityId, OwnerId) VALUES ('9deceb54-6ae7-4777-bc31-756bcb486533', 'Pikachu', 1, NULL);
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (4, '9deceb54-6ae7-4777-bc31-756bcb486533');
INSERT INTO Pokemons (Id, Name, RarityId, OwnerId) VALUES ('fdfdb933-0262-4568-99a5-47bd13d14223', 'Caterpie', 1, NULL);
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (12, 'fdfdb933-0262-4568-99a5-47bd13d14223');
INSERT INTO Pokemons (Id, Name, RarityId, OwnerId) VALUES ('92150894-a28d-435e-b25f-d38deb114b44', 'Charizard', 3, NULL);
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (2, '92150894-a28d-435e-b25f-d38deb114b44');
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (10, '92150894-a28d-435e-b25f-d38deb114b44');
INSERT INTO Pokemons (Id, Name, RarityId, OwnerId) VALUES ('678de2f3-f5ff-48f0-91cf-4b082eb16b86', 'Rayquaza', 4, NULL);
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (15, '678de2f3-f5ff-48f0-91cf-4b082eb16b86');
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (10, '678de2f3-f5ff-48f0-91cf-4b082eb16b86');
INSERT INTO Pokemons (Id, Name, RarityId, OwnerId) VALUES ('fa993d80-de8e-4c99-9844-b9e65804f606', 'Bisharp', 3, NULL);
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (16, 'fa993d80-de8e-4c99-9844-b9e65804f606');
INSERT INTO PokemonElement (ElementsId, PokemonId) VALUES (17, 'fa993d80-de8e-4c99-9844-b9e65804f606');
