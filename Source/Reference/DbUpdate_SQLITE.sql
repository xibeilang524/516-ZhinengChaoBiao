
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 10,'800米','分.秒',2,1 where not exists (select * from PhysicalItem where id=10)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 11,'1000米','分.秒',2,1  where not exists (select * from PhysicalItem where id=11)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 18,'一分钟跳绳','次/分',0,1  where not exists (select * from PhysicalItem where id=18)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 15,'掷实心球','米',1,1  where not exists (select * from PhysicalItem where id=15)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 6,'立定跳远','厘米',0,1  where not exists (select * from PhysicalItem where id=6)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 5,'50米','秒',1,1  where not exists (select * from PhysicalItem where id=5)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 12,'一分钟仰卧起坐','次/分',0,1  where not exists (select * from PhysicalItem where id=12)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 14,'引体向上','次',0,1  where not exists (select * from PhysicalItem where id=14)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 13,'400米','分.秒',2,1  where not exists (select * from PhysicalItem where id=13)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 7,'坐位体前屈','厘米',1,1  where not exists (select * from PhysicalItem where id=7)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 8,'握力','公斤',1,1  where not exists (select * from PhysicalItem where id=8)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 9,'50米×8往返跑','分.秒',2,1  where not exists (select * from PhysicalItem where id=9)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 1,'身高','厘米',1,1  where not exists (select * from PhysicalItem where id=1)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 2,'体重','公斤',1,1  where not exists (select * from PhysicalItem where id=2)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 4,'肺活量','毫升',0,1  where not exists (select * from PhysicalItem where id=4)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 3,'台阶测试','次',0,1  where not exists (select * from PhysicalItem where id=3)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 16,'丢沙包','米',1,1  where not exists (select * from PhysicalItem where id=16)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 17,'25米*2往返跑','秒',1,1  where not exists (select * from PhysicalItem where id=17)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 19,'篮球运球','秒',2,1  where not exists (select * from PhysicalItem where id=19)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 20,'足球运球','秒',2,1  where not exists (select * from PhysicalItem where id=20)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 21,'排球垫球','次',0,1  where not exists (select * from PhysicalItem where id=21)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 22,'30秒踢键子','次',0,1  where not exists (select * from PhysicalItem where id=22)
go

insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine) select 23,'足球颠球','次',0,1  where not exists (select * from PhysicalItem where id=23)
go

-------2014-12-03  bruce 在考试中增加一列用于保存总分的计算公式--------------------------------
Alter table PhysicalProject Add Column TotalFormula nvarchar(1000)
go

-------2014-12-03  bruce 评分标准增加所属考试--------------------------------
Alter table Standard Add Column ProjectID nvarchar(50)
go

--========2014-12-06 bruce 测试项目增加最大值和最小值列--------------------------------
alter table PhysicalItem add column Max Decimal(18,4)
go
alter table PhysicalItem add column Min Decimal(18,4)
go

