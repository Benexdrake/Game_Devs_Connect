// Create Virtual Network
resource "azurerm_virtual_network" "main" {
    name                = "vnet-${var.application_name}-${var.environment_name}"
    location            = data.azurerm_resource_group.main.location
    resource_group_name = data.azurerm_resource_group.main.name
    address_space       = [var.base_address_space]
}