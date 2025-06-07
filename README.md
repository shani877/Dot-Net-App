# .NET Core - Dummy Project

# CI/CD Infrastructure Setup with Jenkins, Docker, EKS and Terraform

## Prerequisites & Tool Installation

```bash
#Install .NET SDK 6.0
sudo apt update
sudo apt install -y wget apt-transport-https software-properties-common
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-6.0
dotnet --version
```

```bash
# Clone the setup scripts
git clone https://github.com/shani877/scripts.git
cd script

# Install essential tooling
bash docker.sh
bash jenkins.sh
bash kubectl.sh
bash eksctl.sh
bash terraform.sh
bash aws.sh
```

---

## Step 1: Provision Infrastructure via Terraform

```bash
# Clone and navigate to the infrastructure repo
git clone https://github.com/shani877/Dot-Net-App.git
cd Infrastructure

terraform init
terraform plan
terraform apply
```

---

## Step 2: Add Jenkins to Docker Group

```bash
sudo usermod -aG docker jenkins
sudo newgrp docker
```

---

## Step 3: Configure AWS CLI for Jenkins

```bash
su jenkins

# Configure AWS credentials
aws configure

# Set correct permissions
chown -R jenkins:jenkins /var/lib/jenkins/.aws

# Update kubeconfig for EKS cluster access
aws eks update-kubeconfig --region us-east-1 --name dotnet-cluster

# Verify access
kubectl get nodes
```

---

## Step 4: Jenkins UI Configuration

1. Access Jenkins UI (`http://<jenkins-ip>:8080`)
2. Navigate to **Manage Jenkins > Plugins** and install:
   - Docker Pipeline
   - Pipeline
   - Kubernetes CLI Plugin (if needed)

3. Navigate to **Manage Jenkins > Credentials**:
   - Add DockerHub registry credentials

---

## Step 5: Run CI/CD Pipeline

1. Create a new Jenkins Pipeline job
2. Configure **Pipeline from SCM** (GitHub)
3. Mention `jenkins.jdp` in pipeline
4. Run the pipeline

```bash
# Validate Kubernetes deployment
kubectl get svc
```

5. Access your application via the LoadBalancer endpoint displayed

---

## Notes

- Confirm Jenkins user has Docker and Kubernetes access
- Port 5000 is open in inbound rule.
- IAM user has AdministratorAccess attach.
