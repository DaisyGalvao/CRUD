create table cadastro
(ID smallint primary key identity (1,1),
nome varchar(50) not null,
email varchar(100) not null)

create table endereco
(ID smallint primary key identity (1,1),
ID_usuario int not null,
rua varchar (200) not null,
numero int not null,
cep int not null)



insert into Cadastro values (3, 'Shelby Galvão Queiroz')

insert into endereco values (102, 'Benedito Gianelli', 16, 08210750)



select * from cadastro
inner join endereco
on cadastro.ID = endereco.ID


select c.nome, e.rua
from cadastro c
inner join endereco e
on c.ID = e.ID






drop table endereço

update Cadastro 
set 
    nome = 'Daisy Galvão',
    email = 'daisy@gmail.com'
where ID = 1



SELECT * FROM cadastro



