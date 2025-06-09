terraform {
  backend "azurerm" {
   resource_group_name  = var.resource_group_name
   storage_account_name = var.storage_account_name
   container_name       = var.container_name
   key                  = var.key // if az login, u dont need a key use az login tenant <tenantid or name> 
  }
}

// az account show - shows all data as json, like the subscription id
// subscription id as system variable: $env:ARM_SUBSCRIPTION_ID = "id" < Powershell
// export ARM_SUBSCRIPTION_ID="id" < Bash
provider "azurerm" {
  features {}
  subscription_id = var.subscription_id
}