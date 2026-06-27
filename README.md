# Grand Couch POS System

A modern Windows Forms Point of Sale (POS) application built with **C#**, **.NET**, and **SQLite** for managing inventory, sales, customer debts, and business reports.

## Features

### Inventory Management

* Add new products
* Update product information
* Delete products
* Search inventory
* Track available stock
* Prevent negative inventory

### Billing & Sales

* Create customer invoices
* Automatic total calculation
* Checkout process
* Supports debt purchases
* Validates available stock before completing sales

### Debt Management

* View all unpaid customer debts
* Mark debts as paid
* Automatically update inventory and records
* Track outstanding balances

### Reports

* View sales reports
* Monitor inventory status
* Business performance overview

### User Interface

* Clean modern dashboard
* Rounded buttons
* Dark theme
* Simple navigation
* Easy-to-use layout

---

# Technologies Used

* C#
* Windows Forms (.NET)
* SQLite
* Microsoft.Data.Sqlite

---

# Project Structure

```
GrandCouchPOS/
│
├── HomeForm
│   ├── Inventory
│   ├── Billing
│   ├── Reports
│   ├── Debt Management
│   └── Exit
│
├── InventoryForm
├── BillingForm
├── DebtForm
├── ReportForm
│
├── inventory.db
└── Program.cs
```

---

# Application Flow

```
Home Screen
     │
     ├── Inventory Management
     │
     ├── Billing
     │      ├── Checkout
     │      └── Debt Sale
     │
     ├── Reports
     │
     └── Debt Management
             └── Mark as Paid
```

---

# Database

The application uses a local **SQLite** database (`inventory.db`) to store:

* Products
* Inventory quantities
* Sales history
* Customer debts
* Payment status

---

# Validation

The application includes several validation checks:

* Prevents selling more items than available in stock.
* Prevents debt transactions that exceed available inventory.
* Updates inventory automatically after successful sales.
* Validates user input before saving data.

---

# Installation

1. Clone the repository.

```bash
git clone https://github.com/yourusername/GrandCouchPOS.git
```

2. Open the solution in Visual Studio.

3. Restore NuGet packages.

4. Build the project.

5. Run the application.

---

# Future Improvements

* User authentication
* Customer management
* Barcode scanner support
* Receipt printing
* Export reports to PDF and Excel
* Dashboard analytics
* Product images
* Multi-user support
* Cloud database synchronization
* Backup and restore functionality

---

# Screenshots

You can add screenshots here after uploading them.

```
/Screenshots
    Home.png
    Inventory.png
    Billing.png
    Debt.png
    Reports.png
```

Example:

```
![Home Screen](Screenshots/Home.png)
```

---

# Learning Objectives

This project was developed to strengthen knowledge in:

* Object-Oriented Programming (OOP)
* Windows Forms development
* SQLite database integration
* CRUD operations
* Event-driven programming
* Database validation
* Desktop application architecture

---

# License

This project is intended for educational and portfolio purposes.

---

# Author

**Walid John**

Feel free to fork the project, submit improvements, or use it as a learning resource.
