data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_log_analytics_workspace" "main" {
  name = "${var.application_name}-log-analytics"
  resource_group_name = data.azurerm_resource_group.main.name
}