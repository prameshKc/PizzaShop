USE [PizzaOrderingSystem]
GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[PizzaID] [int] IDENTITY(1,1) NOT NULL,
	[PizzaName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
	[photo] [nvarchar](max) NULL,
	[BasePrice] [decimal](8, 2) NOT NULL,
	[PizzeriaID] [int] NOT NULL,
 CONSTRAINT [PK__Pizza__0B6012FD2429CA3E] PRIMARY KEY CLUSTERED 
(
	[PizzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaOrder]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaOrder](
	[OrderID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerAddress] [varchar](100) NOT NULL,
	[TotalPrice] [decimal](8, 2) NOT NULL,
	[PizzeriaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaOrderItem]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaOrderItem](
	[OrderItemID] [int] NOT NULL,
	[PizzaID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Toppings] [varchar](100) NULL,
	[Price] [decimal](8, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizzeria]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzeria](
	[PizzeriaID] [int] IDENTITY(1,1) NOT NULL,
	[PizzeriaName] [varchar](50) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[Phone] [nvarchar](20) NULL,
 CONSTRAINT [PK__Pizzeria__24EC5FB435E7A8CC] PRIMARY KEY CLUSTERED 
(
	[PizzeriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzeriaUserLogin]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzeriaUserLogin](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[PizzeriaID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Pizza_Pizzeria] FOREIGN KEY([PizzeriaID])
REFERENCES [dbo].[Pizzeria] ([PizzeriaID])
GO
ALTER TABLE [dbo].[Pizza] CHECK CONSTRAINT [FK_Pizza_Pizzeria]
GO
ALTER TABLE [dbo].[PizzaOrder]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrder_Pizzeria] FOREIGN KEY([PizzeriaID])
REFERENCES [dbo].[Pizzeria] ([PizzeriaID])
GO
ALTER TABLE [dbo].[PizzaOrder] CHECK CONSTRAINT [FK_PizzaOrder_Pizzeria]
GO
ALTER TABLE [dbo].[PizzaOrderItem]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrderItem_Pizza] FOREIGN KEY([PizzaID])
REFERENCES [dbo].[Pizza] ([PizzaID])
GO
ALTER TABLE [dbo].[PizzaOrderItem] CHECK CONSTRAINT [FK_PizzaOrderItem_Pizza]
GO
ALTER TABLE [dbo].[PizzaOrderItem]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrderItem_PizzaOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[PizzaOrder] ([OrderID])
GO
ALTER TABLE [dbo].[PizzaOrderItem] CHECK CONSTRAINT [FK_PizzaOrderItem_PizzaOrder]
GO
/****** Object:  StoredProcedure [dbo].[Pizza_CRUD]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pizza_CRUD]
(
    @PizzaID int = NULL,
    @PizzaName varchar(50) = NULL,
	@PizzeriaName varchar(50) = NULL,
    @Description varchar(200) = NULL,
    @Photo nvarchar(max) = NULL,
    @BasePrice decimal(8,2) = NULL,
    @PizzeriaID int = NULL,
	@Id int=NULL,
	@UserName nvarchar(55)=NULL,
	@CreatedBy nvarchar(55)=NULL,
    @Flag varchar(10)
)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @Flag = 'INSERT'
    BEGIN
        INSERT INTO Pizza (PizzaName, Description, Photo, BasePrice, PizzeriaID)
        VALUES (@PizzaName, @Description, @Photo, @BasePrice, @PizzeriaID);
		select * from Pizza where PizzaID=@@IDENTITY
    END
    
    IF @Flag = 'UPDATE'
    BEGIN
        UPDATE Pizza
        SET PizzaName = ISNULL(@PizzaName, PizzaName),
            Description = ISNULL(@Description, Description),
			Photo = ISNULL(@Photo, (select Photo from Pizza where PizzaID=@PizzaID)),
            BasePrice = ISNULL(@BasePrice, BasePrice),
            PizzeriaID = ISNULL(@PizzeriaID, PizzeriaID)
        WHERE PizzaID = @PizzaID;
		select * from Pizza where PizzaID=@PizzaID
    END
    
    IF @Flag = 'DELETE'
    BEGIN
        DELETE FROM Pizza
        WHERE PizzaID = @PizzaID;
    END
    
    IF @Flag = 'GET'
    BEGIN
        SELECT p.*,r.PizzeriaName
        FROM Pizza p inner join Pizzeria r on p.PizzeriaID= r.PizzeriaID
		where p.PizzeriaID= (case when @PizzeriaID is not null or @PizzeriaID!=0 then @PizzeriaID else p.PizzeriaID end)
    END
	 IF @Flag = 'GETBYID'
    BEGIN
        SELECT   p.*,r.PizzeriaName
        FROM Pizza p inner join Pizzeria r on p.PizzeriaID= r.PizzeriaID
         where PizzaID=@Id
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Pizzeria_CRUD]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pizzeria_CRUD]
    @PizzeriaID int = NULL,
    @PizzeriaName varchar(50) = NULL,
    @Location varchar(100) = NULL,
    @Phone nvarchar(20) = NULL,
	@Id int=NULL,
	@UserName nvarchar(55)=NULL,
	@CreatedBy nvarchar(55)=NULL,
    @Flag varchar(10)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Flag = 'INSERT')
    BEGIN
        INSERT INTO Pizzeria (PizzeriaID,PizzeriaName, Location, Phone)
        VALUES (@PizzeriaID,@PizzeriaName, @Location, @Phone);
		SELECT * FROM Pizzeria where PizzeriaID=@@IDENTITY
    END;
	 IF (@Flag = 'SEED_DATA')
    BEGIN
         SET IDENTITY_INSERT Pizzeria ON
         INSERT INTO Pizzeria (PizzeriaID,PizzeriaName, Location, Phone)
         VALUES (@PizzeriaID,@PizzeriaName, @Location, @Phone);
		 SELECT * FROM Pizzeria where PizzeriaID=@@IDENTITY

		 SET IDENTITY_INSERT Pizzeria OFF

    END;

    IF (@Flag = 'UPDATE')
    BEGIN
        UPDATE Pizzeria
        SET PizzeriaName = @PizzeriaName, Location = @Location, Phone = @Phone
        WHERE PizzeriaID = @PizzeriaID;
		 SELECT * FROM Pizzeria WHERE  PizzeriaID = @PizzeriaID
    END;

    IF (@Flag = 'DELETE')
    BEGIN
        DELETE FROM Pizzeria
        WHERE PizzeriaID = @PizzeriaID;
    END;

    IF (@Flag = 'GET')
    BEGIN
        SELECT * FROM Pizzeria
        WHERE (@PizzeriaID IS NULL OR PizzeriaID = @PizzeriaID)
        AND (@PizzeriaName IS NULL OR PizzeriaName = @PizzeriaName)
        AND (@Location IS NULL OR Location = @Location)
        AND (@Phone IS NULL OR Phone = @Phone);
    END;
	IF (@Flag = 'GETBYID')
    BEGIN
        SELECT * FROM Pizzeria
        WHERE  PizzeriaID = @Id
       
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[PizzeriaUserLoginCRUD]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PizzeriaUserLoginCRUD]
    @UserID int = NULL,
    @UserName varchar(50) = NULL,
    @Password varchar(50) = NULL,
    @PizzeriaID int = NULL,
	@Id int=NULL,
	@CreatedBy nvarchar(55)=NULL,
    @Flag varchar(10)
AS
BEGIN
    IF @Flag = 'INSERT'
    BEGIN
        INSERT INTO PizzeriaUserLogin (UserName, Password, PizzeriaID)
        VALUES (@UserName, @Password, @PizzeriaID);
    END
	IF @Flag = 'SEED_DATA'
    BEGIN
	   SET IDENTITY_INSERT  PizzeriaUserLogin on
        INSERT INTO PizzeriaUserLogin (UserID, UserName, Password, PizzeriaID)
        VALUES (@UserID, @UserName, @Password, @PizzeriaID);
		select 1;
		SET IDENTITY_INSERT  PizzeriaUserLogin off

    END
    ELSE IF @Flag = 'Update'
    BEGIN
        UPDATE PizzeriaUserLogin
        SET Password = @Password
        WHERE UserID = @UserID;
    END
    ELSE IF @Flag = 'Delete'
    BEGIN
        DELETE FROM PizzeriaUserLogin
        WHERE UserID = @UserID;
    END
    ELSE IF @Flag = 'LOGIN'
    BEGIN

        SELECT *
        FROM PizzeriaUserLogin
        WHERE UserName = @UserName AND Password = @Password

       
    END
	 ELSE IF @Flag = 'GET'
    BEGIN

        SELECT *
        FROM PizzeriaUserLogin

       
    END

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPiza]    Script Date: 3/8/2023 12:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllPiza]
as
BEGIN
   SELECT * from Pizza
END
GO
