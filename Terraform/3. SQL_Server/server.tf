resource "azurerm_mssql_server" "main" {
  name                         = "${var.application_name}-sqlserver"
  resource_group_name          = data.azurerm_resource_group.main.name
  location                     = data.azurerm_resource_group.main.location
  version                      = "12.0"
  administrator_login          = var.administrator_login
  administrator_login_password = "P@ssword1"
  public_network_access_enabled = true
  tags = var.tags
}

resource "azurerm_mssql_firewall_rule" "allow_all" {
  name             = "AllowAll"
  server_id        = azurerm_mssql_server.main.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "255.255.255.255"
}