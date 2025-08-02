resource "azurerm_container_app" "gateway" {
  depends_on = [
                azurerm_container_app.azure,
                azurerm_container_app.file,
                azurerm_container_app.notification,
                azurerm_container_app.profile,
                azurerm_container_app.project,
                azurerm_container_app.post,
                azurerm_container_app.quest,
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
      cpu    = 2
      memory = "4.0Gi"

      env {
       name = "AZURE_URL" 
       value = "https://${azurerm_container_app.azure.latest_revision_fqdn}"
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
       name = "POST_URL" 
       value = "https://${azurerm_container_app.post.latest_revision_fqdn}"
      }
      env {
       name = "QUEST_URL" 
       value = "https://${azurerm_container_app.quest.latest_revision_fqdn}"
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
        value = var.X_ACCESS_KEY
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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

# resource "azurerm_container_app" "frontend" {
#   depends_on = [ azurerm_container_app.gateway]
#   name                         = "frontend-container"
#   resource_group_name          = data.azurerm_resource_group.main.name
#   container_app_environment_id = data.azurerm_container_app_environment.public.id
#   revision_mode = "Single"

#   ingress {
#     external_enabled = true
#     target_port      = 3000
#     transport        = "auto"
#     traffic_weight {
#       percentage = 100
#       revision_suffix = "initial"
#     }
#   }

#   template {
#     container {
#       name   = "frontend"
#       image  = "benexdrake012/gamedevsconnect_frontend"
#       cpu    = 2
#       memory = "4.0Gi"

#       env {
#        name = "BACKEND_URL" 
#        value = "https://${azurerm_container_app.gateway.latest_revision_fqdn}"
#       }

#       env {  
#         name = "X-Access-Key"
#         value = var.X_ACCESS_KEY
#       }

#       env {  
#         name = "NEXT_PUBLIC_URL"
#         value = "https://${var.DOMAIN}"
#       }

#       env {  
#         name = "NEXTAUTH_URL"
#         value = "https://${var.DOMAIN}/api/auth"
#       }

#       env {  
#         name = "NEXTAUTH_SECRET"
#         value = var.NEXTAUTH_SECRET
#       }


#       env {  
#         name = "DISCORD_ID"
#         value = var.DISCORD_ID
#       }

#       env {  
#         name = "DISCORD_SECRET"
#         value = var.DISCORD_SECRET
#       }

#       env {  
#         name = "NEXT_PUBLIC_AZURE_STORAGE_CONTAINERNAME"
#         value = "files"
#       }

#       env {  
#         name = "NEXT_PUBLIC_AZURE_STORAGE_BASE_UR"
#         value = "https://gamedevsconnect.blob.core.windows.net"
#       }
#     }
#   }
#   tags = var.tags
# }