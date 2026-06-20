# 02 - Technical Design Document (TDD)

## 1. 🏗️ Kiến trúc Tổng thể (High-level Architecture)
Hệ thống áp dụng mô hình **Clean Architecture / N-Tier Architecture** cơ bản, phân tách rõ ràng các tầng trách nhiệm:
- **Presentation Layer**: Controllers, Middleware, Filter.
- **Business Logic Layer**: Services, Handlers (nếu dùng CQRS).
- **Data Access Layer**: Repositories (hoặc DbContext trực tiếp), Entity Framework Core.
- **Database**: SQL Server.

---

## 2. 🧱 Công nghệ và Framework (Tech Stack)

### 2.1. Core
- **Framework**: .NET 8 (hoặc mới nhất) - ASP.NET Core Web API.
- **Ngôn ngữ**: C#.

### 2.2. Database & ORM
- **Cơ sở dữ liệu chính**: Microsoft SQL Server.
- **ORM**: Entity Framework Core (Code First Approach).

### 2.3. Caching & Background Processing
- **Distributed Cache (Optional)**: Redis (dùng cho Rate Limiting, Caching Token, Feature Flags).
- **Background Jobs**: Hangfire (Lưu trữ job trong SQL Server hoặc Redis) hoặc .NET Hosted Services (BackgroundService).

### 2.4. Real-time & Events
- **Real-time communication**: SignalR (Dùng để push notifications cho web clients).

### 2.5. Security
- **Authentication**: JWT (JSON Web Tokens).
- **Password Hashing**: BCrypt.Net-Next hoặc PBKDF2 (Mặc định của ASP.NET Core Identity).

---

## 3. 📌 Các Pattern và Best Practices áp dụng
- **Dependency Injection (DI)**: Đăng ký tất cả Services, DbContext, Repositories qua DI Container tích hợp sẵn.
- **DTOs (Data Transfer Objects)**: Sử dụng AutoMapper hoặc Mapster để map giữa Entities và DTOs, tránh expose DB model ra API.
- **Global Exception Handling**: Sử dụng Middleware để bắt lỗi toàn cục, trả về format chuẩn (RFC 7807 - Problem Details).
- **Validation**: Sử dụng FluentValidation thay cho Data Annotations để tách biệt logic validation khỏi Model.
- **Pagination & Filtering**: Chuẩn hóa format trả về cho các API có danh sách (VD: `PagedResult<T>`).
- **Options Pattern**: Map cấu hình từ `appsettings.json` sang strongly-typed classes.