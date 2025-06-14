resource "azurerm_container_app" "gateway" {
  depends_on = [
                azurerm_container_app.azure,
                azurerm_container_app.comment,
                azurerm_container_app.file,
                azurerm_container_app.notification,
                azurerm_container_app.profile,
                azurerm_container_app.project,
                azurerm_container_app.request,
                azurerm_container_app.tag,
                azurerm_container_app.user
                ]
  name                         = "api-gateway-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = data.azurerm_container_app_environment.public.id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = 8080
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = "gateway"
      image  = "benexdrake012/gamedevsconnect_backend_api_gateway"
      cpu    = 0.5
      memory = "1.0Gi"

      env {
       name = "AZURE_URL" 
       value = "https://${azurerm_container_app.azure.latest_revision_fqdn}"
      }
      env {
       name = "COMMENT_URL" 
       value = "https://${azurerm_container_app.comment.latest_revision_fqdn}"
      }
      env {
       name = "FILE_URL" 
       value = "https://${azurerm_container_app.file.latest_revision_fqdn}"
      }
      env {
       name = "NOTIFICATION_URL" 
       value = "https://${azurerm_container_app.notification.latest_revision_fqdn}"
      }
      env {
       name = "PROJECT_URL" 
       value = "https://${azurerm_container_app.project.latest_revision_fqdn}"
      }
      env {
       name = "PROFILE_URL" 
       value = "https://${azurerm_container_app.profile.latest_revision_fqdn}"
      }
      env {
       name = "REQUEST_URL" 
       value = "https://${azurerm_container_app.request.latest_revision_fqdn}"
      }
      env {
       name = "TAG_URL" 
       value = "https://${azurerm_container_app.tag.latest_revision_fqdn}"
      }
      env {
       name = "USER_URL" 
       value = "https://${azurerm_container_app.user.latest_revision_fqdn}"
      }
      env {
        name = "X-Access-Key"
        value = local.access_key
      }
      env {
        name = "SQL_URL"
        value = data.azurerm_mssql_server.main.fully_qualified_domain_name
      }
      env {
        name = "SQL_ADMIN_USERNAME"
        value = data.azurerm_mssql_server.main.administrator_login
      }
      env {
        name = "SQL_ADMIN_PASSWORD"
        value = "P@ssword1"
      }
    }
  }
  tags = var.tags
}

resource "azurerm_container_app" "frontend" {
  depends_on = [ azurerm_container_app.gateway ]
  name                         = "frontend-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = data.azurerm_container_app_environment.public.id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = 8080
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = "frontend"
      image  = "benexdrake012/gamedevsconnect_frontend"
      cpu    = 0.5
      memory = "1.0Gi"

      env {
       name = "API_URL" 
       value = "https://${azurerm_container_app.gateway.latest_revision_fqdn}"
      }
    }
  }
  tags = var.tags
}