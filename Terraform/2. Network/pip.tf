// Creates a Public static IP
# resource "azurerm_public_ip" "frontend" {
#   name                = "pip-${var.application_name}-${var.environment_name}-frontend"
#   resource_group_name = data.azurerm_resource_group.main.name
#   location            = data.azurerm_resource_group.main.location
#   allocation_method   = "Static"
#   tags = var.tags
# }