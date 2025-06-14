resource "azurerm_container_app_environment" "public" {
  depends_on = [ azurerm_subnet.public_container ]
  name                              = "cae-public"
  location                          = data.azurerm_resource_group.main.location
  resource_group_name               = data.azurerm_resource_group.main.name
  log_analytics_workspace_id        = data.azurerm_log_analytics_workspace.main.id

  infrastructure_subnet_id          = azurerm_subnet.public_container.id
  internal_load_balancer_enabled    = false
  
  workload_profile {
    name                    = "gdc-apps"
    workload_profile_type   = "D4"
    minimum_count           = 1
    maximum_count           = 3
  }
  tags = var.tags
}