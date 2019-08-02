
create database bao_2_Van2;
--drop database bao_2_Van

create table tblTheLoai
(
pk_itheloai int IDENTITY(1,1) NOT NULL PRIMARY KEY,
stentheloai nvarchar (50)
)

create table tblquyen
(
pk_iquyenid int IDENTITY(1,1) NOT NULL PRIMARY KEY,
stenquyen nvarchar(20)
)




create table tblUSer
(
pk_iuserid int IDENTITY(1,1) NOT NULL PRIMARY KEY,
susername nvarchar(35),
spass nvarchar(10),
shoten nvarchar(35),
bGioiTinh bit,
btrangThai bit,
dngaysinh datetime

)

alter table tbluser add imaquyen int;
alter table tbluser add foreign key (imaquyen) references tblquyen (pk_iquyenid);

--alter table tbluser alter column pk_iuserid int IDENTITY (1,1) NOT NULL PRIMARY KEY

create table tblBaiBao
(
pk_ibaivietid int IDENTITY(1,1) NOT NULL PRIMARY KEY,
stieude nvarchar(150),
snoidung nvarchar(800),
bduyet bit,
ilanxem int ,
dngaydang datetime,
iuserdang int,
dngayduyet datetime,
iuserduyet int,
btrangthai bit,
iuserdoitrangthai int,
fk_itheloaiid int,
smota nvarchar(150),
surlanh varchar(30)
)

alter table tblbaibao add constraint fk_theloai 
Foreign key (fk_itheloaiid) references tbltheloai (pk_itheloai)

alter table tblbaibao add constraint fk_userdang 
Foreign key (iuserdang) references tbluser (pk_iuserid)

alter table tblbaibao add constraint fk_userduyet 
Foreign key (iuserdang) references tbluser (pk_iuserid)

alter table tblbaibao add constraint fk_userdoitt 
Foreign key (iuserdoitrangthai) references tbluser (pk_iuserid)


create proc select_Baibao_daduyet
 as
 select * from tblBaiBao,tbltheloai where tblbaibao.fk_itheloaiid = tblTheLoai.pk_itheloai
 and bduyet = 1

exec select_Baibao_daduyet

create proc select_Theloai_ByPK
@ma int
as
select stentheloai from tblTheLoai where pk_itheloai = @ma

select * from tblUSer

create proc select_Users_by_ID
@ma int
as
select * from tblUSer where tblUSer.pk_iuserid = @ma

alter proc select_All_Users
as
select * from tblUSer, tblquyen where tblUSer.imaquyen = tblquyen.pk_iquyenid

alter

exec select_All_Users

exec select_Users_by_ID

create proc insert_Users
@username nvarchar(35),
@pass varchar(10),
@hoten nvarchar(35),
@gt bit ,
@ns datetime,
@quyen int
as
insert into tblUSer values (@username,@pass,@hoten,@gt,0,@ns,@quyen)

create proc select_Baibao
@ma int
as
select a.fk_itheloaiid, b.stentheloai, a.stieude, a.snoidung,a.smota,a.surlanh,a.dngaydang,
a.ilanxem, c.shoten  from tblBaiBao a, tbltheloai b,
tbluser c
 where pk_ibaivietid  = @ma and a.fk_itheloaiid = b.pk_itheloai and a.iuserdang = c.pk_iuserid

 exec  select_baiBao 1

create proc update_soluotxem
@ma int 
as
update  tblBaiBao set ilanxem = ilanxem +1 where pk_ibaivietid = @ma

alter proc search_Article
@tieude nvarchar(50)
as
select a.fk_itheloaiid, a.pk_ibaivietid, a.surlanh,a.smota, a.stieude from tblBaiBao a
where a.stieude like '%' + @tieude + '%'

exec search_Article '2'


alter table tblbaibao alter column surlanh varchar(100);

select * from tblbaiBao

create proc insert_Baibao
@tieude nvarchar(150),
@noidung nvarchar(600),
@mota nvarchar(150),
@ngaydang datetime,
@manguoidang int,
@matl int,
@urlanh varchar(100)
as
insert into tblBaiBao (stieude,snoidung,smota,dngaydang,iuserdang,fk_itheloaiid,surlanh)
values(@tieude,@noidung,@mota,@ngaydang,@manguoidang,@matl,@urlanh);

