output "cluster_name" {
  description = "Name of the EKS cluster"
  value       = aws_eks_cluster.dotnet_cluster.name
}

output "node_group_desired_size" {
  description = "Desired number of nodes in the EKS node group"
  value       = aws_eks_node_group.dotnet_nodegroup.scaling_config[0].desired_size
}
