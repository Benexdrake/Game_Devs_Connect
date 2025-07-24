output "access_key" {
  value = data.terraform_remote_state.api.outputs.access_key
}

output "sql_pw" {
  value = data.terraform_remote_state.sql.outputs.mssql_admin_password
}

output "ip" {
  value = data.azurerm_public_ip.frontend.ip_address
}