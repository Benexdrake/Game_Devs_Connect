output "tag_url" {
  value = "https://${azurerm_container_app.tag.latest_revision_fqdn}"
}