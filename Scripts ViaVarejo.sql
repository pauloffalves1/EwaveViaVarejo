CREATE DATABASE ViaVarejoDB;
USE ViaVarejoDB;

CREATE TABLE [dbo].[FRIEND](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](255) NULL,
	[LATITUDE] [varchar](100) NULL,
	[LONGITUDE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FRIEND] ON 

INSERT [dbo].[FRIEND] ([ID], [NAME], [GEOGRAPHYPOINT], [LATITUDE], [LONGITUDE]) VALUES (1, N'Paulo', NULL, N'-23.7023451', N'-46.54155939999998')
INSERT [dbo].[FRIEND] ([ID], [NAME], [GEOGRAPHYPOINT], [LATITUDE], [LONGITUDE]) VALUES (2, N'Francisco', NULL, N'-23.5579169', N'-46.65009599999996')
INSERT [dbo].[FRIEND] ([ID], [NAME], [GEOGRAPHYPOINT], [LATITUDE], [LONGITUDE]) VALUES (3, N'Fabiana', NULL, N'-22.9236575', N'-47.019509400000004')
INSERT [dbo].[FRIEND] ([ID], [NAME], [GEOGRAPHYPOINT], [LATITUDE], [LONGITUDE]) VALUES (4, N'S�nia', NULL, N'-23.4820917', N'-46.62805639999999')
SET IDENTITY_INSERT [dbo].[FRIEND] OFF