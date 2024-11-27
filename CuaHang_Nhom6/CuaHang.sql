CREATE DATABASE CuaHang
GO

USE CuaHang
GO

CREATE TABLE LoaiHang (
	MaLH INT IDENTITY PRIMARY KEY,
	TenLH NVARCHAR(100)
)
GO

INSERT INTO LoaiHang VALUES
	(N'Vật liệu xây dựng'),
    (N'Điện tử'),
    (N'Gia dụng'),
    (N'Nội thất'),
    (N'Vật liệu hoàn thiện'),
    (N'Công cụ dụng cụ'),
    (N'Hóa chất'),
    (N'Thiết bị xây dựng'),
    (N'Vật liệu cách nhiệt'),
    (N'Vật liệu trang trí')
GO

CREATE TABLE HangHoa (
	MaHH INT IDENTITY PRIMARY KEY,
	TenHH NVARCHAR(100),
	MaLH INT FOREIGN KEY REFERENCES LoaiHang(MaLH),
	Gia DECIMAL(10,0),
	SLTon INT,
	DonVi NVARCHAR(10)
)
GO

INSERT INTO HangHoa VALUES
	(N'Xi măng', 1, 200000, 100, N'Bao'),
    (N'Gạch đất nung', 1, 15000, 200, N'Viên'),
    (N'Thép cuộn', 1, 30000, 50, N'Kg'),
    (N'Gỗ thông', 1, 5000000, 30, N'M3'),
    
    (N'Thiết bị âm thanh', 2, 1500000, 20, N'Sản phẩm'),
    (N'Mạch in', 2, 300000, 10, N'Chiếc'),
    (N'Microphone', 2, 500000, 15, N'Chiếc'),
    (N'Tivi LED', 2, 7000000, 5, N'Chiếc'),
    
    (N'Bàn ăn', 3, 2000000, 10, N'Chiếc'),
    (N'Ghế sofa', 3, 3000000, 8, N'Chiếc'),
    (N'Máy giặt', 3, 5000000, 12, N'Sản phẩm'),
    (N'Tủ lạnh', 3, 8000000, 6, N'Sản phẩm'),
    
    (N'Bàn làm việc', 4, 1500000, 15, N'Chiếc'),
    (N'Ghế văn phòng', 4, 1000000, 20, N'Chiếc'),
    (N'Tủ sách', 4, 1200000, 10, N'Chiếc'),
    (N'Giá treo tường', 4, 800000, 25, N'Chiếc'),
    
    (N'Sơn nước', 5, 250000, 50, N'Lit'),
    (N'Gạch men', 5, 100000, 100, N'M2'),
    (N'Giấy dán tường', 5, 50000, 200, N'M2'),
    (N'Phào chỉ', 5, 30000, 150, N'M'),
    
    (N'Máy khoan', 6, 700000, 20, N'Chiếc'),
    (N'Kéo cắt', 6, 200000, 30, N'Chiếc'),
    (N'Máy cắt gạch', 6, 1000000, 10, N'Chiếc'),
    (N'Tua vít', 6, 10000, 100, N'Chiếc'),
    
    (N'Hóa chất tẩy rửa', 7, 50000, 60, N'Lit'),
    (N'Phân bón', 7, 30000, 100, N'Kg'),
    (N'Hóa chất xây dựng', 7, 200000, 50, N'Kg'),
    (N'Hóa chất bảo vệ gỗ', 7, 150000, 40, N'Lit'),
    
    (N'Máy xúc', 8, 8000000, 5, N'Chiếc'),
    (N'Máy trộn bê tông', 8, 12000000, 4, N'Chiếc'),
    (N'Xe tải', 8, 50000000, 3, N'Chiếc'),
    (N'Máy cẩu', 8, 60000000, 2, N'Chiếc'),
    
    (N'Bông cách nhiệt', 9, 50000, 150, N'M2'),
    (N'Tấm xốp cách nhiệt', 9, 20000, 100, N'M2'),
    (N'Tấm kim loại cách nhiệt', 9, 300000, 50, N'M2'),
    (N'Gạch cách nhiệt', 9, 25000, 80, N'M2'),
    
    (N'Đèn trang trí', 10, 150000, 40, N'Chiếc'),
    (N'Khung tranh', 10, 30000, 60, N'Chiếc'),
    (N'Rèm cửa', 10, 50000, 80, N'M2'),
    (N'Sàn gỗ công nghiệp', 10, 800000, 30, N'M2')
GO