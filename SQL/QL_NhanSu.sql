--drop database QL_NHANSU
CREATE DATABASE QL_NHANSU
USE QL_NHANSU

set dateformat dmy

CREATE TABLE PHONGBAN 
(
    MaPB CHAR(10) PRIMARY KEY,
    TenPB NVARCHAR(50),
    DiaChi NVARCHAR(100),
    SDTPB CHAR(15)
)

CREATE TABLE CHUCVU 
(
    MaCV CHAR(10) PRIMARY KEY,
    TenCV NVARCHAR(50)
)

CREATE TABLE TRINHDOHOCVAN 
(
    MaTDHV CHAR(10) PRIMARY KEY,
    TTDHV NVARCHAR(50),
)

CREATE TABLE LUONG (
    MucLuong CHAR(10) PRIMARY KEY,
    LuongCB FLOAT
)

CREATE TABLE NHANVIEN (
    MaNV CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50),
    NgaySinh DATE,
	GioiTinh NVARCHAR(6),
	CMND CHAR(15) UNIQUE,
	SoDienThoai CHAR(15),
    QueQuan NVARCHAR(50),
    DanToc NVARCHAR(20),
	MucLuong char(10),
	MaPB CHAR(10),
    MaCV CHAR(10),
    MaTDHV CHAR(10),
	MaNQL CHAR(10),
	TTHN NVARCHAR(30),
	HINH IMAGE,
    FOREIGN KEY (MaPB) REFERENCES PHONGBAN(MaPB),
    FOREIGN KEY (MaCV) REFERENCES CHUCVU(MaCV),
    FOREIGN KEY (MaTDHV) REFERENCES TRINHDOHOCVAN(MaTDHV),
	FOREIGN KEY (MaNQL) REFERENCES NHANVIEN(MaNV),
	FOREIGN KEY (MucLuong) REFERENCES LUONG(MucLuong)
)

CREATE TABLE THUONGPHAT
(
	MATP CHAR(10) PRIMARY KEY,
	Loai NVARCHAR(50)
)

Create Table CHITIETTHUONGPHAT
(
	MaCTTP CHAR(10),
	MaNV CHAR(10),
	MaTP CHAR(10),
	Tien FLOAT,
	LyDo NVARCHAR(max),
	Ngay DATE,
	PRIMARY KEY (MACTTP),
	FOREIGN KEY (MATP) REFERENCES THUONGPHAT(MATP),
	FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
)

create table NGHIPHEP
(
	MANP CHAR(10),
	MaNV CHAR(10),
	TuNgay DATE,
	DenNgay Date,
	LyDo NVARCHAR(255),
	TinhTrang nvarchar(30),
	PRIMARY KEY (MANP),
	FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
)

CREATE TABLE TINHLUONG 
(
    MaNV CHAR(10),
    Thang INT,
    Nam INT,
    SoNgayCong INT,
	TienThuongPhat float,
    TongLuong float,
	primary key (MaNV, Thang, Nam),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
)


CREATE TABLE HOPDONGLAODONG 
(
    MaHD CHAR(10),
    MaNV CHAR(10),
    LoaiHD NVARCHAR(MAX),
    TuNgay DATE,
    DenNgay DATE,
	TinhTrang NVARCHAR(30),
	PRIMARY KEY (MaHD, MaNV),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
)

CREATE TABLE THONGTINNHANTHAN
(
	MaNT char(10),
    MaNV CHAR(10),
    Ten NVARCHAR(50), 
    QuanHe NVARCHAR(20),
	NgaySinh DATE,
    SoDienThoai CHAR(15),
    NgheNghiep NVARCHAR(100),
	PRIMARY KEY (MaNT, MaNV),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
)


