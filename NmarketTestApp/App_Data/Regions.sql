SET IDENTITY_INSERT [dbo].[Region] ON;
INSERT INTO [dbo].[Region](id, RegionId, Name) 
VALUES 
  (
    newid(), 1, N'Санкт-Петербург'
  );
INSERT INTO [dbo].[Region](id, RegionId, Name) 
VALUES 
  (
    newid(), 5001, N'Ленинградская область'
  );
 SET IDENTITY_INSERT [dbo].[Region] OFF;