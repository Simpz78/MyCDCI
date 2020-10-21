CREATE TABLE FattureRicevute(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeFile] [nvarchar](150) NULL,
	[Hash] [nvarchar](max) NULL,
	[CodiceDestinatario] [nvarchar](50) NULL,
	[Formato] [nvarchar](50) NULL,
	[MessageId] [nvarchar](50) NULL,
	[IdentificativoSdi] [nvarchar](50) NULL,
	[EsitoSpedizione] [bit] NULL,
	[ErroreSpedizione] [nvarchar](max) NULL,
	[data] [smalldatetime] NULL,
	[IdFattureZIP] [int] NULL,
 CONSTRAINT [PK_FattureRicevute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 
