# **Bike API Documentation**

## **1. Project Overview**
**Bike API** is a web application built using ASP.NET Core, designed to provide an API for checking bike theft statistics in different cities. The application is containerized using Docker and can be deployed in Kubernetes using a Helm chart.

### **Key Components:**
- **Bike Theft Information API**: Provides REST endpoints to fetch data related to bike thefts.
- **Docker**: Used for containerizing the application, ensuring portability and isolation.
- **Helm**: Simplifies the deployment to a Kubernetes environment.

## **2. Project Structure**
The Bike API project includes several key components and classes, organized into the following directories:

### **2.1 Main Folders and Files**
- **`Bike.Api/`**: 
	- AspNetCore Web application. Contains controller to get required data.

- **`Bike.Domain/`**: 
  - Contains core business logic, models, and interfaces.

- **`BikeApi.Client/`**: 
  - Client implementation to get data from third-party clients.
  
- **`Bike.Domain.Adapters/`**: 
  - Adapt bikeindex.org client to Domain Service.

- **`Dockerfile`**: Contains the steps for building the Docker image for the Bike API. It uses multi-stage builds for efficiency:
  - **Base stage**: Uses the ASP.NET Core runtime.
  - **Build stage**: Uses the .NET SDK to build the application.
  - **Final stage**: Copies the build output to create a minimal runtime container.

- **`docker-compose.yml`**: Defines services to run the Bike API in Docker, including port bindings for external access.

- **`helm/`**:
  - Helm chart templates for deploying the API to a Kubernetes cluster, providing configurability for different environments.

## **3. Configuration**
### **3.1 AppSettings**
The configuration values, such as the API's base URI and application name, are stored in `appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUri": "https://bikeindex.org:443/api/v3/",
    "ApplicationName": "BikeApi"
  }
}
```


## **4. Running the Application**

### **4.1 Running Locally with Docker**
1. **Build the Docker Image**:
   ```sh
   docker build -t bikehub/bike-api:latest
   ```

2. **Run the Docker Container**:
   ```sh
	docker run -d -p 8080:8080 bikehub/bike-api:latest
   ```