create proc update_Baibao
@tieude nvarchar(150),
@noidung nvarchar(600),
@mota nvarchar(150),
@matl int,
@urlanh varchar(100),
@ma int
as
update tblbaibao set stieude = @tieude, snoidung = @noidung , smota = @mota,
 fk_itheloaiid = @matl, surlanh = @urlanh
where pk_ibaivietid = @ma

create proc update_Baibao2
@tieude nvarchar(150),
@noidung nvarchar(600),
@mota nvarchar(150),
@matl int,
@ma int
as
update tblbaibao set stieude = @tieude, snoidung = @noidung , smota = @mota,
 fk_itheloaiid = @matl
where pk_ibaivietid = @ma

create proc update_Users
@ma int,
@hoten nvarchar(35),
@gt bit ,
@ns datetime,
@quyen int
as
update tbluser set shoten = @hoten , bGioitinh = @gt, dngaysinh = @ns, imaquyen = @quyen
where pk_iuserid = @ma

create proc delete_Baibao
@ma int
as
delete from tblBaiBao where pk_ibaivietid = @ma

create proc select_nhomquyen_by_user
as

create proc delete_Users
@ma int
as
delete from tblUSer where pk_iuserid = @ma

create proc select_Baibao_by_user
@ma int
as
select a.bduyet,a.fk_itheloaiid, b.stentheloai, a.stieude, a.snoidung,a.smota,a.surlanh,a.dngaydang,
a.ilanxem, c.shoten, a.btrangthai, a.pk_ibaivietid  from tblBaiBao a, tbltheloai b,
tbluser c
 where a.fk_itheloaiid = b.pk_itheloai and a.iuserdang = c.pk_iuserid and a.iuserdang  = @ma

 exec select_Baibao_by_user 1 

 select * from tbluser

 create proc select_quyen_by_uID
 @ma int 
 as
 select c.pk_inhomquyenid from tbluser a, tblUser_nhomquyen b , tblNhomquyen c
 where a.pk_iuserid = 1 and a.pk_iuserid = b.fk_iuserid and fk_inhomquyenid = pk_inhomquyenid

  select * from tbluser , tblUser_nhomquyen  
 where pk_iuserid = 1 and pk_iuserid = fk_iuserid

 exec select_quyen_by_uID 1

  select * from tblUser_nhomquyen  


 create proc select_unq_by_uID
 @ma int 
 as
 select c.pk_inhomquyenid from tbluser a, tblUser_nhomquyen b , tblNhomquyen c
 where a.pk_iuserid = @ma and a.pk_iuserid = b.fk_iuserid and fk_inhomquyenid = pk_inhomquyenid

 create proc select_nhomquyen_by_user
 @ma int 
 as
 select c.pk_inhomquyenid from tbluser a, tblUser_nhomquyen b , tblNhomquyen c
 where a.pk_iuserid = @ma and a.pk_iuserid = b.fk_iuserid and fk_inhomquyenid = pk_inhomquyenid


 exec select_unq_by_uID 1

 create proc select_Users_by_ID1
 as
 select * from tbluser

 alter proc select_Theloai_ByPK
 @ma int
 as
 select pk_itheloai, stentheloai from tblTheLoai

 create proc select_Baibao_by_Theloai
 @ma int
 as
 select a.fk_itheloaiid, b.stentheloai, a.stieude, a.snoidung,a.smota,a.surlanh,a.dngaydang,
a.ilanxem, c.shoten, a.btrangthai, a.pk_ibaivietid  from tblBaiBao a, tbltheloai b,
tbluser c
 where a.fk_itheloaiid = b.pk_itheloai and a.iuserdang = c.pk_iuserid and b.pk_itheloai  = @ma

 select * from tblBaiBao
 select * from tblUSer


 create proc duyet_Baibao
 @ma int 
 as
 update tblBaiBao set bduyet = 1 where pk_ibaivietid = @ma


 --tim quyen theo id user
 create proc select_quyen_by_userid
 @ma int
 as
 select imaquyen from tbluser where pk_iuserid = @ma

 exec select_quyen_by_userid 1
 
 create proc select_quyen
 as
 select * from tblquyen


 select * from tblbaibao

create proc select_Baibao_daduyet_newsest
 as
 select top 5 * from tblBaiBao, tblTheLoai where pk_itheloai = fk_itheloaiid
 and bduyet =1
 order by dngaydang Desc

alter proc select_Baibao_daduyet
 as
 select * from tblBaiBao, tblTheLoai where
  pk_itheloai = fk_itheloaiid