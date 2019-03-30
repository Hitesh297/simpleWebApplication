# simpleWebApplication
Created Readme file.


select * from hitesh.students;

insert into hitesh.students values(1,'Hitesh','CS',1);
insert into hitesh.students values(2,'werfw','CS',2);
insert into hitesh.students values(3,'aefs','IS',3);

select * from Hitesh.Risk 
insert into Hitesh.Risk values(3,'B-');
delete from hitesh.students;

CREATE TABLE Hitesh.Risk (
    RiskId int NOT NULL,
    Rating varchar(255) NOT NULL,
    PRIMARY KEY (RiskId)
);

drop table Hitesh.Risk;

alter table hitesh.students
add RiskId int;

alter table hitesh.students add constraint fk_RiskId foreign key(RiskId) references hitesh.Risk(RiskId); 
