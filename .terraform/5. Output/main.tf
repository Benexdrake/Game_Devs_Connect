data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_public_ip" "dashboard" {
  name                  = "pip-${var.application_name}-${var.environment_name}-dashboard"
  resource_group_name   = data.azurerm_resource_group.main.name
}

data "azurerm_mssql_server" "sql" {
  name                = "${var.application_name}-sqlserver"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_container_app" "gateway" {
  name                = "api-gateway-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "frontend" {
  name                = "frontend-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "azure" {
  name                = "api-azure-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "comment" {
  name                = "api-comment-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "file" {
  name                = "api-file-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "notification" {
  name                = "api-notification-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "profile" {
  name                = "api-profile-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "project" {
  name                = "api-project-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "request" {
  name                = "api-request-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "tag" {
  name                = "api-tag-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}

data "azurerm_container_app" "user" {
  name                = "api-user-container"
  resource_group_name = data.azurerm_resource_group.main.name 
}