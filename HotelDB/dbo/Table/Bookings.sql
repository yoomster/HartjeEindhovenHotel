CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomId] INT NOT NULL, 
    [GuestId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndData] DATETIME2 NOT NULL, 
    [CheckedIn] BIT NOT NULL DEFAULT 0, 
    [TotalCost] FLOAT NOT NULL, 
    CONSTRAINT [FK_Bookings_RoomId] FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
    CONSTRAINT [FK_Bookings_GuestId] FOREIGN KEY (GuestId) REFERENCES Guests(Id)
)
