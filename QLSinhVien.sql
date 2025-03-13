CREATE DATABASE QLSV1
GO
USE QLSV 1
GO

-- ================================
-- 🔹 Tạo bảng Khoa
-- ================================
CREATE TABLE Khoa (
    Ma_Khoa NCHAR(10) PRIMARY KEY,
    Ten_Khoa NVARCHAR(50) NOT NULL
);

-- ================================
-- 🔹 Tạo bảng Giảng Viên
-- ================================
CREATE TABLE GiaoVien (
    MSGV NCHAR(10) PRIMARY KEY,
    Ten_Day_Du NVARCHAR(50) NOT NULL,
    Gioi_Tinh NCHAR(5) CHECK (Gioi_Tinh IN (N'Nam', N'Nữ')) NOT NULL,
    Ngay_Sinh DATE NOT NULL,
    Dia_Chi NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(15) NOT NULL,
    Ma_Khoa NCHAR(10) NOT NULL,
    FOREIGN KEY (Ma_Khoa) REFERENCES Khoa(Ma_Khoa)
);

-- ================================
-- 🔹 Tạo bảng Môn Học
-- ================================
CREATE TABLE MonHoc (
    Ma_Mon_Hoc NCHAR(10) PRIMARY KEY,
    Ten_Mon_Hoc NVARCHAR(50) NOT NULL,
    So_Tin_Chi INT NOT NULL CHECK (So_Tin_Chi > 0)
);

-- ================================
-- 🔹 Tạo bảng Lớp
-- ================================
CREATE TABLE Lop (
    Ma_Lop NCHAR(10) PRIMARY KEY,
    MSGVCN NCHAR(10) NOT NULL,
    Ma_Khoa NCHAR(10) NOT NULL,
    Si_So INT,
    FOREIGN KEY (MSGVCN) REFERENCES GiaoVien(MSGV),
    FOREIGN KEY (Ma_Khoa) REFERENCES Khoa(Ma_Khoa)
);



CREATE TABLE LopMonHoc (
    MSGV NCHAR(10) NOT NULL,
    Ma_Khoa NCHAR(10) NOT NULL,
    
    Ma_Mon_Hoc NCHAR(10) NOT NULL,
	PRIMARY KEY(MSGV,Ma_Mon_Hoc),
    FOREIGN KEY (MSGV) REFERENCES GiaoVien(MSGV),
    FOREIGN KEY (Ma_Khoa) REFERENCES Khoa(Ma_Khoa),
    FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc)
);
-- ================================
-- 🔹 Tạo bảng Giảng viên dạy môn học
-- ================================
CREATE TABLE DayMonHoc (
    MSGV NCHAR(10) NOT NULL,
    Ma_Mon_Hoc NCHAR(10) NOT NULL,
	Ngay_Hoc NVARCHAR(10) NOT NULL,  -- Ví dụ: 'Thứ 2', 'Thứ 3'
    Gio_Bat_Dau TIME NOT NULL,
    Gio_Ket_Thuc TIME NOT NULL,
    PRIMARY KEY (MSGV, Ma_Mon_Hoc),
    FOREIGN KEY (MSGV) REFERENCES GiaoVien(MSGV),
    FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc)
);
-- ================================
-- 🔹 Tạo bảng Sinh Viên
-- ================================
CREATE TABLE SinhVien (
    MSSV NCHAR(10) PRIMARY KEY,
    Ten_Day_Du NVARCHAR(50) NOT NULL,
    Gioi_Tinh NCHAR(5) CHECK (Gioi_Tinh IN (N'Nam', N'Nữ')) NOT NULL,
    Ngay_Sinh DATE CHECK (YEAR(GETDATE()) - YEAR(Ngay_Sinh) >= 18) NOT NULL,
    Email NVARCHAR(50) NULL,
    SDT NVARCHAR(15) NOT NULL,
    Dia_Chi NVARCHAR(100) NOT NULL,
    Khoa_Hoc NCHAR(10) NOT NULL,
    Diem_Ren_Luyen FLOAT CHECK (Diem_Ren_Luyen BETWEEN 0 AND 100) NOT NULL,
    Ma_Lop NCHAR(10) NOT NULL,
    FOREIGN KEY (Ma_Lop) REFERENCES Lop(Ma_Lop)
);

-- ================================
-- 🔹 Tạo bảng Tài Khoản
-- ================================
CREATE TABLE TaiKhoan (
    Ten_Dang_Nhap NVARCHAR(10) PRIMARY KEY,  -- Dùng MSSV hoặc MSGV làm tên đăng nhập
    Mat_Khau NVARCHAR(100) NOT NULL, -- Mật khẩu (nên mã hóa)
    Loai_Tai_Khoan INT NOT NULL CHECK (Loai_Tai_Khoan IN (1, 2, 3)),
	Trang_Thai INT NOT NULL CHECK(Trang_Thai IN (0,1))
);

