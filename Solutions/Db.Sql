if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AIABP') and o.name = 'FK_AIABP_REFERENCE_PLANBOOK')
alter table AIABP
   drop constraint FK_AIABP_REFERENCE_PLANBOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AIAPCP') and o.name = 'FK_AIAPCP_REFERENCE_PLANBOOK')
alter table AIAPCP
   drop constraint FK_AIAPCP_REFERENCE_PLANBOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BCCCL3') and o.name = 'FK_BCCCL3_REFERENCE_PLANBOOK')
alter table BCCCL3
   drop constraint FK_BCCCL3_REFERENCE_PLANBOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BCEGS') and o.name = 'FK_BCEGS_REFERENCE_PLANBOOK')
alter table BCEGS
   drop constraint FK_BCEGS_REFERENCE_PLANBOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Customer') and o.name = 'FK_CUSTOMER_REFERENCE_USER')
alter table Customer
   drop constraint FK_CUSTOMER_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Employee') and o.name = 'FK_EMPLOYEE_REFERENCE_DEPARTME')
alter table Employee
   drop constraint FK_EMPLOYEE_REFERENCE_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Employee') and o.name = 'FK_EMPLOYEE_REFERENCE_USER')
alter table Employee
   drop constraint FK_EMPLOYEE_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Employee') and o.name = 'FK_EMPLOYEE_REFERENCE_CONFIG')
alter table Employee
   drop constraint FK_EMPLOYEE_REFERENCE_CONFIG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Order"') and o.name = 'FK_ORDER_REFERENCE_PRODUCT')
alter table "Order"
   drop constraint FK_ORDER_REFERENCE_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Order"') and o.name = 'FK_ORDER_REFERENCE_PLANBOOK')
alter table "Order"
   drop constraint FK_ORDER_REFERENCE_PLANBOOK
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PlanBook') and o.name = 'FK_PLANBOOK_REFERENCE_CONTACT')
alter table PlanBook
   drop constraint FK_PLANBOOK_REFERENCE_CONTACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PlanBook') and o.name = 'FK_PLANBOOK_REFERENCE_PRODUCT')
alter table PlanBook
   drop constraint FK_PLANBOOK_REFERENCE_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SaleEmployee') and o.name = 'FK_SALEEMPL_REFERENCE_EMPLOYEE')
alter table SaleEmployee
   drop constraint FK_SALEEMPL_REFERENCE_EMPLOYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Subscribe') and o.name = 'FK_SUBSCRIB_REFERENCE_PLANBOOK')
alter table Subscribe
   drop constraint FK_SUBSCRIB_REFERENCE_PLANBOOK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AIABP')
            and   type = 'U')
   drop table AIABP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AIAPCP')
            and   type = 'U')
   drop table AIAPCP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BCCCL3')
            and   type = 'U')
   drop table BCCCL3
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BCEGS')
            and   type = 'U')
   drop table BCEGS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Config')
            and   type = 'U')
   drop table Config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Contact')
            and   type = 'U')
   drop table Contact
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Customer')
            and   type = 'U')
   drop table Customer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Employee')
            and   type = 'U')
   drop table Employee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Order"')
            and   type = 'U')
   drop table "Order"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PlanBook')
            and   type = 'U')
   drop table PlanBook
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Product')
            and   type = 'U')
   drop table Product
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SaleEmployee')
            and   type = 'U')
   drop table SaleEmployee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Subscribe')
            and   type = 'U')
   drop table Subscribe
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"User"')
            and   type = 'U')
   drop table "User"
go

/*==============================================================*/
/* Table: AIABP                                                 */
/*==============================================================*/
create table AIABP (
   PlanId               varchar(50)          not null,
   Amount               money                not null,
   Single               int                  not null,
   constraint PK_AIABP primary key (PlanId)
)
go

/*==============================================================*/
/* Table: AIAPCP                                                */
/*==============================================================*/
create table AIAPCP (
   PlanId               varchar(50)          not null,
   IsSmoke              bit                  not null,
   Amount               money                not null,
   MoneyType            int                  not null,
   constraint PK_AIAPCP primary key (PlanId)
)
go

/*==============================================================*/
/* Table: BCCCL3                                                */
/*==============================================================*/
create table BCCCL3 (
   PlanId               varchar(50)          not null,
   IsSmoke              bit                  not null,
   Amount               money                not null,
   MoneyType            int                  not null,
   constraint PK_BCCCL3 primary key (PlanId)
)
go

/*==============================================================*/
/* Table: BCEGS                                                 */
/*==============================================================*/
create table BCEGS (
   PlanId               varchar(50)          not null,
   Amount               money                not null,
   Single               int                  not null,
   constraint PK_BCEGS primary key (PlanId)
)
go

/*==============================================================*/
/* Table: Config                                                */
/*==============================================================*/
create table Config (
   Id                   int                  not null,
   Type                 varchar(10)          not null,
   KeyName              varchar(20)          not null,
   Value                varchar(200)         not null,
   DataType             int                  not null,
   constraint PK_CONFIG primary key (Id)
)
go

/*==============================================================*/
/* Table: Contact                                               */
/*==============================================================*/
create table Contact (
   Id                   int                  not null,
   CustomerId           varchar(50)          not null,
   Name                 nvarchar(20)         not null,
   PhoneNum             varchar(20           not null,
   IdentityNum          char(18)             not null,
   CreateTime           datetime             not null,
   Sex                  int                  not null,
   Age                  int                  not null,
   constraint PK_CONTACT primary key (Id)
)
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   Id                   varchar(50)          not null,
   GroupId              int                  not null,
   Name                 nvarchar(20)         null,
   Sex                  int                  null,
   PhoneNum             varchar(20)          null,
   MobileNum            varchar(20)          null,
   Email                varchar(50)          null,
   SaleId               int                  null,
   CreateTime           datetime             not null,
   ModifyTime           datetime             not null,
   constraint PK_CUSTOMER primary key (Id)
)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   Id                   int                  identity,
   Code                 varchar(20)          null,
   Name                 varchar(50)          not null,
   SuperId              int                  not null,
   constraint PK_DEPARTMENT primary key (Id)
)
go

