data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "terraform_remote_state" "api" {
  backend = "azurerm"
  config = {
   resource_group_name  = var.resource_group_name
   storage_account_name = var.storage_account_name
   container_name       = var.container_name
   key                  = "gamedevsconnect.api.tfstate"
  }
}

data "terraform_remote_state" "sql" {
  backend = "azurerm"
  config = {
   resource_group_name  = var.resource_group_name
   storage_account_name = var.storage_account_name
   container_name       = var.container_name
   key                  = "gamedevsconnect.sql.tfstate"
  }
}