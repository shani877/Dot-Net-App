# Dummy .NET Core Application

## Overview
This repository contains a simple .NET Core application demonstrating basic web endpoints. The application can be run locally without Docker or deployed within a Docker container.

---

## Run Locally (Without Docker)

Follow these steps to clone, restore dependencies, and run the application on your local machine:

1. **Clone the repository**
    ```bash
    git clone https://github.com/your-username/dummy-dotnet-core.git
    cd dummy-dotnet-core
    ```

2. **Restore dependencies**
    ```bash
    dotnet restore
    ```

3. **Run the application**
    ```bash
    dotnet run --urls "http://0.0.0.0:5000"
    ```

4. **Access the application**
    Open your browser and navigate to:
    - [http://localhost:5000/](http://localhost:5000/)
    - [http://localhost:5000/Home/time](http://localhost:5000/Home/time)
    - [http://localhost:5000/Home/times](http://localhost:5000/Home/times)

---

## Run with Docker

Execute the following steps to build and run the application within a Docker container:

1. **Build the Docker image**
    ```bash
    docker build -t dummy-dotnet-core .
    ```

2. **Run the Docker container**
    ```bash
    docker run -d -p 5000:5000 --name dummy-dotnet-container dummy-dotnet-core
    ```

3. **Access the application via browser**

    Replace `<your-ec2-public-ip>` with the public IP address of your EC2 instance:

    - `http://<your-ec2-public-ip>:5000/`
    - `http://<your-ec2-public-ip>:5000/Home/time`
    - `http://<your-ec2-public-ip>:5000/Home/times`

---

## Notes
- Ensure that the port `5000` is open and accessible if running on a cloud environment.
- Docker must be installed and running on your host machine to use the Docker instructions.
- The application targets .NET Core; ensure you have the appropriate SDK installed locally.

---
