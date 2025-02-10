# 🏭 Automated Industrial Report Generator

The **Automated Industrial Report Generator** is a **C# WinForms application** that connects to a **PostgreSQL database**, retrieves **machine data**, and **generates reports in PDF and Excel** format. It can also **automate report generation (daily, weekly, monthly)** and send reports via **email**.

---

## 🚀 Features
- ✅ **Connects to a PostgreSQL database**  
- ✅ **Displays machine data in a DataGridView**  
- ✅ **Generates reports (PDF & Excel)**  
- ✅ **Sends reports via email**  
- ✅ **Automates report generation (Daily/Weekly/Monthly) using a Timer**  
- ✅ **Allows scheduling reports & email notifications**

---

## 🛠 Installation & Setup

### **1️⃣ Install PostgreSQL**
1. Download & install **PostgreSQL** from [official site](https://www.postgresql.org/download/).
2. Open **pgAdmin** and log in.
3. Create a **new database**:  
   - **Name**: `industrial_reports`

---

### **2️⃣ Create the `machine_data` Table**
1. Open **pgAdmin** and select the `industrial_reports` database.
2. Click **Tools → Query Tool** and run the following SQL:
```sql
CREATE TABLE machine_data (
    id SERIAL PRIMARY KEY,
    machine_name VARCHAR(255),
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    temperature NUMERIC(5,2),
    pressure NUMERIC(5,2),
    status VARCHAR(50)
);
```
4. Insert sample data:
INSERT INTO machine_data (machine_name, temperature, pressure, status) 
VALUES 
('Machine A', 75.5, 1.2, 'Running'),
('Machine B', 60.3, 1.1, 'Stopped'),
('Machine C', 80.1, 1.3, 'Running');
### **3️⃣ Configure Database Connection**
Open the DatabaseHelper.cs file and update the connection string:
private string connectionString = "Host=localhost;Port=5432;Username=your_user;Password=your_password;Database=industrial_reports";
Replace your_user and your_password with your PostgreSQL credentials.
### **4️⃣ Install Dependencies** 
Ensure you have installed the required NuGet packages in Visual Studio:
dotnet add package Dapper
dotnet add package Npgsql
dotnet add package System.Data.SqlClient
dotnet add package iTextSharp.LGPLv2.Core
dotnet add package ClosedXML
dotnet add package MailKit

## 📌 How to Use the App
- 1️⃣ Load Machine Data:
Click "Load Machine Data" to retrieve data from PostgreSQL.
- 2️⃣ Generate Reports
Click "Generate PDF Report" to create a PDF file.
Click "Generate Excel Report" to create an Excel file.
- 3️⃣ Send Reports via Email
Enter the recipient's email in the text box.
Click "Send Report via Email" to send a PDF attachment.
- 4️⃣ Automate Reports (Daily/Weekly/Monthly)
Select a schedule (Daily, Weekly, Monthly).
Check "Enable Automated Reports" to start auto-reporting.
The app will automatically generate & send reports at the selected interval.

## 📧 Email Setup (Gmail)
  If using Gmail, enable App Passwords:
      Go to Google App Passwords.
      Generate a 16-character App Password.
      Use it in EmailHelper.cs instead of your normal password.
