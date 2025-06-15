output "mssql_admin_password" {
  value     = azurerm_mssql_server.main.administrator_login_password
  sensitive = true
}