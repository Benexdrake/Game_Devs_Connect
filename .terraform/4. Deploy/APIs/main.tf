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

data "terraform_remote_state" "db" {
  backend = "azurerm"
  config = {
   resource_group_name  = var.resource_group_name
   storage_account_name = var.storage_account_name
   container_name       = var.container_name
   key                  = "gamedevsconnect.sql.tfstate"
  }
}

resource "random_password" "access_key" {
  length = 24
  upper = true
  special = false
  numeric = true
  lower = true
}