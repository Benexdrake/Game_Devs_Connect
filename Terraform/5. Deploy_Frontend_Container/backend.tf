terraform {
  backend "azurerm" {
   resource_group_name  = var.resource_group_name
   storage_account_name = var.storage_account_name
   container_name       = var.container_name
   key                  = "gamedevsconnect.frontend.container.tfstate"
  }
}

provider "azurerm" {
  features {}
  subscription_id = var.subscription_id
}