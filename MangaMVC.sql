CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Manga] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [ReleaseYear] int NOT NULL,
  [VolumeCount] int NOT NULL,
  [ChapterCount] int NOT NULL

)
GO

CREATE TABLE [UserMangaReadList] (
  [Id] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserProfileId] int NOT NULL,
  [MangaId] int NOT NULL,
  [UserChapterCount] int NOT NULL

  CONSTRAINT [FK_UserMangaRealList_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
)
GO