-- ================================
-- 🔹 Tạo bảng Điểm
-- ================================
CREATE TABLE Diem (
    MSSV NCHAR(10) NOT NULL,
    Ma_Mon_Hoc NCHAR(10) NOT NULL,
    Lan_Thi INT NOT NULL CHECK (Lan_Thi > 0),
    Diem_Qua_Trinh FLOAT CHECK (Diem_Qua_Trinh BETWEEN 0 AND 10) NULL,
    Diem_Thi FLOAT CHECK (Diem_Thi BETWEEN 0 AND 10) NULL,
    Diem_Tong_Ket FLOAT CHECK (Diem_Tong_Ket BETWEEN 0 AND 10) NULL,
    PRIMARY KEY (MSSV, Ma_Mon_Hoc, Lan_Thi),
    FOREIGN KEY (MSSV) REFERENCES SinhVien(MSSV),
    FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc)
);

-- ================================
-- 🔹 Tạo bảng Đăng Ký Môn Học
-- ================================
CREATE TABLE DangKy (
    MSSV NCHAR(10) NOT NULL,
    Ma_Mon_Hoc NCHAR(10) NOT NULL,
    PRIMARY KEY (MSSV, Ma_Mon_Hoc),
    FOREIGN KEY (MSSV) REFERENCES SinhVien(MSSV),
    FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc)
);


CREATE TABLE MonDangKi(
	Ma_Mon_Hoc NCHAR(10) PRIMARY KEY,
    Ngay_BD DATE NOT NULL,
    Ngay_KT DATE NOT NULL,
	FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc),
	CONSTRAINT CK_NgayDangKi CHECK (Ngay_KT >= Ngay_BD)
)

CREATE TABLE MonThi(
	Ma_Mon_Hoc NCHAR(10)  PRIMARY KEY,
	Ngay_Thi DATETIME NOT NULL,
	Gio_BD TIME NOT NULL,
	Gio_KT TIME NOT NULL,
	FOREIGN KEY (Ma_Mon_Hoc) REFERENCES MonHoc(Ma_Mon_Hoc),
	CONSTRAINT CK_GioThi CHECK (Gio_KT > Gio_BD)
)

-- ================================
-- 🔹 Thêm dữ liệu mẫu
-- ================================
-- Khoa
INSERT INTO Khoa VALUES 
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kinh tế'),
('QTKD', N'Quản trị kinh doanh'),
('NN', N'Ngoại ngữ');


-- Giảng viên
INSERT INTO GiaoVien VALUES 
('GV001', N'Nguyễn Văn A', N'Nam', '1980-05-10', N'Hà Nội', '0123456789', 'CNTT'),
('GV002', N'Trần Thị B', N'Nữ', '1985-07-20', N'Hồ Chí Minh', '0987654321', 'KT'),
('GV003', N'Lê Văn C', N'Nam', '1990-09-15', N'Đà Nẵng', '0912345678', 'QTKD'),
('GV004', N'Phạm Thị D', N'Nữ', '1978-03-25', N'Cần Thơ', '0909876543', 'NN'),
('GV005', N'Hoàng Văn E', N'Nam', '1982-12-30', N'Hải Phòng', '0923456789', 'CNTT');

-- Môn học
INSERT INTO MonHoc VALUES 
('MH001', N'Lập trình C', 3),
('MH002', N'Kinh tế vi mô', 3),
('MH003', N'Quản trị nhân sự', 3),
('MH004', N'Tiếng Anh giao tiếp', 2),
('MH005', N'Vật lý hạt nhân', 3);

-- Lớp
INSERT INTO Lop VALUES 
('L001', 'GV001', 'CNTT', 90),
('L002', 'GV002', 'KT', 85),
('L003', 'GV003', 'QTKD', 78),
('L004', 'GV004', 'NN', 80),
('L005', 'GV005', 'CNTT', 88);

