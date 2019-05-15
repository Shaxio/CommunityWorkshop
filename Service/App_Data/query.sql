﻿CREATE TABLE IF NOT EXISTS Staff(StaffID INTEGER PRIMARY KEY AUTOINCREMENT, UserName TEXT NOT NULL, Hash BLOB NOT NULL, SALT BLOB NOT NULL);
CREATE TABLE IF NOT EXISTS Users(UserID INTEGER PRIMARY KEY AUTOINCREMENT, RentersName TEXT NOT NULL);
CREATE TABLE IF NOT EXISTS Brands(BrandID INTEGER PRIMARY KEY AUTOINCREMENT, Brand TEXT NOT NULL); 
CREATE TABLE IF NOT EXISTS Tools(ToolID INTEGER PRIMARY KEY AUTOINCREMENT, ToolName TEXT NOT NULL, ToolDescription TEXT NOT NULL, Active NUMERIC NOT NULL, BrandID INTEGER NOT NULL, FOREIGN KEY(BrandID) REFERENCES Brands(BrandID));  
CREATE TABLE IF NOT EXISTS Comments(CommentID INTEGER PRIMARY KEY AUTOINCREMENT, Comment TEXT NOT NULL, ToolID INTEGER NOT NULL, FOREIGN KEY(ToolID) REFERENCES Tools(ToolID));
CREATE TABLE IF NOT EXISTS Rentals(RentalID INTEGER PRIMARY KEY AUTOINCREMENT, RentalDate DATETIME NOT NULL, RentalReturn DATETIME, ToolID INTEGER NOT NULL, UserID INTEGER NOT NULL, FOREIGN KEY(ToolID) REFERENCES Tools(ToolID), FOREIGN KEY(UserID) REFERENCES Users(UserID));