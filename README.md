<h1 align="center"> Skinet </h1>
<p align="center"> A Modern Full-Stack E-commerce Solution for Seamless Online Shopping </p>

<p align="center">
  <img alt="Build" src="https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge">
  <img alt="Issues" src="https://img.shields.io/badge/Issues-0%20Open-blue?style=for-the-badge">
  <img alt="Contributions" src="https://img.shields.io/badge/Contributions-Welcome-orange?style=for-the-badge">
  <img alt="License" src="https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge">
</p>
<!-- 
  **Note:** These are static placeholder badges. Replace them with your project's actual badges.
  You can generate your own at https://shields.io
-->

## Table of Contents
- [⭐ Overview](#-overview)
- [✨ Key Features](#-key-features)
- [🛠️ Tech Stack & Architecture](#️-tech-stack--architecture)
- [🚀 Getting Started](#-getting-started)
- [🔧 Usage](#-usage)
- [🤝 Contributing](#-contributing)
- [📝 License](#-license)

## ⭐ Overview
Skinet is a sophisticated, full-stack e-commerce platform designed to deliver a seamless and engaging online shopping experience.

> The modern digital marketplace demands robust, scalable, and user-friendly e-commerce solutions that are often complex and expensive to develop from scratch. Businesses need a foundational platform that efficiently handles product management, customer interactions, and secure transactions.

Skinet provides an elegant solution by offering a ready-to-deploy, high-performance platform. It features a rich product catalog, an intuitive shopping cart, a secure checkout flow, and a responsive user interface, all built on a modern, maintainable architecture.

Skinet employs a clean, decoupled architecture consisting of a robust ASP.NET Core API backend and a dynamic Angular frontend. The backend is responsible for data management, business logic, and API exposition, while the frontend provides a rich, interactive user interface. Data persistence is handled using Entity Framework Core with SQLite for development, and potentially Redis for fast data access (e.g., shopping baskets). The entire application is containerized with Docker for easy deployment and scalability.

## ✨ Key Features
*   **Comprehensive Product Catalog:** Manage a diverse range of products, brands, and types with rich details and imagery, powered by efficient data retrieval mechanisms.
*   **Intuitive Shopping Basket:** A persistent and easy-to-use shopping basket system allows users to add, update, and remove items before proceeding to checkout.
*   **Advanced Product Filtering & Pagination:** Users can effortlessly browse and discover products using powerful filtering, sorting, and pagination capabilities for an optimized shopping experience.
*   **Robust Error Handling:** A centralized exception handling middleware ensures a smooth user experience by gracefully managing API errors and providing informative, structured error responses.
*   **Secure and Responsive UI:** Built with Angular, the frontend delivers a fast, responsive, and secure user interface, complete with SSL configuration for encrypted communication.
*   **Containerized Deployment:** Leverage Docker and Docker Compose for easy setup, consistent development environments, and scalable deployment across various environments.
*   **Interactive API Documentation:** Automatically generated Swagger/OpenAPI documentation provides an interactive interface for exploring and testing all API endpoints.

## 🛠️ Tech Stack & Architecture
| Technology              | Purpose                           | Why it was Chosen                                                                      |
| :---------------------- | :-------------------------------- | :------------------------------------------------------------------------------------- |
| **ASP.NET Core**        | Backend API & Business Logic      | High performance, cross-platform compatibility, robust ecosystem, and developer productivity. |
| **Angular**             | Frontend User Interface           | Powerful framework for building dynamic, single-page applications with excellent tooling. |
| **Entity Framework Core** | ORM for Data Access               | Simplifies database interactions, supports LINQ queries, and integrates seamlessly with .NET. |
| **SQLite**              | Local Development Database        | Lightweight, file-based database for easy local setup and rapid development.           |
| **Redis**               | Distributed Caching & Basket Store | High-performance in-memory data store for caching and managing shopping basket data efficiently. |
| **Docker & Docker Compose** | Containerization & Orchestration  | Enables consistent development environments, easy deployment, and scalability.         |
| **Bootstrap & Bootswatch** | UI Styling & Theming            | Provides a responsive, mobile-first design system for a modern aesthetic.              |
| **Swagger/OpenAPI**     | API Documentation & Testing       | Automatic generation of interactive API documentation for easy integration and testing. |
| **ngx-spinner**         | Loading Indicators                | Provides user-friendly loading animations to enhance user experience during asynchronous operations. |
| **ngx-toastr**          | Notification System               | Displays elegant and informative toast notifications for user feedback.                 |
| **xng-breadcrumb**      | Breadcrumb Navigation             | Simplifies the implementation of dynamic breadcrumb navigation paths.                  |

## 🚀 Getting Started

To get Skinet up and running on your local machine, follow these steps.

### Prerequisites
Ensure you have the following software installed:
*   [.NET SDK](https://dotnet.microsoft.com/download) (Version 8.0 or later)
*   [Node.js](https://nodejs.org/) (v18.x or later)
*   [npm](https://www.npmjs.com/) (typically included with Node.js)
*   [Docker Desktop](https://www.docker.com/products/docker-desktop/) (recommended for containerized deployment)

### Installation

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/Darsh-8-Skinet-Ecommerce-in-.Net-and-Angular-f7504eb/Skinet.git
    cd Skinet
    ```

2.  **Option 1: Local Development Setup**

    *   **Backend (API) Setup:**
        Navigate to the `skinet` directory, which contains the ASP.NET Core API project.
        ```bash
        cd skinet
        dotnet restore
        dotnet ef database update # Apply migrations and create the SQLite database
        dotnet run # Start the API
        ```
        The API will typically run on `https://localhost:5001`.

    *   **Frontend (Angular) Setup:**
        In a new terminal, navigate to the `client` directory.
        ```bash
        cd ../client
        npm install
        ng serve --ssl true # Start the Angular development server with SSL
        ```
        The frontend will typically run on `https://localhost:4200`.

3.  **Option 2: Containerized Setup with Docker Compose**

    From the project root directory (`Skinet/`), run the following command to build and start all services:
    ```bash
    docker-compose up --build
    ```
    This will build and start both the backend API and frontend client services, along with any necessary dependencies like Redis.

## 🔧 Usage

### Accessing the Application
*   **Frontend:** Once the frontend is running (either via `ng serve` or Docker Compose), open your web browser and navigate to `https://localhost:4200` (or the port specified by Docker Compose, usually 4200 mapped).
*   **Backend API & Documentation:**
    *   The API endpoints are available at `https://localhost:5001`.
    *   Interactive API documentation (Swagger UI) can be accessed at `https://localhost:5001/swagger`.

### Example API Interaction
You can interact with the API using tools like `curl` or Postman. Here's an example using `curl` to fetch products:

```bash
curl -X GET "https://localhost:5001/api/products" -k -H "accept: application/json"
```
*(Note: The `-k` flag is used for local development due to self-signed SSL certificates. Remove it for production environments with trusted certificates.)*

## 🤝 Contributing

We welcome contributions to Skinet! If you're interested in improving the project, please follow these steps:

1.  **Fork** the repository.
2.  **Create a new branch** for your feature or bug fix (e.g., `feature/add-checkout-steps` or `fix/product-pagination`).
3.  **Make your changes** and ensure they adhere to the project's coding standards.
4.  **Commit your changes** with clear, descriptive messages.
5.  **Push your branch** to your forked repository.
6.  **Open a Pull Request** to the `main` branch of the original repository, providing a detailed description of your changes.

