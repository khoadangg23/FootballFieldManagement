USE master;
GO

CREATE DATABASE FootballFieldManagementDB;
GO

USE FootballFieldManagementDB;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
	PhoneNumber VARCHAR(20),
	Email VARCHAR(100),
    Role NVARCHAR(50), -- e.g., 'Admin', 'Staff'
    IsActive BIT NOT NULL DEFAULT 1
);
GO

-- Tạo bảng Fields
CREATE TABLE Fields (
    FieldID INT IDENTITY(1,1) PRIMARY KEY,
    FieldName NVARCHAR(100) NOT NULL,
    FieldType NVARCHAR(50),
    PricePerHour DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50) -- Có sẵn, Đã đặt, Bảo trì
);
GO

-- Tạo bảng Customers
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(150) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL UNIQUE,
	Email VARCHAR(100),
    Address NVARCHAR(200)
);
GO

-- Tạo bảng Bookings
CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    BookingDate DATE NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL, -- Chưa thanh toán, Đã đặt cọc, Đã thanh toán
    CreatedDate DATETIME NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

-- Tạo bảng BookingDetails
CREATE TABLE BookingDetails (
    BookingDetailID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    FieldID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
	DurationHours INT NOT NULL,
    PriceApplied DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID),
    FOREIGN KEY (FieldID) REFERENCES Fields(FieldID)
);
GO

-- Tạo bảng Payments
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    BookingID INT NOT NULL,
    PaymentDate DATETIME NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentMethod NVARCHAR(50), -- Tiền mặt, Thẻ, Ngân hàng, Momo
    UserID INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive) VALUES
('admin', 'admin123', N'Nguyễn Văn Quản Trị', N'Admin', 1),
('manager', 'manager123', N'Trần Thị Quản Lý', N'Manager', 1),
('nhanvien1', 'nhanvien1', N'Lê Minh Nhân', N'Staff', 1),
('nhanvien2', 'nhanvien2', N'Phạm Thị Viên', N'Staff', 1),
('nhanvien3', 'nhanvien3', N'Hoàng Văn An', N'Staff', 1);
GO

-- Dữ liệu mẫu cho bảng Fields
INSERT INTO Fields (FieldName, FieldType, PricePerHour, Status) VALUES
(N'Sân 5A', N'Sân 5', 100.00, N'Có sẵn'),
(N'Sân 5B', N'Sân 5', 100.00, N'Có sẵn'),
(N'Sân 7A', N'Sân 7', 200.00, N'Có sẵn'),
(N'Sân 7B', N'Sân 7', 200.00, N'Có Sẵn'),
(N'Sân 11', N'Sân 11', 300.00, N'Có sẵn');
GO

-- Dữ liệu mẫu cho bảng Customers
INSERT INTO Customers (CustomerName, PhoneNumber, Address) VALUES
(N'Trần Anh Khoa', '0987654321', N'101 Lê Lợi, P. Bến Nghé, Q.1'),
(N'Nguyễn Thị Bình', '0981234567', N'202 Hai Bà Trưng, P. Đa Kao, Q.1'),
(N'Lê Văn Cường', '0982345678', N'303 Nguyễn Huệ, P. Bến Nghé, Q.1'),
(N'Phạm Thị Dung', '0983456789', N'404 Võ Thị Sáu, P. 8, Q.3'),
(N'Hoàng Minh Nhật', '0984567890', N'505 Cách Mạng Tháng Tám, P. 11, Q.3');
GO

INSERT INTO Bookings (CustomerID, BookingDate, TotalAmount, Status, CreatedDate, UserID) VALUES
(1, '2025-01-20', 300.00, N'Đã thanh toán', '2025-01-19 09:10:00', 3),
(2, '2025-02-15', 200.00, N'Đã đặt cọc', '2025-02-14 14:30:00', 1),
(3, '2025-03-05', 100.00, N'Chưa thanh toán', '2025-03-04 20:00:00', 4),
(4, '2025-04-18', 400.00, N'Đã thanh toán', '2025-04-16 11:55:00', 2),
(5, '2025-05-01', 200.00, N'Đã đặt cọc', '2025-04-30 17:00:00', 5),
(1, '2025-03-25', 200.00, N'Chưa thanh toán', '2025-03-24 08:00:00', 3),
(2, '2025-04-10', 300.00, N'Đã thanh toán', '2025-04-08 15:40:00', 1);
GO

INSERT INTO BookingDetails (BookingID, FieldID, StartTime, EndTime, DurationHours, PriceApplied) VALUES
(1, 5, '2025-01-20 19:00:00', '2025-01-20 20:00:00', 1, 300.00),
(2, 4, '2025-02-15 20:00:00', '2025-02-15 21:00:00', 1, 200.00),
(3, 1, '2025-03-05 21:00:00', '2025-03-05 22:00:00', 1, 100.00),
(4, 4, '2025-04-18 19:00:00', '2025-04-18 21:00:00', 2, 200.00),
(5, 3, '2025-05-01 17:00:00', '2025-05-01 18:00:00', 1, 200.00),
(6, 1, '2025-03-25 10:00:00', '2025-03-25 12:00:00', 2, 100.00),
(7, 5, '2025-04-10 16:00:00', '2025-04-10 17:00:00', 1, 300.00);
GO

INSERT INTO Payments (BookingID, PaymentDate, Amount, PaymentMethod, UserID, CreatedDate) VALUES
(1, '2025-01-20 10:00:00', 300.00, N'Ngân hàng', 3, '2025-01-20 09:55:00'),
(2, '2025-02-15 15:00:00', 200.00, N'Tiền mặt', 1, '2025-02-15 15:00:00'),
(3, '2025-03-05 20:30:00', 100.00, N'Momo', 4, '2025-03-05 20:30:00'),
(4, '2025-04-18 12:00:00', 400.00, N'Thẻ', 2, '2025-04-18 11:58:00'),
(5, '2025-05-01 17:30:00', 200.00, N'Tiền mặt', 5, '2025-05-01 17:30:00'),
(6, '2025-03-25 08:30:00', 200.00, N'Ngân hàng', 3, '2025-03-25 08:25:00'),
(7, '2025-04-10 16:30:00', 300.00, N'Momo', 1, '2025-04-10 16:30:00');
GO