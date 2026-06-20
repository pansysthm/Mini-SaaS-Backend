# 04 - API Specifications

Tất cả các request và response trả về sử dụng định dạng `application/json`.
Tất cả các endpoints (ngoại trừ Auth) đều yêu cầu header: `Authorization: Bearer <token>`.

---

## 1. Authentication (`/api/auth`)

### 1.1. Đăng ký tài khoản mới
- **Endpoint**: `POST /api/auth/register`
- **Quyền**: Public
- **Request Body**:
  ```json
  {
    "email": "user@example.com",
    "password": "Password123!"
  }
  ```
- **Responses**:
  - `201 Created`: Đăng ký thành công.
  - `400 Bad Request`: Email đã tồn tại hoặc format không hợp lệ.

### 1.2. Đăng nhập
- **Endpoint**: `POST /api/auth/login`
- **Quyền**: Public
- **Request Body**:
  ```json
  {
    "email": "user@example.com",
    "password": "Password123!"
  }
  ```
- **Responses**:
  - `200 OK`: `{ "token": "ey...", "expiresIn": 3600 }`
  - `401 Unauthorized`: Sai email hoặc mật khẩu.

---

## 2. File Management (`/api/files`)

### 2.1. Upload File
- **Endpoint**: `POST /api/files/upload`
- **Quyền**: Yêu cầu đăng nhập
- **Request (multipart/form-data)**:
  - `file`: (Binary data)
- **Responses**:
  - `201 Created`: `{ "id": "guid", "fileName": "...", "url": "..." }`
  - `400 Bad Request`: File quá lớn hoặc sai định dạng.

### 2.2. Lấy thông tin & Tải file
- **Endpoint**: `GET /api/files/{id}`
- **Quyền**: Chủ sở hữu file
- **Responses**:
  - `200 OK`: File stream (tải xuống).
  - `404 Not Found`: Không tìm thấy file.

---

## 3. Background Tasks (`/api/tasks`)

### 3.1. Tạo tác vụ mới
- **Endpoint**: `POST /api/tasks`
- **Quyền**: Yêu cầu đăng nhập
- **Request Body**:
  ```json
  {
    "name": "Export Data",
    "parameters": { "format": "csv" }
  }
  ```
- **Responses**:
  - `202 Accepted`: Trả về `taskId` để tracking.

### 3.2. Kiểm tra trạng thái tác vụ
- **Endpoint**: `GET /api/tasks/{id}`
- **Quyền**: Chủ sở hữu task
- **Responses**:
  - `200 OK`: `{ "id": "...", "status": "Processing", ... }`

---

## 4. Notifications (`/api/notifications`)

### 4.1. Lấy danh sách thông báo
- **Endpoint**: `GET /api/notifications?page=1&pageSize=10`
- **Quyền**: Yêu cầu đăng nhập
- **Responses**:
  - `200 OK`: Danh sách thông báo có phân trang.

### 4.2. Đánh dấu đã đọc
- **Endpoint**: `PUT /api/notifications/{id}/read`
- **Quyền**: Yêu cầu đăng nhập
- **Responses**:
  - `204 No Content`: Thành công.

---

## 5. Feature Flags (`/api/features`)

### 5.1. Lấy danh sách cờ tính năng
- **Endpoint**: `GET /api/features`
- **Quyền**: Public hoặc Yêu cầu đăng nhập (để xem feature áp dụng cho user).
- **Responses**:
  - `200 OK`: `[{ "key": "BetaUI", "isEnabled": true }]`

### 5.2. Thay đổi trạng thái tính năng (Admin)
- **Endpoint**: `POST /api/features/toggle`
- **Quyền**: Yêu cầu Role Admin
- **Request Body**:
  ```json
  {
    "key": "BetaUI",
    "isEnabled": false
  }
  ```
- **Responses**:
  - `200 OK`: Cập nhật thành công.
  - `403 Forbidden`: User không có quyền Admin.