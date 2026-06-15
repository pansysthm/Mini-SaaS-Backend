# 03 - ERD

## Database: SQL Server

---

## Users
- Id
- Email
- PasswordHash
- Role
- CreatedAt

---

## Files
- Id
- UserId
- FileName
- FilePath
- CreatedAt

---

## Tasks
- Id
- UserId
- Name
- Status
- RunAt

---

## Notifications
- Id
- UserId
- Message
- IsRead
- CreatedAt

---

## FeatureFlags
- Id
- Key
- IsEnabled