-- Sinh viên
INSERT INTO SinhVien VALUES 
('SV001', N'Nguyễn Văn X', N'Nam', '2003-06-15', 'x@gmail.com', '0934567890', N'Hà Nội',N'K24',80, 'L001'),
('SV002', N'Trần Thị Y', N'Nữ', '2002-08-22', 'y@gmail.com', '0945678901', N'Hồ Chí Minh',N'K24' ,78,'L002'),
('SV003', N'Lê Văn Z', N'Nam', '2001-11-30', 'z@gmail.com', '0956789012', N'Đà Nẵng',N'K45' , 95,'L003'),
('SV004', N'Phạm Thị M', N'Nữ', '2000-09-25', 'm@gmail.com', '0967890123', N'Cần Thơ', N'K23' ,93,'L004'),
('SV005', N'Hoàng Văn N', N'Nam', '1999-12-10', 'n@gmail.com', '0978901234', N'Hải Phòng',N'K22' ,69, 'L005'),
(N'SV006', N'Nguyễn Văn A', N'Nam', '2003-05-10', 'nguyenvana@gmail.com', '0123456789', N'Hà Nội',N'K23' , 85, N'L001'),
(N'SV007', N'Trần Thị B', N'Nữ', '2002-08-15', 'tranthib@gmail.com', '0987654321', N'Hồ Chí Minh', N'K22' ,90, N'L002'),
(N'SV008', N'Phạm Công C', N'Nam', '2001-12-22', 'phamcongc@gmail.com', '0971122334', N'Đà Nẵng', N'K22' ,88, N'L001'),
(N'SV009', N'Lê Thu D', N'Nữ', '2003-02-05', 'lethud@gmail.com', '0933445566', N'Hải Phòng',  N'K23',92 ,N'L003'),
(N'SV010', N'Hoàng Minh E', N'Nam', '2002-11-30', 'hoangminhe@gmail.com', '0966778899', N'Cần Thơ', N'K22' ,87, N'L002');

-- Thêm tài khoản 
INSERT INTO TaiKhoan  VALUES
('admin01', '123456', 3,1),
('GV001', 'pass123',  2,1),
('GV002', 'pass123',  2,1),
('GV003', 'pass123',  2,1),
('GV004', 'pass123',  2,1),
('GV005', 'pass123',  2,1),
('SV001', 'pass123',  1,1),
('SV002', 'pass123',  1,1),
('SV003', 'pass123',  1,1),
('SV004', 'pass123',  1,1),
('SV005', 'pass123',  1,1),
(N'SV006', N'pass123', 1,1),
(N'SV007', N'pass123',  1,1),
(N'SV008', N'pass123',  1,1),
(N'SV009', N'pass123',  1,1),
(N'SV010', N'pass123', 1,1);


-- Thêm dữ liệu vào bảng DayMonHoc (Giảng viên dạy môn học)
INSERT INTO DayMonHoc (MSGV, Ma_Mon_Hoc) VALUES
(N'GV001', N'MH001'),
(N'GV002', N'MH002'),
(N'GV003', N'MH003'),
(N'GV004', N'MH004'),
(N'GV005', N'MH005');
-- Thêm dữ liệu vào bảng DangKy (Sinh viên đăng ký môn học)
INSERT INTO DangKy (MSSV, Ma_Mon_Hoc) VALUES
(N'SV001', N'MH001'),
(N'SV001', N'MH002'),
(N'SV001', N'MH003'),
(N'SV002', N'MH002'),
(N'SV002', N'MH003'),
(N'SV002', N'MH004'),
(N'SV003', N'MH001'),
(N'SV003', N'MH004'),
(N'SV003', N'MH005'),
(N'SV004', N'MH002'),
(N'SV004', N'MH003'),
(N'SV004', N'MH005'),
(N'SV005', N'MH001'),
(N'SV005', N'MH003'),
(N'SV005', N'MH004'),
(N'SV006', N'MH002'),
(N'SV006', N'MH004'),
(N'SV006', N'MH005'),
(N'SV007', N'MH001'),
(N'SV007', N'MH003'),
(N'SV007', N'MH005'),
(N'SV008', N'MH001'),
(N'SV008', N'MH002'),
(N'SV008', N'MH004'),
(N'SV009', N'MH002'),
(N'SV009', N'MH003'),
(N'SV009', N'MH005'),
(N'SV010', N'MH001'),
(N'SV010', N'MH003'),
(N'SV010', N'MH004');

-- Thêm dữ liệu vào bảng LopMonHoc
INSERT INTO LopMonHoc (Ma_Nhom_Hoc, MSGV, Ma_Khoa, Ngay_Hoc, Gio_Bat_Dau, Gio_Ket_Thuc, Ma_Mon_Hoc) VALUES
(N'LMH001', N'GV001', N'CNTT', N'Thứ 2', '07:30', '09:00', N'MH001'),
(N'LMH002', N'GV002', N'KT', N'Thứ 3', '09:15', '10:45', N'MH002'),
(N'LMH003', N'GV003', N'CNTT', N'Thứ 4', '13:30', '15:00', N'MH003'),
(N'LMH004', N'GV004', N'NN', N'Thứ 5', '15:15', '16:45', N'MH004'),
(N'LMH005', N'GV005', N'QTKD', N'Thứ 6', '07:30', '09:00', N'MH005');