CREATE TABLE QUYEN
(
	MANV CHAR(10),
	TENDN VARCHAR(20),
	MATKHAU VARCHAR(20),
	VAITRO NVARCHAR(30)
	CONSTRAINT PK_QUYEN PRIMARY KEY (TENDN),
	CONSTRAINT FK_QUYEN_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

select * from QUYEN

-----RÀNG BUỘC-----
ALTER TABLE NGHIPHEP
ADD CONSTRAINT CHK_MANP check (left(MANP,2)='NP')

ALTER TABLE NHANVIEN
ADD CONSTRAINT CHK_MaNV CHECK (LEFT(MaNV, 2) = 'NV')

ALTER TABLE PHONGBAN
ADD CONSTRAINT CHK_MaPB CHECK (LEFT(MaPB, 2) = 'PH')

ALTER TABLE NHANVIEN
ADD CONSTRAINT CHK_GioiTinh CHECK (GioiTinh IN ('Nam', N'Nữ'))

ALTER TABLE NHANVIEN
ADD CONSTRAINT CHK_TTHN CHECK (TTHN in (N'Độc thân',N'Kết hôn'))

ALTER TABLE NHANVIEN
DROP CONSTRAINT CHK_GioiTinh

ALTER TABLE NHANVIEN
ADD CONSTRAINT CHK_Tuoi CHECK (DATEDIFF(YEAR, NgaySinh, GETDATE()) >= 18 AND DATEDIFF(YEAR, NgaySinh, GETDATE()) <= 65)

ALTER TABLE THUONGPHAT
ADD CONSTRAINT CHK_Loai CHECK (Loai in (N'Thưởng', N'Phạt',N'Không có'))

ALTER TABLE NGHIPHEP
ADD CONSTRAINT CHK_NghiPhep CHECK (TinhTrang IN (N'Chưa duyệt', N'Đã duyệt'))

ALTER TABLE THONGTINNHANTHAN
ADD CONSTRAINT FK_Delete_NhanVien FOREIGN KEY (MaNV) 
REFERENCES NHANVIEN(MaNV) ON DELETE CASCADE;

ALTER TABLE CHITIETTHUONGPHAT
ADD CONSTRAINT FK_Delete_NhanVien_TP FOREIGN KEY (MaNV) 
REFERENCES NHANVIEN(MaNV) ON DELETE CASCADE;

ALTER TABLE TINHLUONG
ADD CONSTRAINT FK_Delete_NhanVien_TL FOREIGN KEY (MaNV) 
REFERENCES NHANVIEN(MaNV) ON DELETE CASCADE;

ALTER TABLE HOPDONGLAODONG
ADD CONSTRAINT FK_Delete_NhanVien_HDDL FOREIGN KEY (MaNV) 
REFERENCES NHANVIEN(MaNV) ON DELETE CASCADE;

ALTER TABLE NGHIPHEP
ADD CONSTRAINT FK_Delete_NhanVien_NP FOREIGN KEY (MaNV) 
REFERENCES NHANVIEN(MaNV) ON DELETE CASCADE;

-------------NHẬP------------------
--BẢNG PHÒNG BAN
INSERT INTO PHONGBAN (MaPB, TenPB, DiaChi, SDTPB)
VALUES
    ('PH101', N'Phòng Kế Toán', N'123 Đường A, Quận 1, TP.HCM', '0123456789'),
    ('PH102', N'Phòng Kinh Doanh', N'456 Đường B, Quận 2, TP.HCM', '0987654321'),
    ('PH103', N'Phòng Nhân Sự', N'789 Đường C, Quận 3, TP.HCM', '0123123456'),
    ('PH104', N'Phòng Hành Chính', N'101 Đường D, Quận 4, TP.HCM', '0345789123'),
    ('PH105', N'Phòng Công Nghệ', N'202 Đường E, Quận 5, TP.HCM', '0789456123'),
    ('PH106', N'Phòng Marketing', N'303 Đường F, Quận 6, TP.HCM', '0912345678'),
    ('PH107', N'Phòng Kỹ Thuật', N'404 Đường G, Quận 7, TP.HCM', '0898765432'),
    ('PH108', N'Phòng Tài Chính', N'505 Đường H, Quận 8, TP.HCM', '0341234567'),
    ('PH109', N'Phòng Hỗ Trợ', N'606 Đường I, Quận 9, TP.HCM', '0777123456'),
    ('PH110', N'Phòng Quản Lý', N'707 Đường J, Quận 10, TP.HCM', '0981234567')
--BẢNG CHỨC VỤ
INSERT INTO CHUCVU (MaCV, TenCV)
VALUES
    ('CV1', N'Giám đốc'),
    ('CV2', N'Trưởng phòng'),
    ('CV3', N'Nhân Viên')

-- BẢNG TRÌNH ĐỘ HỌC VẤN
INSERT INTO TRINHDOHOCVAN (MaTDHV, TTDHV)
VALUES
    ('TDHV1', N'Trên Đại học'),
    ('TDHV2', N'Đại học'),
    ('TDHV3', N'Cao đẳng')
	
--BẢNG LƯƠNG
INSERT INTO LUONG (MucLuong, LuongCB)
VALUES
    ('M1', 8000000),
    ('M2', 6000000),
    ('M3', 4000000)

--NhanVien
	INSERT INTO NHANVIEN (MaNV, HoTen, NgaySinh, QueQuan, GioiTinh, DanToc, SoDienThoai, MaPB, MaCV, MaTDHV, MucLuong, MaNQL, CMND, TTHN, HINH)
VALUES
    ('NV101', N'Nguyễn Văn A', '1990-01-15', N'Hà Nội', 'Nam', N'Kinh', '0123456789', 'PH110', 'CV1', 'TDHV1', NULL, NULL,'111111111111',N'Độc thân',NULL),
    ('NV102', N'Trần Thị B', '1985-03-20', N'Hải Phòng', N'Nữ', N'Kinh', '0234567890', 'PH102', 'CV2', 'TDHV2',NULL, NULL,'2222222222',N'Độc thân',NULL),
    ('NV103', N'Lê Văn C', '1992-06-05', N'Đà Nẵng', 'Nam', N'Kinh', '0345678901', 'PH101', 'CV1', 'TDHV3', NULL, NULL,'3333333333',N'Kết hôn',NULL),
    ('NV104', N'Phạm Thị D', '1988-11-12', N'Quảng Ninh', N'Nữ', N'Kinh', '0456789012', 'PH102', 'CV2', 'TDHV1', NULL, NULL,'4444444444',N'Độc thân',NULL),
    ('NV105', N'Hoàng Văn E', '1995-02-25', N'Cần Thơ', 'Nam', N'Kinh', '0567890123', 'PH103', 'CV3', 'TDHV2', NULL, NULL,'555555555',N'Độc thân',NULL),
    ('NV106', N'Vũ Thị F', '1986-07-10', N'Đồng Nai', N'Nữ', N'Kinh', '0678901234', 'PH101', 'CV1', 'TDHV1', NULL, NULL,'6666666666',N'Độc thân',NULL),
    ('NV107', N'Đặng Văn G', '1993-09-18', N'Hưng Yên', 'Nam', N'Kinh', '0789012345', 'PH103', 'CV2', 'TDHV2', NULL, NULL,'7777777777',N'Độc thân',NULL),
    ('NV108', N'Ngô Thị H', '1984-04-30', N'Hà Tĩnh', N'Nữ', N'Kinh', '0890123456', 'PH101', 'CV3', 'TDHV3', NULL, NULL,'8888888888',N'Kết hôn',NULL),
    ('NV109', N'Lý Văn I', '1991-08-22', N'Hòa Bình', 'Nam', N'Kinh', '0901234567', 'PH104', 'CV1', 'TDHV1', NULL, NULL,'9999999999',N'Độc thân',NULL),
    ('NV110', N'Chu Thị K', '1987-12-05', N'Quảng Trị', N'Nữ', N'Kinh', '0987654321', 'PH104', 'CV2', 'TDHV2', NULL, NULL,'1010101010',N'Kết hôn',NULL),
    ('NV111', N'Phan Văn L', '1993-03-15', N'Quảng Ngãi', 'Nam', N'Kinh', '0123456789', 'PH105', 'CV3', 'TDHV1', NULL, NULL,'1212121212',N'Độc thân',NULL),
    ('NV112', N'Bùi Thị M', '1988-05-28', N'Kiên Giang', N'Nữ', N'Kinh', '0234567890', 'PH106', 'CV1', 'TDHV2', NULL, NULL,'1313131313',N'Độc thân',NULL),
    ('NV113', N'Trần Văn N', '1990-09-10', N'Bình Phước', 'Nam', N'Kinh', '0345678901', 'PH105', 'CV2', 'TDHV3', NULL, NULL,'1414141414',N'Kết hôn',NULL),
    ('NV114', N'Hoàng Thị O', '1987-11-22', N'Lâm Đồng', N'Nữ', N'Kinh', '0456789012', 'PH106', 'CV3', 'TDHV1', NULL, NULL,'1515151515',N'Kết hôn',NULL),
    ('NV115', N'Đinh Văn P', '1996-01-18', N'Bạc Liêu', 'Nam', N'Kinh', '0567890123', 'PH107', 'CV1', 'TDHV2', NULL, NULL,'1616161616',N'Kết hôn',NULL),
    ('NV116', N'Võ Thị Q', '1986-06-05', N'Cà Mau', N'Nữ', N'Kinh', '0678901234', 'PH107', 'CV2', 'TDHV3', NULL, NULL,'1717171717',N'Độc thân',NULL)
--HỢP ĐỒNG LAO ĐỘNG
INSERT INTO HOPDONGLAODONG (MaHD, MaNV, LoaiHD, TuNgay, DenNgay)
VALUES
    ('HD1', 'NV101', N'Hợp đồng thử việc 3 tháng', '2022-01-01', '2022-03-01'),
    ('HD2', 'NV101', N'Hợp đồng nhân viên chính thức', '2022-03-02', '2025-03-02'),
    ('HD3', 'NV102', N'Hợp đồng thử việc 3 tháng', '2022-02-01', '2022-04-01')
--THƯỞNG PHẠT
INSERT INTO THUONGPHAT (MaTP, Loai)
VALUES
('TH',N'Thưởng'),
('PH',N'Phạt')

--chi tiết thưởng phạt
INSERT INTO CHITIETTHUONGPHAT(MaCTTP, MaNV, MaTP,Tien, LyDo, Ngay)
VALUES
('PH101','NV102','PH',10000,N'Quên tắt đèn','2023-11-05'),
('TH101','NV101','TH',120000,N'Đi sự kiện','2023-02-12'),
('PH104','NV102','PH',10000,N'Quên tắt đèn','2023-11-05'),
('TH105','NV101','TH',120000,N'Đi sự kiện','2023-02-12'),
('PH102','NV101','PH',100000,N'Không quản lý được nv','2023-12-05'),
('PH107','NV102','PH',10000,N'Quên tắt đèn','2023-11-05')

--NGHI PHEP 
INSERT INTO NGHIPHEP (MANP, MaNV, TuNgay, DenNgay, LyDo, TinhTrang)
VALUES
('NP104','NV102','2023-12-5','2023-12-6', N'Công tác', N'Đã duyệt'),
('NP103','NV101','2023-12-2','2023-12-4', N'Công tác', N'Đã duyệt'),
('NP102','NV101','2023-06-10','2023-06-12', N'Công tác', N'Đã duyệt'),
('NP101','NV102','2023-06-10','2023-06-12', N'Công tác', N'Đã duyệt')

--Thêm dữ liệu tính lương
INSERT INTO TINHLUONG(MaNV, Thang, Nam, SoNgayCong, TongLuong)
VALUES
	('NV101', 12, 2023 ,26, NULL),
	('NV102', 12, 2023, 26, NULL),
    ('NV103', 12, 2023, 26, NULL),
    ('NV104', 12, 2023, 26, NULL),
    ('NV105', 12, 2023, 26, NULL),
    ('NV106', 12, 2023, 26, NULL),
    ('NV107', 12, 2023, 24, NULL),
    ('NV108', 12, 2023, 28, NULL),
    ('NV109', 12, 2023, 26, NULL),
    ('NV110', 12, 2023, 26, NULL),
    ('NV111', 12, 2023, 26, NULL),
    ('NV112', 12, 2023, 26, NULL),
    ('NV113', 12, 2023, 26, NULL),
    ('NV114', 12, 2023, 26, NULL),
    ('NV115', 12, 2023, 26, NULL),
    ('NV116', 12, 2023, 26, NULL)

--NHANTHAN
INSERT INTO THONGTINNHANTHAN 
VALUES
('NT1','NV101',N'Huỳnh Thanh A',N'Vợ','1995-04-23','04123652098',N'Chủ tịch'),
('NT2','NV101',N'Nguyễn Thanh B',N'Con','2020-10-05',NULL,NULL)


--QUYEN
INSERT INTO QUYEN (MANV, TENDN, MATKHAU, VAITRO)
VALUES
('NV101', 'NguyenVA', 'pass1', NULL),
('NV103', 'LeVC', 'pass3', NULL),
('NV105','HoangHE','pass5',NULL),
('NV106','VuTF','pass6',NULL),
('NV107', 'DangVG', 'pass7', NULL),
('NV108', 'NgoTH', 'pass8', NULL)

select * from QUYEN
--Cập nhật MaNQL null cho nhân viên có MaCV là 'CV1'
UPDATE NHANVIEN
SET MaNQL = NULL
WHERE MaCV = 'CV1'

-- Cập nhật MaNQL cho nhân viên có MaCV là 'CV2' (người quản lý là nhân viên có MaCV là 'CV1')
UPDATE NHANVIEN
SET MaNQL = (SELECT TOP 1 MaNV FROM NHANVIEN WHERE MaCV = 'CV1' AND MaTDHV = 'TDHV1')
WHERE MaCV = 'CV2'

-- Cập nhật MaNQL cho nhân viên có MaCV là 'CV3' (người quản lý là nhân viên có MaCV là 'CV2')
UPDATE NHANVIEN
SET MaNQL = (SELECT TOP 1 MaNV FROM NHANVIEN WHERE MaCV = 'CV2' AND MaTDHV = 'TDHV1')
WHERE MaCV = 'CV3'
---- Thiết lập bậc lương cho nhân viên có mã công việc là cv1 là bậc lương 1
UPDATE NhanVien
SET MucLuong = 'M1'
WHERE MaCV = 'CV1';

-- Thiết lập bậc lương cho nhân viên có mã công việc là cv2 là bậc lương 2
UPDATE NhanVien
SET MucLuong = 'M2'
WHERE MaCV = 'CV2';

-- Thiết lập bậc lương cho nhân viên có mã công việc là cv3 là bậc lương 3
UPDATE NhanVien
SET MucLuong = 'M3'
WHERE MaCV = 'CV3';

-- Cập nhật trạng thái của hợp đồng
UPDATE HOPDONGLAODONG
SET TinhTrang = 
    CASE
        WHEN DenNgay < GETDATE() THEN N'Hết hạn'
        ELSE N'Còn hạn'
    END;
--Cập nhật quyền
UPDATE QUYEN
SET VAITRO = 
    CASE 
        WHEN NHANVIEN.MANV IN (SELECT MANV FROM NHANVIEN WHERE MaPB = 'PH101') THEN N'Kế toán'
        WHEN NHANVIEN.MANV IN (SELECT MANV FROM NHANVIEN WHERE MaPB = 'PH103') THEN N'Nhân sự'
        WHEN NHANVIEN.MANV IN (SELECT MANV FROM NHANVIEN WHERE MaPB = 'PH110') THEN N'Quản lý'
		else null
    END
FROM QUYEN
JOIN NHANVIEN ON QUYEN.MANV = NHANVIEN.MANV

SELECT * FROM QUYEN
------Thiết lập thưởng phạt
--drop function fn_TongTienThuongPhat
CREATE FUNCTION fn_TongTienThuongPhat (@MaNV varchar(10), @Thang int, @Nam int)
RETURNS money
AS
BEGIN
  DECLARE @Tong money
  SELECT @Tong = SUM(CASE WHEN TP.Loai LIKE N'%Thưởng%' THEN CT.Tien ELSE -CT.Tien END)
  FROM CHITIETTHUONGPHAT AS CT 
  INNER JOIN THUONGPHAT AS TP ON CT.MaTP = TP.MaTP
  WHERE CT.MaNV = @MaNV 
    AND MONTH(CT.Ngay) = @Thang 
    AND YEAR(CT.Ngay) = @Nam
  RETURN @Tong
END

UPDATE TINHLUONG 
SET TienThuongPhat = dbo.fn_TongTienThuongPhat(MaNV, Thang, Nam)
select * from TINHLUONG
----------------------------PROCEDURE------------------------
--drop procedure TinhNgayCong
CREATE PROCEDURE TinhNgayCong
@MaNV char(10),
@Thang int,
@Nam int
AS
BEGIN
  DECLARE @SoNgayCong int
  SELECT @SoNgayCong = 26
  SELECT @SoNgayCong = @SoNgayCong - ISNULL(SUM(DATEDIFF(DAY, TuNgay, DenNgay)+1), 0)
  FROM NGHIPHEP
  WHERE MaNV = @MaNV
    AND MONTH(TuNgay) = @Thang
    AND YEAR(TuNgay) = @Nam
    AND TinhTrang = N'Đã duyệt'  
  UPDATE TINHLUONG 
  SET SoNgayCong = @SoNgayCong
  WHERE MaNV = @MaNV 
    AND Thang = @Thang
    AND Nam = @Nam
END

EXEC TinhNgayCong 'NV102',12,2023

---TÍNH LƯƠNG
--drop procedure TinhTongLuong 
CREATE PROCEDURE TinhTongLuong 
@MaNV char(10),
@Thang int, 
@Nam int
AS  
BEGIN
  DECLARE @LuongCB float
  DECLARE @SoNgayCong int
  DECLARE @TongLuong float
  
  -- Lấy dữ liệu 
  SELECT @LuongCB = L.LuongCB, @SoNgayCong = T.SoNgayCong
  FROM LUONG L JOIN NHANVIEN NV ON L.MucLuong = NV.MucLuong
  JOIN TINHLUONG T ON NV.MaNV = T.MaNV
  WHERE NV.MaNV = @MaNV AND T.Thang = @Thang AND T.Nam = @Nam

  -- Tính tổng lương
  SELECT @TongLuong = @LuongCB/26*@SoNgayCong  

  -- Kiểm tra bản ghi có tồn tại hay không
  IF EXISTS(SELECT * FROM TINHLUONG 
            WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam)
  BEGIN
     -- Nếu có thì update
     UPDATE TINHLUONG  
     SET TongLuong = @TongLuong
     WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam
  END
  ELSE
  BEGIN
     -- Nếu không có thì insert 
     INSERT INTO TINHLUONG (MaNV, Thang, Nam, SoNgayCong, TongLuong)  
     VALUES (@MaNV, @Thang, @Nam, @SoNgayCong, @TongLuong);
  END
END

EXEC TinhTongLuong  'NV101', 12, 2023

