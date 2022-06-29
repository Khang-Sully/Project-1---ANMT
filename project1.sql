use master

create database newBD_Account

go
use newBD_Account

go
create table Account
(
	_Email varchar(100) not null,
	_Password varbinary(max) not null,
	_Phone varchar(20),
	_Fullname varchar(200) not null,
	_Dob varchar(20),
	_Address varchar(200)
	constraint PK_AC primary key(_Email)
)

create table RSA_KEY
(
	_Email varchar(100) not null,
	_Passphare varbinary(max),
	_Kpublic varchar(200),
	_Kprivate varchar(200)
	constraint PK_RSA_Key primary key(_Email)
)

create table MFile
(
	_FromEmail varchar(100) not null,
	_DestEmail varchar(100) not null,
	_fileName nvarchar(200) not null
	constraint PK_FILE primary key(_FromEmail, _DestEmail, _fileName)
)
go

alter table RSA_KEY
add constraint FK_KEY_AC foreign key(_Email) references ACCOUNT(_Email)

alter table MFile
add constraint FK_FILE_AC1 foreign key(_FromEmail) references ACCOUNT(_Email)

alter table MFile
add constraint FK_FILE_AC2 foreign key(_DestEmail) references ACCOUNT(_Email)

go

drop procedure if exists SP_INS_ACCOUNT
go
create procedure SP_INS_ACCOUNT
(
	@Email varchar(100),
	@Password varbinary(max),
	@Phone varchar(20),
	@Fullname varchar(200),
	@Dob varchar(20),
	@Address varchar(200)
)
as
	Begin
		insert into Account
		values (@Email, @Password, @Phone, @Fullname, @Dob, @Address)
	end

go

drop procedure if exists SP_SEL_All_ACCOUNTS
go
create procedure SP_SEL_All_ACCOUNTS
as
	begin
		select * from Account
	end

go

drop procedure if exists SP_SEL_ACCOUNT
go
create procedure SP_SEL_ACCOUNT
(
	@Email varchar(100)
)
as
	begin
		select _Email, _Password, _Phone,_Fullname, _Dob, _Address from Account where Account._Email = @Email
	end

go

drop procedure if exists SP_UPDATE_ACCOUNT
go
create procedure SP_UPDATE_ACCOUNT
(
	@Email varchar(100),
	@Password varbinary(max),
	@Phone varchar(20),
	@Fullname varchar(200),
	@Dob varchar(20),
	@Address varchar(200) 
)
as
	Begin 
		update Account
		set
			_Password = @Password,
			_Phone = @Phone,
			_Fullname = @Fullname,
			_Dob = @Dob,
			_Address = @Address
		from Account where _Email = @Email
	end
go

drop procedure if exists SP_LOG_IN
go
create procedure SP_LOG_IN
(
	@Email varchar(100),
	@Password varbinary(max)
)
as
	begin
		select count(*) from Account where Account._Email = @Email and Account._Password = @Password
	end
go


drop procedure if exists SP_SIGN_UP
go
create procedure SP_SIGN_UP
(
	@Email varchar(100),
	@Password varbinary(max),
	@Dob varchar(20),
	@Fullname varchar(200),
	@Phone varchar(20),
	@Address varchar(200),
	@KPublic varchar(200),
	@KPrivate varchar(200)

)
as
	Begin
		declare @E_exists int;
		set @E_exists = (select count(*) from Account where Account._Email = @Email)
		if @E_exists = 0
			begin
				insert into Account(_Email, _Password, _Phone, _Fullname, _Dob, _Address)
				values (@Email, @Password, @Phone, @Fullname, @Dob, @Address) 
				insert into RSA_KEY(_Email, _Passphare, _Kpublic, _Kprivate)
				values (@Email, @Password, @KPublic, @KPrivate)
				select 1 return
			end
		else
			select 0 return
	end

go

/*
drop procedure if exists SP_SU_ADD_RSAKEY
go
create procedure SP_SU_ADD_RSAKEY
(
	@Email varchar(100),
	@Password varbinary(max),
	@Kpublic varbinary(max),
	@Kprivate varbinary(max)
)
as
	Begin
		insert into RSA_KEY(_Email, _Passphare, _Kpublic, _Kprivate)
		values (@Email, @Password, @Kpublic, @Kprivate)
	end
*/
select * from Account

--test Account: Email: "test@gmail.com" ; Password: 123
--exec sp_executesql N'exec SP_SIGN_UP @Email , @Password , @Phone , @Fullname , @Dob , @Address',N'@Email nvarchar(14),@Password varbinary(32),@Phone nvarchar(3),@Fullname nvarchar(6),@Dob nvarchar(3),@Address nvarchar(3)',@Email=N'test@gmail.com',@Password=0xA665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3,@Phone=N'123',@Fullname=N'Testet',@Dob=N'123',@Address=N'123'