INSERT INTO Diem (MSSV, Ma_Mon_Hoc, Lan_Thi, Diem_Qua_Trinh, Diem_Thi, Diem_Tong_Ket) VALUES
(N'SV001', N'MH001', 1, 7.5, 8.0, 7.8),
(N'SV001', N'MH002', 1, 6.0, 7.0, 6.5),
(N'SV001', N'MH003', 1, 8.2, 8.5, 8.4),
(N'SV002', N'MH002', 1, 8.5, 9.0, 8.8),
(N'SV002', N'MH003', 1, 7.0, 7.5, 7.3),
(N'SV002', N'MH004', 1, 9.1, 9.2, 9.2),
(N'SV003', N'MH001', 1, 9.0, 8.5, 8.8),
(N'SV003', N'MH004', 1, 6.5, 7.2, 6.9),
(N'SV003', N'MH005', 1, 7.5, 7.8, 7.6),
(N'SV004', N'MH002', 1, 6.5, 7.2, 6.9),
(N'SV004', N'MH003', 1, 8.0, 7.8, 7.9),
(N'SV004', N'MH005', 1, 5.5, 6.0, 5.8),
(N'SV005', N'MH001', 1, 6.5, 6.8, 6.7),
(N'SV005', N'MH003', 1, 5.0, 5.5, 5.3),
(N'SV005', N'MH004', 1, 9.2, 9.0, 9.1),
(N'SV006', N'MH002', 1, 7.5, 8.0, 7.8),
(N'SV006', N'MH004', 1, 6.0, 7.0, 6.5),
(N'SV006', N'MH005', 1, 8.2, 8.5, 8.4),
(N'SV007', N'MH001', 1, 8.5, 9.0, 8.8),
(N'SV007', N'MH003', 1, 7.0, 7.5, 7.3),
(N'SV007', N'MH005', 1, 9.1, 9.2, 9.2),
(N'SV008', N'MH001', 1, 9.0, 8.5, 8.8),
(N'SV008', N'MH002', 1, 6.5, 7.2, 6.9),
(N'SV008', N'MH004', 1, 7.5, 7.8, 7.6),
(N'SV009', N'MH002', 1, 6.5, 7.2, 6.9),
(N'SV009', N'MH003', 1, 8.0, 7.8, 7.9),
(N'SV009', N'MH005', 1, 5.5, 6.0, 5.8),
(N'SV010', N'MH001', 1, 6.5, 6.8, 6.7),
(N'SV010', N'MH003', 1, 5.0, 5.5, 5.3),
(N'SV010', N'MH004', 1, 9.2, 9.0, 9.1);



-- Thêm dữ liệu vào bảng MonDangKi
INSERT INTO MonDangKi (Ma_Mon_Hoc, Ngay_BD, Ngay_KT) VALUES
(N'MH001', '2025-03-10', '2025-03-20'),
(N'MH002', '2025-03-15', '2025-03-25'),
(N'MH003', '2025-03-12', '2025-03-22'),
(N'MH004', '2025-03-18', '2025-03-28'),
(N'MH005', '2025-03-08', '2025-03-18');

-- Thêm dữ liệu vào bảng MonThi
INSERT INTO MonThi (Ma_Mon_Hoc, Ngay_Thi, Gio_BD, Gio_KT) VALUES
(N'MH001', '2025-04-05', '08:00:00','10:00:00'),
(N'MH002', '2025-04-07', '10:30:00','12:00:00'),
(N'MH003', '2025-04-10', '14:00:00','15:00:00'),
(N'MH004', '2025-04-12', '09:00:00','11:00:00'),
(N'MH005', '2025-04-15', '13:30:00','15:00:00');


--Tạo trigger mỗi khi thêm sinh viên tự động tạo tài khoản dựa trên MSSV vs pass là pass123
CREATE TRIGGER trg_AutoCreateTaiKhoan_SV
ON SinhVien
AFTER INSERT
AS
BEGIN
    INSERT INTO TaiKhoan (Ten_Dang_Nhap, Mat_Khau, Loai_Tai_Khoan,Trang_Thai)
    SELECT 
        MSSV, 
        N'pass123',
		1,
        1  -- Mặc định tài khoản hoạt động
    FROM inserted;
END;


--Tạo trigger mỗi khi thêm giáo viên tự động tạo tài khoản dựa trên MSGV vs pass là pass123
CREATE TRIGGER trg_AutoCreateTaiKhoan_GV
ON GiaoVien
AFTER INSERT
AS
BEGIN
    INSERT INTO TaiKhoan (Ten_Dang_Nhap, Mat_Khau,Loai_Tai_Khoan,Trang_Thai)
    SELECT 
        MSGV, 
        N'pass123',
        2,
        1  -- Mặc định tài khoản hoạt động
    FROM inserted;
END;



