USE [projeto-evolucional]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 16/06/2021 18:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aluno_Disciplina]    Script Date: 16/06/2021 18:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno_Disciplina](
	[IdAluno] [int] NOT NULL,
	[IdDisciplina] [int] NOT NULL,
	[Nota] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Aluno_Disciplina] PRIMARY KEY CLUSTERED 
(
	[IdAluno] ASC,
	[IdDisciplina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disciplina]    Script Date: 16/06/2021 18:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disciplina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Disciplina] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/06/2021 18:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
	[Hash] [varchar](100) NOT NULL,
	[Salt] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Login], [Senha], [Hash], [Salt]) VALUES (1, N'candidato-evolucional', N'123456', N'FRoh6HTPTN1OwLmO+sxPivO72QGqL1Ew/sPo3X3+b5Y=', N'Ucg3VyzkjDkCzLXBo+8/qr8tM7TzuRIKwrSfNzzrrwI=')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Aluno_Disciplina]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Disciplina_Aluno] FOREIGN KEY([IdAluno])
REFERENCES [dbo].[Aluno] ([Id])
GO
ALTER TABLE [dbo].[Aluno_Disciplina] CHECK CONSTRAINT [FK_Aluno_Disciplina_Aluno]
GO
ALTER TABLE [dbo].[Aluno_Disciplina]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Disciplina_Disciplina] FOREIGN KEY([IdDisciplina])
REFERENCES [dbo].[Disciplina] ([Id])
GO
ALTER TABLE [dbo].[Aluno_Disciplina] CHECK CONSTRAINT [FK_Aluno_Disciplina_Disciplina]
GO
