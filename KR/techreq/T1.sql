CREATE TABLE [dbo].[T1](
	[K] [int] NOT NULL,
	[dt] [datetime] NULL,
	[author] [varchar](50) NULL,
	[descr] [varchar](max) NULL, 
    CONSTRAINT [PK_T1] PRIMARY KEY ([K]),
	)