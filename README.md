# Project Manager

## Tổng Quan

**Dự án:** Project Manager

**Ngôn ngữ lập trình:** C#

**Framework:** WPF (Windows Presentation Foundation)

**Database:** SQL Server

**ORM:** Entity Framework

**Mục đích:** Dự án này được thiết kế để quản lý các dự án cá nhân và nhóm, bao gồm việc theo dõi tiến độ, quản lý tài nguyên và nhiệm vụ.

## Các Tính Năng Chính

1. **Quản Lý Dự Án:**
   - Tạo, chỉnh sửa và xóa dự án.
   - Theo dõi tiến độ và trạng thái của từng dự án.
   
2. **Quản Lý Nhiệm Vụ:**
   - Thêm, chỉnh sửa và xóa nhiệm vụ.
   - Gán nhiệm vụ cho thành viên dự án.
   - Thiết lập ưu tiên và hạn chót cho nhiệm vụ.

3. **Quản Lý Thành Viên:**
   - Thêm, chỉnh sửa và xóa thành viên.
   - Quản lý vai trò và quyền hạn của từng thành viên trong dự án.

4. **Báo Cáo:**
   - Tạo báo cáo tiến độ dự án.
   - Xuất báo cáo dưới dạng file PDF hoặc Excel.

## Cài Đặt và Chạy Dự Án

1. **Yêu Cầu Hệ Thống:**
   - .NET Framework 4.7.2 trở lên
   - SQL Server 2017 trở lên

2. **Cài Đặt:**
   - Clone repository từ GitHub: `git clone https://github.com/toiQS/ProjectManager.git`
   - Mở solution trong Visual Studio.
   - Cấu hình chuỗi kết nối đến SQL Server trong file `\Services\ApplicationDbContext.cs`.
   - Chạy lệnh `update-database` để tạo cơ sở dữ liệu và các bảng cần thiết.
   - Build và chạy dự án.

3. **Cấu Hình:**
   - Cập nhật chuỗi kết nối trong `\Services\ApplicationDbContext.cs`:
     ```cs
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
        @"Server={your-sql-server-name};Database=PM;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");

      }
     ```

4. **Chạy Dự Án:**
   - Nhấn F5 trong Visual Studio để build và chạy dự án.

## Phát Triển và Đóng Góp

- **Fork repository** trên GitHub.
- **Tạo branch mới** cho các tính năng hoặc sửa lỗi.
- **Gửi pull request** với mô tả chi tiết về thay đổi.

## Liên Hệ

- **Tác giả:** Nguyen Quoc Sieu
- **Email:** nguyensieu12112002@gmail.com
- **Địa chỉ:** Long An, Viet Nam
