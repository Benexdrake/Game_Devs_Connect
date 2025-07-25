resource "azurerm_container_app" "frontend" {
  depends_on = [ data.azurerm_container_app.gateway]
  name                         = "frontend-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = data.azurerm_container_app_environment.public.id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = 3000
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
      cpu    = 2
      memory = "4.0Gi"

      env {
       name = "BACKEND_URL" 
       value = "https://${data.azurerm_container_app.gateway.latest_revision_fqdn}"
      }

      env {  
        name = "X_ACCESS_KEY"
        value = var.X_ACCESS_KEY
      }

      env {  
        name = "NEXT_PUBLIC_URL"
        value = "https://${var.DOMAIN}"
      }

      env {  
        name = "NEXTAUTH_URL"
        value = "https://${var.DOMAIN}/api/auth"
      }

      env {  
        name = "NEXTAUTH_SECRET"
        value = var.NEXTAUTH_SECRET
      }

      env {  
        name = "DISCORD_ID"
        value = var.DISCORD_ID
      }

      env {  
        name = "DISCORD_SECRET"
        value = var.DISCORD_SECRET
      }

      env {  
        name = "NEXT_PUBLIC_AZURE_STORAGE_CONTAINERNAME"
        value = "files"
      }

      env {  
        name = "NEXT_PUBLIC_AZURE_STORAGE_BASE_UR"
        value = "https://gamedevsconnect.blob.core.windows.net"
      }
    }
  }
  tags = var.tags
}