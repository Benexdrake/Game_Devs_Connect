data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_container_app_environment" "public" {
  name                = "cae-public"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_mssql_server" "main" {
  name                = "${var.application_name}-sqlserver"
  resource_group_name = data.azurerm_resource_group.main.name
}