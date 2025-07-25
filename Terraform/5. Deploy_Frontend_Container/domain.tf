resource "azurerm_container_app_custom_domain" "custom_domain" {
  name                     = var.DOMAIN
  container_app_id         = azurerm_container_app.frontend.id
  certificate_binding_type = "SniEnabled"
}