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
	_Kpublic varbinary(max),
	_Kprivate varbinary(max)
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

create procedure SP_SEL_All_ACCOUNTS
as
	begin
		select _Email, _Fullname from Account
	end

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
		where
			_Email = @Email
		select * from Account where _Email = @Email
	end
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

create procedure SP_SIGN_UP
(
	@Email varchar(100),
	@Password varbinary(max),
	@Dob varchar(20),
	@Fullname varchar(200),
	@Phone varchar(20),
	@Address varchar(200)

)
as
	Begin
		declare @E_exists int;
		set @E_exists = (select count(*) from Account where Account._Email = @Email)
		if @E_exists = 0
			begin
				insert into Account(_Email, _Password, _Phone, _Fullname, _Dob, _Address)
				values (@Email, @Password, @Phone, @Fullname, @Dob, @Address) 
				select 1 return
			end
		else
			select 0 return
	end

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

select * from Account