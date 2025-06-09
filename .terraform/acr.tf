resource "azurerm_container_registry" "main" {
  name                      = var.application_name
  resource_group_name       = data.azurerm_resource_group.main.name
  location                  = data.azurerm_resource_group.main.location
  sku                       = "Standard"
  admin_enabled             = true
  anonymous_pull_enabled    = true
}

# resource "null_resource" "acr_push" {
#     for_each = var.vms
#     depends_on = [ azurerm_container_registry.main ]
#   provisioner "local-exec" {
#     command = "bash ./docker/acr.sh ${each.value.image.name}"
#   }
# }