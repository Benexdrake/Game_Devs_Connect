resource "azurerm_storage_account" "main" {
  name                     = "${var.storage_account_name}"
  resource_group_name      = data.azurerm_resource_group.main.name
  location                 = data.azurerm_resource_group.main.location
  account_tier             = "Standard"
  account_replication_type = "GRS"
  tags = var.tags
}

resource "azurerm_storage_container" "tfstate" {
  name                  = "${var.container_name}"
  storage_account_id    = azurerm_storage_account.main.id
  container_access_type = "private"
}