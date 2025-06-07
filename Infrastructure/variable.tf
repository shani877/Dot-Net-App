variable "region" {
  description = "AWS region to deploy resources"
  type        = string
  default     = "us-east-1"
}

variable "cluster_name" {
  description = "Name of the EKS Cluster"
  type        = string
  default     = "dotnet-cluster"
}

variable "desired_nodes" {
  description = "Desired number of worker nodes in the node group"
  type        = number
  default     = 2
}

variable "max_nodes" {
  description = "Maximum number of worker nodes in the node group"
  type        = number
  default     = 3
}

variable "min_nodes" {
  description = "Minimum number of worker nodes in the node group"
  type        = number
  default     = 1
}

variable "node_instance_type" {
  description = "EC2 instance type for the worker nodes"
  type        = string
  default     = "t3.medium"
}
