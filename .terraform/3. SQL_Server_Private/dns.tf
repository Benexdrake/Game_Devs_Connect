// Für Privat
resource "azurerm_private_dns_zone" "sql" {
  name                = "privatelink.database.windows.net"
  resource_group_name = data.azurerm_resource_group.main.name
  tags = var.tags
}

resource "azurerm_private_dns_zone_virtual_network_link" "sql_link" {
  name                  = "sql-dns-link"
  resource_group_name   = data.azurerm_resource_group.main.name
  private_dns_zone_name = azurerm_private_dns_zone.sql.name
  virtual_network_id    = data.azurerm_virtual_network.main.id
  registration_enabled  = false
  tags = var.tags
}

resource "azurerm_private_dns_a_record" "sql" {
  name                = "dns-record-${azurerm_mssql_server.main.name}"
  zone_name           = azurerm_private_dns_zone.sql.name
  resource_group_name = data.azurerm_resource_group.main.name
  ttl                 = 300
  records             = [azurerm_private_endpoint.sql_private_endpoint.private_service_connection[0].private_ip_address]
  tags = var.tags
}