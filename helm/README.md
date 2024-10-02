# Helm Deployment Documentation

## Prerequisites

Before deploying your application using Helm, ensure you have the following installed:

- [Docker](https://www.docker.com/get-started/)
- [Kubernetes](https://kubernetes.io/docs/setup/)
- [Helm](https://helm.sh/docs/intro/install/)

## Installation

To deploy your application with Helm, follow these steps:

### 1 Build Docker image

   ```sh
	docker build -t bikeapi:test .
   ```

### 2. Configure `values.yaml`

Before deploying, you may want to customize the `values.yaml` file.

**Image Configuration:**

- Update the image repository and tag.  

   ```yaml
	image:
	  repository: bikehub/bike-api  # Update with your image repository
	  tag: latest                     # Specify the image tag to use
	  pullPolicy: IfNotPresent        # Policy for pulling the image
   ```


**Service Configuration:**

- Enable or disable the service.  
  ```yaml
  service:
	  enabled: true                   # Set to true to enable the service
	  annotations: {}                 # Annotations for the service
	  type: ClusterIP                 # Service type (e.g., ClusterIP, NodePort)
	  port: 8080                      # Service port
   ```

### 3. Install Helm Chart

You can deploy the application using the Helm command.  
    ```sh
	helm install bike-api ./helm   # Command to install the Helm chart
    ```

### 4. Verify the Deployment

Check if the application is running and accessible.  
   ```sh
   kubectl get all
   ```


### 5. Accessing the Application

After deployment, you may need to access your application through the specified service endpoint.  
   ```sh
   http://localhost:8080           # Example URL to access the application
   ```

### 6. Cleanup

If you need to uninstall the application, use the appropriate Helm command.  
   ```sh
   helm uninstall bike-api         # Command to uninstall the Helm release
   ```
