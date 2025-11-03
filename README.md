<h1 align="center">🚀 ApiDemo</h1>

<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg" width="80" alt=".NET Logo"/>
</p>

<p align="center">
  <b>A lightweight .NET 8 Minimal API project with PostgreSQL, Docker, and Swagger UI.</b><br>
  Built for learning clean architecture, containerization, and modern backend workflows.
</p>

<p align="center">
  <a href="https://github.com/sansfadhillah/ApiDemo/actions">
    <img src="https://img.shields.io/github/actions/workflow/status/sansfadhillah/ApiDemo/dotnet.yml?branch=main&logo=github&style=flat-square" alt="Build Status"/>
  </a>
  <a href="https://hub.docker.com/_/microsoft-dotnet">
    <img src="https://img.shields.io/badge/Docker-Ready-blue?logo=docker&style=flat-square" alt="Docker"/>
  </a>
  <img src="https://img.shields.io/badge/.NET-8.0-purple?logo=dotnet&style=flat-square" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/PostgreSQL-16-blue?logo=postgresql&style=flat-square" alt="PostgreSQL"/>
  <img src="https://img.shields.io/github/license/sansfadhillah/ApiDemo?style=flat-square" alt="License"/>
</p>

---

## 🧩 Overview
**ApiDemo** is a simple yet robust REST API built with **.NET 8**, using **Entity Framework Core** and **PostgreSQL** for persistence.  
It’s fully containerized with Docker and includes Swagger UI for quick testing.

---

## ⚙️ Features
- ✅ CRUD endpoints for Todo items  
- 🧠 Entity Framework Core with PostgreSQL  
- 🔍 Built-in Swagger (OpenAPI 3.0)  
- 🐳 Docker Compose setup  
- 🚀 Ready for cloud deployment or frontend integration (React, Next.js, etc.)

---

## 🛠 Tech Stack

| Layer | Technology |
|-------|-------------|
| Backend | .NET 8 Minimal API |
| Database | PostgreSQL 16 (via Docker) |
| ORM | Entity Framework Core |
| Docs | Swagger / OpenAPI 3.0 |
| Container | Docker Compose |

---

## 🧰 Setup Guide

### 1️⃣ Requirements
- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) + [Docker Compose](https://docs.docker.com/compose/)

---

### 2️⃣ Run Locally
```bash
dotnet run
# Open http://localhost:5184/swagger

