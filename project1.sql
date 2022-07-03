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
	_SessionKey varchar(100) not null,
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

drop procedure if exists SP_ADD_MFILE
go
create procedure SP_ADD_MFILE
(
	@FromEmail varchar(100),
	@DestEmail varchar(100),
	@SessionKey varchar(100),
	@FileName varchar(200)
)
as
	Begin
		insert into MFile
		values (@FromEmail, @DestEmail, @SessionKey, @FileName)
	End

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

drop procedure if exists SP_SEL_PUBLICKEY
go
create procedure SP_SEL_PUBLICKEY
(
	@Email varchar(100)
)
as
	Begin
		select _Kpublic from RSA_KEY
		where RSA_KEY._Email= @Email
	End

go

drop procedure if exists SP_SEL_PRIVATEKEY
go
create procedure SP_SEL_PRIVATEKEY
(
	@Email varchar(100)
)
as
	Begin
		select _Kprivate from RSA_KEY
		where RSA_KEY._Email = @Email
	End
go

drop procedure if exists SP_GET_SESSIONKEY
go
create procedure SP_GET_SESSIONKEY
(
	@Email varchar(100),
	@FileName varchar(200)
)
as
	Begin
		select f._SessionKey from MFile as f
		where f._DestEmail =@Email and f._fileName = @FileName
	End

go
