# OnlineChallengeWebMotors

## Desenvolvimento para conclusão de teste para WebMotors.

*Para o funcionamento local deste projeto, deverá criar um banco de dados local com uma tabela espeficica, sendo:

create database teste_webmotors
go --apenas MSSQL

create table teste_webmotors..tb_AnuncioWebmotors(
	ID INT identity not null,
	marca varchar (45) not null,
	modelo varchar (45) not null,
	versao varchar (45) not null,
	ano INT not null,
	quilometragem INT not null,
	observacao text not null
)
*

# Atenção, certificar-se que o projeto angular está apontando corretamente para o endereço api. Dentro do projeto angular, em enviroments está definido como: **https://localhost:5001/api**, esse endereço pode ser diferente na sua máquina.