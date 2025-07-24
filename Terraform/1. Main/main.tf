data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

resource "azurerm_log_analytics_workspace" "main" {
  name                = "${var.application_name}-log-analytics"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
  tags = var.tags
}