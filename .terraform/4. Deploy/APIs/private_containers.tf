// Azure
resource "azurerm_container_app" "azure" {
  name                         = "api-${local.containers["azure"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["azure"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["azure"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["azure"].template.name
      image  = local.containers["azure"].template.image
      cpu    = local.containers["azure"].template.cpu
      memory = local.containers["azure"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// Comment

resource "azurerm_container_app" "comment" {
  name                         = "api-${local.containers["comment"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["comment"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["comment"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["comment"].template.name
      image  = local.containers["comment"].template.image
      cpu    = local.containers["comment"].template.cpu
      memory = local.containers["comment"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  

  tags = var.tags
}
// File
resource "azurerm_container_app" "file" {
  name                         = "api-${local.containers["file"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["file"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["file"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["file"].template.name
      image  = local.containers["file"].template.image
      cpu    = local.containers["file"].template.cpu
      memory = local.containers["file"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// Notification
resource "azurerm_container_app" "notification" {
  name                         = "api-${local.containers["notification"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["notification"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["notification"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["notification"].template.name
      image  = local.containers["notification"].template.image
      cpu    = local.containers["notification"].template.cpu
      memory = local.containers["notification"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }

  tags = var.tags
}

// Profile
resource "azurerm_container_app" "profile" {
  name                         = "api-${local.containers["profile"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["profile"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["profile"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["profile"].template.name
      image  = local.containers["profile"].template.image
      cpu    = local.containers["profile"].template.cpu
      memory = local.containers["profile"].template.memory
    
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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// Project
resource "azurerm_container_app" "project" {
  name                         = "api-${local.containers["project"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["project"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["project"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["project"].template.name
      image  = local.containers["project"].template.image
      cpu    = local.containers["project"].template.cpu
      memory = local.containers["project"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// Request
resource "azurerm_container_app" "request" {
  name                         = "api-${local.containers["request"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["request"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["request"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["request"].template.name
      image  = local.containers["request"].template.image
      cpu    = local.containers["request"].template.cpu
      memory = local.containers["request"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// Tag
resource "azurerm_container_app" "tag" {
  name                         = "api-${local.containers["tag"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["tag"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["tag"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["tag"].template.name
      image  = local.containers["tag"].template.image
      cpu    = local.containers["tag"].template.cpu
      memory = local.containers["tag"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}

// User
resource "azurerm_container_app" "user" {
  name                         = "api-${local.containers["user"].name}-container"
  resource_group_name          = data.azurerm_resource_group.main.name
  container_app_environment_id = local.containers["user"].container_app_environment_id
  revision_mode = "Single"

  ingress {
    external_enabled = true
    target_port      = local.containers["user"].target_port
    transport        = "auto"
    traffic_weight {
      percentage = 100
      revision_suffix = "initial"
    }
  }

  template {
    container {
      name   = local.containers["user"].template.name
      image  = local.containers["user"].template.image
      cpu    = local.containers["user"].template.cpu
      memory = local.containers["user"].template.memory

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
        value = local.administrator_login_password
      }
    }
  }
  tags = var.tags
}