# 01 - Software Requirements Specification (SRS)

## 1. Mục tiêu (Objective)
Dự án này là một Mini SaaS Backend được xây dựng để cung cấp các dịch vụ cơ bản của một hệ thống Software-as-a-Service. Mục đích chính là tạo ra một nền tảng vững chắc, có thể mở rộng, giúp học tập và áp dụng các best practices trong việc xây dựng Web API với ASP.NET Core, quản lý user, background jobs, và xử lý realtime.

---

## 2. Đối tượng người dùng (User Roles)
- **Admin**: Quản lý toàn bộ hệ thống, quản lý người dùng, thiết lập Feature Flags.
- **User (Tenant)**: Người dùng cuối đăng ký sử dụng dịch vụ, quản lý tài nguyên của mình (files, tasks, notifications).

---

## 3. Yêu cầu chức năng (Functional Requirements)

### 3.1. Authentication & Authorization (Xác thực và phân quyền)
- **Register**: Đăng ký tài khoản mới bằng email và mật khẩu.
- **Login**: Đăng nhập và nhận JWT (JSON Web Token).
- **Authorization**: Phân quyền truy cập tài nguyên theo role (Admin/User).
- **Refresh Token (Optional)**: Hỗ trợ cấp lại token khi token hết hạn mà không cần đăng nhập lại.

### 3.2. File Management (Quản lý file)
- **Upload File**: Người dùng có thể upload các file (hỗ trợ các định dạng cơ bản: hình ảnh, pdf, doc).
- **Get File**: Tải xuống hoặc xem file đã upload.
- **File Limits**: Giới hạn dung lượng upload (VD: 5MB/file) để tối ưu tài nguyên.

### 3.3. Background Tasks (Tác vụ chạy nền)
- **Create Job**: Người dùng có thể tạo một tác vụ xử lý tốn thời gian (ví dụ: export dữ liệu, xử lý ảnh).
- **Track Status**: Xem trạng thái của tác vụ (Pending, Processing, Completed, Failed).
- **Background Worker**: Hệ thống xử lý các tác vụ này trong background (sử dụng Hangfire/BackgroundService).

### 3.4. Notifications (Thông báo)
- **Lưu trữ**: Ghi nhận các sự kiện quan trọng và tạo thông báo cho người dùng.
- **Xem thông báo**: Lấy danh sách thông báo (phân trang), đánh dấu đã đọc (Mark as read).
- **Real-time (Optional)**: Đẩy thông báo trực tiếp đến client đang online (SignalR).

### 3.5. Feature Flags (Quản lý tính năng)
- **Bật/Tắt tính năng**: Admin có thể bật/tắt các tính năng hệ thống mà không cần deploy lại code.
- **Kiểm tra trạng thái**: API kiểm tra xem một tính năng có đang khả dụng cho user hiện tại hay không.

---

## 4. Yêu cầu phi chức năng (Non-functional Requirements)
- **Performance**: API phản hồi dưới 200ms cho các tác vụ thông thường.
- **Security**: Mật khẩu phải được hash an toàn (Bcrypt/Argon2), API phải được bảo vệ chống CORS, XSS, và Rate Limiting.
- **Scalability**: Cấu trúc code phải cho phép dễ dàng mở rộng sang Microservices hoặc thêm các module mới sau này.