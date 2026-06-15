# 05 - Architecture

## 🧠 Pattern

Controller → Service → DbContext → SQL Server

---

## 📌 Giải thích

- Controller: nhận request
- Service: xử lý logic
- DbContext: EF Core
- SQL Server: lưu dữ liệu

---

## ⚡ Optional

- SignalR: realtime notification
- Hangfire: background job