USE [master]
GO

CREATE DATABASE [SeguroVeiculos]
GO
USE [SeguroVeiculos]
GO
/****** Object:  Table [dbo].[Segurado]    Script Date: 09/07/2020 03:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segurado](
	[idSegurado] [int] IDENTITY(1,1) NOT NULL,
	[nomeSegurado] [varchar](100) NULL,
	[cpf] [varchar](11) NULL,
	[idade] [int] NULL,
 CONSTRAINT [PK_Segurado] PRIMARY KEY CLUSTERED 
(
	[idSegurado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 09/07/2020 03:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[idSeguro] [int] IDENTITY(1,1) NOT NULL,
	[idVeiculo] [int] NOT NULL,
	[idSegurado] [int] NOT NULL,
	[TaxaRisco] [numeric](18, 2) NOT NULL,
	[PremioRisco] [numeric](18, 2) NOT NULL,
	[PremioPuro] [numeric](18, 2) NOT NULL,
	[PremioComercial] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[idSeguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Veiculo]    Script Date: 09/07/2020 03:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veiculo](
	[idVeiculo] [int] IDENTITY(1,1) NOT NULL,
	[valorVeiculo] [numeric](18, 2) NULL,
	[marcaModelo] [varchar](100) NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[idVeiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Seguro]  WITH CHECK ADD  CONSTRAINT [FK_Seguro_Segurado] FOREIGN KEY([idSegurado])
REFERENCES [dbo].[Segurado] ([idSegurado])
GO
ALTER TABLE [dbo].[Seguro] CHECK CONSTRAINT [FK_Seguro_Segurado]
GO
ALTER TABLE [dbo].[Seguro]  WITH CHECK ADD  CONSTRAINT [FK_Seguro_Veiculo] FOREIGN KEY([idVeiculo])
REFERENCES [dbo].[Veiculo] ([idVeiculo])
GO
ALTER TABLE [dbo].[Seguro] CHECK CONSTRAINT [FK_Seguro_Veiculo]
GO
USE [master]
GO
ALTER DATABASE [SeguroVeiculos] SET  READ_WRITE 
GO