---------------2014-12-6 对min和max赋初值----------------------------
update physicalItem set [Max]=9.00 where ID=10 and [Max] is null
go
update physicalItem set [Min]=2.00 where ID=10 and [Min] is null
go
update physicalItem set [Max]=9.00 where ID=11 and [Max] is null
go
update physicalItem set [Min]=2.00 where ID=11 and [Min] is null
go
update physicalItem set [Max]=300 where ID=18 and [Max] is null
go
update physicalItem set [Min]=0 where ID=18 and [Min] is null
go
update physicalItem set [Max]=25.0 where ID=15 and [Max] is null
go
update physicalItem set [Min]=1.0 where ID=15 and [Min] is null
go
update physicalItem set [Max]=400 where ID=6 and [Max] is null
go
update physicalItem set [Min]=50 where ID=6 and [Min] is null
go
update physicalItem set [Max]=20.0 where ID=5 and [Max] is null
go
update physicalItem set [Min]=5.0 where ID=5 and [Min] is null
go
update physicalItem set [Max]=99 where ID=12 and [Max] is null
go
update physicalItem set [Min]=0 where ID=12 and [Min] is null
go
update physicalItem set [Max]=99 where ID=14 and [Max] is null
go
update physicalItem set [Min]=0 where ID=14 and [Min] is null
go
update physicalItem set [Max]=4.00 where ID=13 and [Max] is null
go
update physicalItem set [Min]=0.45 where ID=13 and [Min] is null
go
update physicalItem set [Max]=40 where ID=7 and [Max] is null
go
update physicalItem set [Min]=-30 where ID=7 and [Min] is null
go
update physicalItem set [Max]=100 where ID=8 and [Max] is null
go
update physicalItem set [Min]=1 where ID=8 and [Min] is null
go
update physicalItem set [Max]=4.00 where ID=9 and [Max] is null
go
update physicalItem set [Min]=0.45 where ID=9 and [Min] is null
go
update physicalItem set [Max]=250 where ID=1 and [Max] is null
go
update physicalItem set [Min]=80 where ID=1 and [Min] is null
go
update physicalItem set [Max]=200 where ID=2 and [Max] is null
go
update physicalItem set [Min]=14 where ID=2 and [Min] is null
go
update physicalItem set [Max]=9999 where ID=4 and [Max] is null
go
update physicalItem set [Min]=500 where ID=4 and [Min] is null
go
update physicalItem set [Max]=99 where ID=3 and [Max] is null
go
update physicalItem set [Min]=20 where ID=3 and [Min] is null
go
update physicalItem set [Max]=50 where ID=16 and [Max] is null
go
update physicalItem set [Min]=1 where ID=16 and [Min] is null
go
update physicalItem set [Max]=20 where ID=17 and [Max] is null
go
update physicalItem set [Min]=5 where ID=17 and [Min] is null
go
update physicalItem set [Max]=60 where ID=19 and [Max] is null
go
update physicalItem set [Min]=1 where ID=19 and [Min] is null
go
update physicalItem set [Max]=45 where ID=20 and [Max] is null
go
update physicalItem set [Min]=1 where ID=20 and [Min] is null
go
update physicalItem set [Max]=99 where ID=21 and [Max] is null
go
update physicalItem set [Min]=1 where ID=21 and [Min] is null
go
update physicalItem set [Max]=99 where ID=22 and [Max] is null
go
update physicalItem set [Min]=0 where ID=22 and [Min] is null
go
update physicalItem set [Max]=99 where ID=23 and [Max] is null
go
update physicalItem set [Min]=1 where ID=23 and [Min] is null
go
------2014-12-08 --------------------------------------------
update physicalItem set Name='坐位体前屈' where Name='坐位体前驱'
go

--------2014-12-10  学生信息表增加一列用于保存写卡次数------------------
alter table Student add column WriteCardCount int 
go

--------2014-12-13  学生信息表增加一列用于保存成绩单打印次数------------------
alter table Student add column PrintCount int 
go

------2014-12-15  增加报警日志表-------------------------------------
CREATE TABLE [AlarmInfo] (
  [ID] GUID NOT NULL, 
  [AlarmDateTime] DATETIME NOT NULL, 
  [AlarmType] INT NOT NULL, 
  [AlarmDescr] nvarchar(300), 
  [OperatorID] NVARCHAR(50), 
  CONSTRAINT [] PRIMARY KEY ([ID]))
go


CREATE TABLE [AbsentStudent] (
  [ProjectID] NVARCHAR(50) NOT NULL, 
  [StudentID] NVARCHAR(50) NOT NULL, 
  [Memo] NVARCHAR(50) ,
  CONSTRAINT [] PRIMARY KEY ([ProjectID], [StudentID]))
GO

CREATE TABLE [StudentPhoto] (
  [StudentID] NVARCHAR(50) NOT NULL, 
  [Photo] image ,
  CONSTRAINT [] PRIMARY KEY ([StudentID]))
GO


--------------2014-12-30 李建华 学生成绩增加一个特殊类型字段,用于保存缺考,免考,伤病等特殊情况----
alter table PhysicalScore add column SpecialType int 
go

--------------2014-12-31 测试项目增中公式列,有些测试项的成绩是通过公式计算得来的--------------
alter table PhysicalItem add column Formula nvarchar(50) 
go

------------2015-3-23 学生信息增加组别列--------------------
alter table Student add column GroupID nvarchar(50)
go

------------2015-4-22 测试项目增加一列用于表示成绩的排序模式
alter table PhysicalItem add SortMode int 
go

update physicalItem set [SortMode]=1 where ID=10 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=11 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=18 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=15 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=6 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=5 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=12 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=14 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=13 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=7 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=8 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=9 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=4 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=3 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=16 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=17 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=19 and [SortMode] is null
go
update physicalItem set [SortMode]=1 where ID=20 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=21 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=22 and [SortMode] is null
go
update physicalItem set [SortMode]=2 where ID=23 and [SortMode] is null
go


-------2015-4-23 增加俯卧撑等项目
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode) select 70,'一分钟俯卧撑','次/分',0,1,0,900,2 where not exists (select * from PhysicalItem where id=70)
go

--------2015-5-08 增加几个指数项目
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 24,'BMI指数','',1,1,null,null,null,'([体重] * 10000)/([身高] * [身高])' where not exists (select * from PhysicalItem where id=24)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 25,'肺活量体重指数','',1,1,null,null,2,'[肺活量]/[体重]' where not exists (select * from PhysicalItem where id=25)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 26,'握力体重指数','',1,1,null,null,2,'([握力] * 100) / [体重]' where not exists (select * from PhysicalItem where id=26)
go

-----2015-5-8 增加一个表用于保存考试科目和总分计算和，取代之前的表ProjectPhysicalItem
CREATE TABLE [ProjectPhysicalItems] (
  [ID] uniqueidentifier NOT NULL, 
  [ProjectID] NVARCHAR(50) NOT NULL, 
  [Grade] int NOT NULL, 
  [PhysicalItems] nvarchar(1000) NULL, 
  [TotalFormula] nvarchar(1000) NULL,
  CONSTRAINT [] PRIMARY KEY ([ID]))
go

--2015-5-13 增加几个测试项目
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 71,'左眼视力','',1,1,0,10,2,null where not exists (select * from PhysicalItem where id=71)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 72,'右眼视力','',1,1,0,10,2,null where not exists (select * from PhysicalItem where id=72)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 73,'100米跑','秒',2,1,5,50,1,null where not exists (select * from PhysicalItem where id=73)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 74,'200米跑','秒',2,1,5,100,1,null where not exists (select * from PhysicalItem where id=74)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 80,'反应时','秒',2,1,null,null,1,null where not exists (select * from PhysicalItem where id=80)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 81,'纵跳摸高','秒',2,1,null,null,2,null where not exists (select * from PhysicalItem where id=81)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 82,'闭眼单脚站立','秒',2,1,null,null,2,null where not exists (select * from PhysicalItem where id=82)
go

--2015-5-14 成绩表增加修改人字段 , 加分字段
alter table PhysicalScore add column Modifier nvarchar(50)
go

alter table PhysicalScore add column Jiafen decimal(18,4)
go

---2015-5-20 评分标准增加一个字段 是否是加分评分标准
alter table Standard  add column IsForJiafen bit 
go

--2015-7-4 学生信息增加修改,上传到云平台时间两个字段
alter table Student add column UpdateDate datetime
go

alter table student add column UploadToCloudDate datetime
go

alter table physicalScore add column UploadToCloudDate datetime
go

---2015-10-19 增加的测试项目
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 75,'60米跑','秒',2,1,0,30,1,null where not exists (select * from PhysicalItem where id=75)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 76,'100米跨栏','秒',2,1,0,30,1,null where not exists (select * from PhysicalItem where id=76)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 77,'110米跨栏','秒',2,1,0,30,1,null where not exists (select * from PhysicalItem where id=77)
go
insert into PhysicalItem (ID,Name,Unit,PointCount,Hasmachine,[Min],[Max],SortMode,Formula) select 79,'4*100米跑','秒',2,1,0,120,1,null where not exists (select * from PhysicalItem where id=79)
go

---2015-10-27 增加运动会需要的一些表和字段
alter table physicalScore add column SportsID nvarchar(50)
go

CREATE TABLE [Sports] (
  [ID] uniqueidentifier NOT NULL,  
  [Name] NVARCHAR(50) nOT NULL,
  [PhysicalItem] tinyint Not NULL, 
  [MatchDate] DateTime null,
  [Memo] nvarchar(200) NULL,
  CONSTRAINT [] PRIMARY KEY ([ID]))
go

CREATE TABLE [SportsStudentPair] (
  [ID] uniqueidentifier NOT NULL, 
  [SportsID] uniqueidentifier NOT NULL, 
  [StudentID] NVARCHAR(50) NOT NULL, 
  [GroupID] nvarchar(50), 
  [Channel] nvarchar(50), 
  [Score] decimal(18,4), 
  [Rank] tinyint,
  [State] TINYINT NOT NULL, 
  [Memo] NVARCHAR(200) NULL,
  CONSTRAINT [] PRIMARY KEY ([ID]))
go






















