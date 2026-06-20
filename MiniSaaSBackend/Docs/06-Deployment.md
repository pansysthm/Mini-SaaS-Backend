# 06 - Deployment & Setup Guide

Tài liệu này hướng dẫn cách cấu hình và triển khai (deploy) ứng dụng ở môi trường Local và chuẩn bị cho môi trường Production.

---

## 1. Môi trường Local (Development)

### 1.1. Yêu cầu hệ thống (Prerequisites)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (hoặc Docker chạy mssql)
- IDE: Visual Studio 2022, Rider, hoặc VS Code.

### 1.2. Cài đặt Cơ sở dữ liệu (Database Setup)
Dự án sử dụng EF Core Code-First.

1. Đảm bảo connection string trong `appsettings.Development.json` trỏ đúng tới instance SQL Server của bạn:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=MiniSaaS_Db;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```
2. Mở Terminal tại thư mục chứa file `.csproj` và chạy các lệnh sau để tạo DB:
   ```bash
   dotnet tool install --global dotnet-ef  # Nếu chưa cài EF Core CLI
   dotnet ef database update               # Áp dụng migrations mới nhất
   ```

### 1.3. Chạy ứng dụng
```bash
dotnet build
dotnet run
```
Truy cập Swagger UI tại: `https://localhost:<port>/swagger`

---

## 2. Sử dụng Docker (Optional for Local/Prod)

Để dễ dàng thiết lập môi trường, bạn có thể dùng `docker-compose`.

Tạo file `docker-compose.yml` ở thư mục gốc:
```yaml
version: '3.8'
services:
  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      SA_PASSWORD: "Your_password123"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"
    
  api:
    build: .
    ports:
      - "8080:80"
    environment:
      - ConnectionStrings__DefaultConnection=Server=db;Database=MiniSaaS_Db;User Id=sa;Password=Your_password123;TrustServerCertificate=True;
    depends_on:
      - db
```
Chạy lệnh: `docker-compose up -d`

---

## 3. Triển khai Production (CI/CD)

- **Biến môi trường (Environment Variables)**: Đừng bao giờ lưu Connection String, JWT Secret Key, hoặc mật khẩu thật vào repo. Thay vào đó, set chúng qua Environment Variables của máy chủ (Linux/Windows) hoặc container (Docker).
- **Migration Data**: Ở production, nên build file SQL Script thay vì chạy lệnh `dotnet ef database update` trực tiếp, hoặc chạy nó trong CI pipeline.
   ```bash
   dotnet ef migrations script > db_update.sql
   ```
- **Hosting**:
  - Dùng Azure App Service (hoặc AWS Elastic Beanstalk) cho Web API.
  - Azure SQL Database cho Cơ sở dữ liệu.
  - Azure Blob Storage / AWS S3 cho việc lưu trữ Files.