CREATE TABLE [Users] (
  [UserID] int PRIMARY KEY IDENTITY(100, 1),
  [FullName] varchar(25),
  [LoginID] varchar(30),
  [Password] varchar(30),
  [DateOfJoin] date,
  [Address] varchar(200),
  [Discontinued] bit,
  [IsAdmin] bit
)
GO

CREATE TABLE [Products] (
  [ProductID] int PRIMARY KEY IDENTITY(100, 1),
  [ProductName] varchar(20),
  [Decription] varchar(300),
  [UnitPrice] decimal
)
GO

CREATE TABLE [Campaign] (
  [CampaignID] int PRIMARY KEY IDENTITY(100, 1),
  [Name] varchar(30),
  [Venue] varchar(200),
  [AssignedTo] int,
  [StartedOn] date,
  [CompletedOn] date,
  [IsOpen] bit
)
GO

CREATE TABLE [Leads] (
  [LeadID] int PRIMARY KEY IDENTITY(100, 1),
  [CampaignID] int,
  [ConsumerName] varchar(30),
  [EmailAddress] varchar(30),
  [PhoneNo] varchar(10),
  [PreferredMoC] varchar(5),
  [DateApproached] Date,
  [ProductID] int,
  [Status] varchar(4)
)
GO

CREATE TABLE [Sales] (
  [OrderID] int PRIMARY KEY IDENTITY(100, 1),
  [LeadID] int,
  [ShippingAddress] varchar(200),
  [BillingAddress] varchar(200),
  [CreaterON] date,
  [PaymentMode] varchar(10)
)
GO

ALTER TABLE [Campaign] ADD FOREIGN KEY ([AssignedTo]) REFERENCES [Users] ([UserID])
GO

ALTER TABLE [Leads] ADD FOREIGN KEY ([CampaignID]) REFERENCES [Campaign] ([CampaignID])
GO

ALTER TABLE [Leads] ADD FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID])
GO

ALTER TABLE [Sales] ADD FOREIGN KEY ([LeadID]) REFERENCES [Leads] ([LeadID])
GO