/*==============================================================*/
/* Table: Employee                                              */
/*==============================================================*/
create table Employee (
   UserId               varchar(50)          not null,
   DepartmentId         int                  null,
   Id                   varchar(50)          null,
   Con_Id               int                  null,
   Name                 nvarchar(20)         null,
   Position             int                  null,
   State                int                  null,
   CreateTime           datetime             null,
   CreateUser           uniqueidentifier     null,
   Role                 int                  null,
   constraint PK_EMPLOYEE primary key (UserId)
)
go

/*==============================================================*/
/* Table: "Order"                                               */
/*==============================================================*/
create table "Order" (
   Id                   varchar(50)          not null,
   Code                 varchar(20)          not null,
   CUstomerId           varchar(50)          not null,
   ProductId            int                  not null,
   PlanId               varchar(50)          not null,
   CreateUser           varchar(50)          not null,
   CreateTime           datetime             not null,
   State                int                  not null,
   TotalAmount          money                not null,
   constraint PK_ORDER primary key (Id)
)
go

/*==============================================================*/
/* Table: PlanBook                                              */
/*==============================================================*/
create table PlanBook (
   Id                   varchar(50)          not null,
   Code                 varchar(20)          not null,
   ProductId            int                  not null,
   CustomerId           varchar(50)          not null,
   ContactId            int                  not null,
   CreateTime           datetime             not null,
   Feedback             datetime             null,
   Step                 int                  not null,
   CreatUser            varchar(50)          not null,
   CreateUserType       int                  not null,
   constraint PK_PLANBOOK primary key (Id)
)
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   Id                   int                  identity,
   Name                 varchar(20)          null,
   constraint PK_PRODUCT primary key (Id)
)
go

/*==============================================================*/
/* Table: SaleEmployee                                          */
/*==============================================================*/
create table SaleEmployee (
   Id                   int                  not null,
   UserId               varchar(50)          null,
   EmployeeId           varchar(50)          not null,
   SaleCode             varchar(20)          not null,
   SuperId              int                  not null,
   AreaId               int                  null,
   CreateTime           datetime             not null,
   State                int                  not null,
   constraint PK_SALEEMPLOYEE primary key (Id)
)
go

/*==============================================================*/
/* Table: Subscribe                                             */
/*==============================================================*/
create table Subscribe (
   Id                   varchar(50)          not null,
   Code                 varchar(20)          not null,
   PalnId               varchar(50)          not null,
   Source               int                  not null,
   CreateTime           datetime             not null,
   IsVisit              bit                  null,
   VisitUser            varchar(50)          null,
   State                int                  null,
   VisitTime            datetime             null,
   constraint PK_SUBSCRIBE primary key (Id)
)
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   Id                   varchar(50)          not null,
   UserCode             varchar(20)          null,
   UserName             nvarchar(20)         null,
   PhoneNum             varchar(11)          null,
   OpenId               varchar(50)          null,
   Password             varchar(50)          null,
   CreateTime           datetime             not null,
   SourceType           int                  not null,
   constraint PK_USER primary key (Id)
)
go

alter table AIABP
   add constraint FK_AIABP_REFERENCE_PLANBOOK foreign key (PlanId)
      references PlanBook (Id)
go

alter table AIAPCP
   add constraint FK_AIAPCP_REFERENCE_PLANBOOK foreign key (PlanId)
      references PlanBook (Id)
go

alter table BCCCL3
   add constraint FK_BCCCL3_REFERENCE_PLANBOOK foreign key (PlanId)
      references PlanBook (Id)
go

alter table BCEGS
   add constraint FK_BCEGS_REFERENCE_PLANBOOK foreign key (PlanId)
      references PlanBook (Id)
go

alter table Customer
   add constraint FK_CUSTOMER_REFERENCE_USER foreign key (Id)
      references "User" (Id)
go

alter table Employee
   add constraint FK_EMPLOYEE_REFERENCE_DEPARTME foreign key (DepartmentId)
      references Department (Id)
go

alter table Employee
   add constraint FK_EMPLOYEE_REFERENCE_USER foreign key (Id)
      references "User" (Id)
go

alter table Employee
   add constraint FK_EMPLOYEE_REFERENCE_CONFIG foreign key (Con_Id)
      references Config (Id)
go

alter table "Order"
   add constraint FK_ORDER_REFERENCE_PRODUCT foreign key (ProductId)
      references Product (Id)
go

alter table "Order"
   add constraint FK_ORDER_REFERENCE_PLANBOOK foreign key (PlanId)
      references PlanBook (Id)
go

alter table PlanBook
   add constraint FK_PLANBOOK_REFERENCE_CONTACT foreign key (ContactId)
      references Contact (Id)
go

alter table PlanBook
   add constraint FK_PLANBOOK_REFERENCE_PRODUCT foreign key (ProductId)
      references Product (Id)
go

alter table SaleEmployee
   add constraint FK_SALEEMPL_REFERENCE_EMPLOYEE foreign key (UserId)
      references Employee (UserId)
go

alter table Subscribe
   add constraint FK_SUBSCRIB_REFERENCE_PLANBOOK foreign key (PalnId)
      references PlanBook (Id)
go
