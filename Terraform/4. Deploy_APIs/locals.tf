locals {
  containers = {
    "azure" = {
        name = "azure",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiazure",
            image = "benexdrake012/gamedevsconnect_backend_api_azure",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "file" = {
        name = "file",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apifile",
            image = "benexdrake012/gamedevsconnect_backend_api_file",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "notification" = {
        name = "notification",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apinotification",
            image = "benexdrake012/gamedevsconnect_backend_api_notification",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "profile" = {
        name = "profile",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiprofile",
            image = "benexdrake012/gamedevsconnect_backend_api_profile",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "project" = {
        name = "project",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiproject",
            image = "benexdrake012/gamedevsconnect_backend_api_project",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "post" = {
        name = "post",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apipost",
            image = "benexdrake012/gamedevsconnect_backend_api_post",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "quest" = {
        name = "quest",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiquest",
            image = "benexdrake012/gamedevsconnect_backend_api_quest",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "tag" = {
        name = "tag",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apitag",
            image = "benexdrake012/gamedevsconnect_backend_api_tag",
            cpu = 1,
            memory = "2.0Gi"
        }
    },
    "user" = {
        name = "user",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiuser",
            image = "benexdrake012/gamedevsconnect_backend_api_user",
            cpu = 1,
            memory = "2.0Gi"
        }
    }
  }
    
    administrator_login_password = data.terraform_remote_state.db.outputs.mssql_admin_password
}