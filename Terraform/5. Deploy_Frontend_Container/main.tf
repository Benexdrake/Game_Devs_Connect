data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_virtual_network" "main" {
  name = "vnet-${var.application_name}-${var.environment_name}"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_container_app_environment" "public" {
  name                = "cae-public"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_container_app" "gateway" {
  name = "api-gateway-container"
  resource_group_name = data.azurerm_resource_group.main.name
}