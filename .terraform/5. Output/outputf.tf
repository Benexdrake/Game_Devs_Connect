output "output" {
  value = {
    "dashboard_ip" = "http://${data.azurerm_public_ip.dashboard.ip_address}",
    "sql_name" = data.azurerm_mssql_server.sql.fully_qualified_domain_name,
    "azure_url" = "http://${data.azurerm_container_app.azure.latest_revision_fqdn}",
    "comment_url" = "http://${data.azurerm_container_app.comment.latest_revision_fqdn}",
    "file_url" = "http://${data.azurerm_container_app.file.latest_revision_fqdn}",
    "notification_url" = "http://${data.azurerm_container_app.notification.latest_revision_fqdn}",
    "profile_url" = "http://${data.azurerm_container_app.profile.latest_revision_fqdn}",
    "project_url" = "http://${data.azurerm_container_app.project.latest_revision_fqdn}",
    "request_url" = "http://${data.azurerm_container_app.request.latest_revision_fqdn}",
    "tag_url" = "http://${data.azurerm_container_app.tag.latest_revision_fqdn}",
    "user_url" = "http://${data.azurerm_container_app.user.latest_revision_fqdn}",
    "gateway_url" = "http://${data.azurerm_container_app.gateway.latest_revision_fqdn}",
    "frontend_url" = "http://${data.azurerm_container_app.frontend.latest_revision_fqdn}"
  }
}