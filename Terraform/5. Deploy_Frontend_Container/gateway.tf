# resource "azurerm_application_gateway" "appgw" {
#   name                = "appgw"
#   location            = data.azurerm_resource_group.main.location
#   resource_group_name = data.azurerm_resource_group.main.name

#   sku {
#     name     = "Standard_v2"
#     tier     = "Standard_v2"
#     capacity = 1
#   }

#   gateway_ip_configuration {
#     name      = "appgw-ip-config"
#     subnet_id = data.azurerm_subnet.public.id
#   }

#   frontend_ip_configuration {
#     name                 = "appgw-frontend-ip"
#     public_ip_address_id = data.azurerm_public_ip.public.id
#   }

#   frontend_port {
#     name = "httpsPort"
#     port = 443
#   }

#   backend_address_pool {
#     name = "backendPool"
#     fqdns = [azurerm_container_app.frontend.latest_revision_fqdn]
#   }

# backend_http_settings {
#   name                            = "backendHttpSettings"
#   cookie_based_affinity           = "Disabled"
#   port                            = 443
#   protocol                        = "Https"
#   pick_host_name_from_backend_address = true
#   probe_name                      = "healthProbe"
# }

# http_listener {
#   name                           = "appgwHttpsListener"
#   frontend_ip_configuration_name = "appgw-frontend-ip"
#   frontend_port_name             = "httpsPort"
#   protocol                       = "Https"
#   # ssl_certificate_name           = "appgw-cert"
# }

#   request_routing_rule {
#     name                       = "rule1"
#     rule_type                  = "Basic"
#     http_listener_name         = "appgwListener"
#     backend_address_pool_name  = "backendPool"
#     backend_http_settings_name = "backendHttpSettings"
#     priority = 100
#   }

# probe {
#   name                = "healthProbe"
#   protocol            = "Https"
#   host                = azurerm_container_app.frontend.latest_revision_fqdn
#   path                = "/"
#   interval            = 30
#   timeout             = 30
#   unhealthy_threshold = 3
# }

# # ssl_certificate {
# #   name = "appgw-cert"
# #   data = ""
# # }

# }
