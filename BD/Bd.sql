USE [GoflyPrueba]
GO
/****** Object:  User [dante]    Script Date: 27/03/2023 17:36:11 ******/
CREATE USER [dante] FOR LOGIN [dante] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ACTIVITIES]    Script Date: 27/03/2023 17:36:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVITIES](
	[id_activities] [int] IDENTITY(1,1) NOT NULL,
	[create_date] [datetime] NULL,
	[activity] [nvarchar](20) NULL,
	[id_user] [int] NULL,
 CONSTRAINT [PK_ACTIVITIES] PRIMARY KEY CLUSTERED 
(
	[id_activities] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [nvarchar](20) NULL,
	[email] [nvarchar](20) NULL,
	[date_of_birth] [datetime] NULL,
	[phone_number] [int] NULL,
	[country_of_residence] [nvarchar](20) NULL,
	[permission_information] [bit] NULL,
	[name] [nvarchar](20) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACTIVITIES]  WITH CHECK ADD  CONSTRAINT [FK_ACTIVITIES_USER] FOREIGN KEY([id_user])
REFERENCES [dbo].[USER] ([id_user])
GO
ALTER TABLE [dbo].[ACTIVITIES] CHECK CONSTRAINT [FK_ACTIVITIES_USER]
GO
/****** Object:  StoredProcedure [dbo].[CreateActivity_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateActivity_sp]
    @create_date datetime,
	@activity nvarchar(20),
	@id_user int,
	@id_activities INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT 1 FROM [dbo].[USER] WHERE id_user = @id_user)
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO [dbo].[ACTIVITIES] (create_date, activity, id_user)
				VALUES (@create_date, @activity, @id_user)
				SET @id_activities = SCOPE_IDENTITY();
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			THROW;
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser_sp]
	@last_name nvarchar(20),
	@email nvarchar(20),
	@date_of_birth datetime,
	@phone_number int,
	@country_of_residence nvarchar(20),
	@permission_information bit,
	@name nvarchar(20),
	@id_user int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO [dbo].[USER] (last_name, email, date_of_birth, phone_number, country_of_residence, permission_information, name,estado)
			VALUES (@last_name, @email, @date_of_birth, @phone_number,
					@country_of_residence, @permission_information, @name,1)

			SET @id_user = SCOPE_IDENTITY();
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteActivity_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteActivity_sp]
    @id_activities INT
AS
BEGIN
    DELETE FROM [dbo].[ACTIVITIES] WHERE [id_activities] = @id_activities
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser_sp]
	@id_user int
AS
BEGIN

    --DELETE FROM [dbo].[USER] WHERE id_user = @id_user
	UPDATE [dbo].[USER] SET [estado]=0 WHERE id_user = @id_user;
END
GO
/****** Object:  StoredProcedure [dbo].[GetActivitiesByIdUser_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetActivitiesByIdUser_sp]
    @id_user INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[ACTIVITIES]
    WHERE [id_user] = @id_user
END
GO
/****** Object:  StoredProcedure [dbo].[GetActivitiesWithUsers]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActivitiesWithUsers]
AS
BEGIN
    SELECT a.[id_activities] AS Id,
           a.[create_date] AS CreateDate,
           a.[activity] AS ActivityName,
           u.[id_user] AS IdUser,
           u.[last_name] AS LastName,
           u.[email] AS Email,
           u.[date_of_birth] AS DateOfBirth,
           u.[phone_number] AS PhoneNumber,
           u.[country_of_residence] AS CountryOfResidence,
           u.[permission_information] AS PermissionInformation,
           u.[name] AS Name,
           u.[estado] AS Estado
    FROM [GoflyPrueba].[dbo].[ACTIVITIES] a
    INNER JOIN [GoflyPrueba].[dbo].[USER] u ON a.[id_user] = u.[id_user]
END
GO
/****** Object:  StoredProcedure [dbo].[GetActivity_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActivity_sp]
    @id_activities INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM [dbo].[ACTIVITIES] WHERE [id_activities] = @id_activities
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActivities_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActivities_sp]
AS
BEGIN
	SELECT * FROM [dbo].[ACTIVITIES]
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers_sp]
AS
BEGIN
	SET NOCOUNT ON; -- Mejora el rendimiento al evitar el envío de mensajes de recuento de filas

    SELECT [id_user] AS IdUser, [last_name] AS LastName, [email], [date_of_birth] AS DateOfBirth, [phone_number] AS PhoneNumber, [country_of_residence] AS CountryOfResidence, [permission_information] AS PermissionInformation, [name]
    FROM [dbo].[USER] -- Es mejor evitar usar calificaciones de tres partes en la consulta
	WHERE [estado] = 1
    ORDER BY [id_user]; -- Ordenar los registros es una buena práctica para mejorar la legibilidad y facilitar la búsqueda de datos
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUser_sp]
	@id_user int
AS
BEGIN
	SELECT * FROM [dbo].[USER] WHERE id_user = @id_user
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateActivity_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[UpdateActivity_sp]
	@id_activities int,
	@create_date datetime,
	@activity nvarchar(20),
	@id_user int

AS
BEGIN
	
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [dbo].[ACTIVITIES] SET create_date = @create_date, activity= @activity, id_user = @id_user
			WHERE id_activities = @id_activities;

			IF @@ROWCOUNT > 0
				SELECT 1 AS Result
			ELSE
				SELECT 0 AS Result
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser_sp]    Script Date: 27/03/2023 17:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser_sp]
	@id_user int,
	@last_name nvarchar(20),
	@email nvarchar(20),
	@date_of_birth datetime,
	@phone_number int,
	@country_of_residence nvarchar(20),
	@permission_information bit,
	@name nvarchar(20)
AS
BEGIN
	
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [dbo].[USER] SET last_name = @last_name, email = @email,
				date_of_birth = @date_of_birth, phone_number = @phone_number, 
				country_of_residence = @country_of_residence, permission_information = @permission_information, 
				name = @name WHERE id_user = @id_user

			IF @@ROWCOUNT > 0
				SELECT 1 AS Result
			ELSE
				SELECT 0 AS Result
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO
