
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
DELETE FROM personne WHERE nom = 'abadi' OR nom='toto';