data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_virtual_network" "main" {
  name = "vnet-${var.application_name}-${var.environment_name}"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_subnet" "private_sql_subnet" {
  name = "subnet-private-sql"
  resource_group_name = data.azurerm_resource_group.main.name
  virtual_network_name = data.azurerm_virtual_network.main.name
}

resource "random_password" "sql_password" {
  length = 12
  upper = true
  special = false
  numeric = true
  lower = true
}