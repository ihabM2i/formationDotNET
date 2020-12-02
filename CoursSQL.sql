
--Création de TABLE
CREATE TABLE personne (id int PRIMARY KEY IDENTITY(1,1), nom varchar(120) NOT NULL, prenom varchar(50) NOT NULL);

--Supprimer une TABLE
DROP TABLE personne;

--Modification d'une TABLE
--Ajouter une column
ALTER TABLE personne ADD telephone varchar(10) NOT NULL;

--Supprimer une column
ALTER TABLE personne DROP COLUMN telephone;

--ALTER TABLE peronne RENAME COLUMN telephone to phone
--Uniquement pour SQL SERVER
EXEC sp_rename 'personne.telephone', 'phone', 'COLUMN'; 

--Ajouter des données dans une table
INSERT INTO personne (nom, prenom, telephone) values ('abadi', 'ihab', '0606060606');
INSERT INTO personne (nom, prenom, telephone) values ('toto', 'tata', '0606060606');

--Pour supprimer des données dans une table
--DELETE FROM personne
--DELETE FROM personne WHERE id = 4;
--DELETE FROM personne WHERE nom = 'abadi';
--DELETE FROM personne WHERE nom = 'abadi' AND prenom='ihab';
--DELETE FROM personne WHERE nom = 'abadi' OR nom='toto';

--Pour modifier des données dans une table

--UPDATE personne set nom = 'coucou', prenom = 'ttttt';
UPDATE personne set telephone='0707070707' where id=8;

--SELECTION
SELECT * FROM personne;
SELECT id, nom, prenom, telephone from personne;

-- AS permet d'ajouter un alias à une colonne uniquement à la réponse de la requete
--SELECT id as personneId, nom, prenom, telephone from personne;
--SELECT * FROM personne where id <> 8 AND id<>10;
--SELECT * FROM personne where nom = 'abadi'
--SELECT * FROM personne where nom like 'aba%'
--SELECT * FROM personne where nom like '%aba'
--SELECT * FROM personne where nom like '%t%'

--Les relations entre tables

--Creer une table adresse (id, adresse, ville, codePostal, personne_id)
CREATE TABLE adresse (
id int PRIMARY KEY IDENTITY(1,1),
adresse VARCHAR(2000) NOT NULL,
ville varchar(200) NOT NULL,
code_postal varchar(5) NOT NULL,
personne_id int NOT NULL
)

--INSERT INTO adresse (adresse, ville, code_postal, personne_id) 
--values ('lille', 'lille', '59000', 10)
--INSERT INTO adresse (adresse, ville, code_postal, personne_id) 
--values ('lille', 'paris', '75000', 10)

--Jointure
--inner join
SELECT * FROM personne inner join adresse on personne.id = adresse.personne_id
SELECT p.id, p.nom, p.prenom, p.telephone, a.adresse, a.ville, a.code_postal FROM personne as p inner join adresse as a on p.id = a.personne_id where p.id = 10

