locals {
  containers = {
    "azure" = {
        name = "azure",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiazure",
            image = "benexdrake012/gamedevsconnect_backend_api_azure",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "comment" = {
        name = "comment",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apicomment",
            image = "benexdrake012/gamedevsconnect_backend_api_comment",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "file" = {
        name = "file",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apifile",
            image = "benexdrake012/gamedevsconnect_backend_api_file",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "notification" = {
        name = "notification",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apinotification",
            image = "benexdrake012/gamedevsconnect_backend_api_notification",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "profile" = {
        name = "profile",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiprofile",
            image = "benexdrake012/gamedevsconnect_backend_api_profile",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "project" = {
        name = "project",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiproject",
            image = "benexdrake012/gamedevsconnect_backend_api_project",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "request" = {
        name = "request",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apirequest",
            image = "benexdrake012/gamedevsconnect_backend_api_request",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "tag" = {
        name = "tag",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apitag",
            image = "benexdrake012/gamedevsconnect_backend_api_tag",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    },
    "user" = {
        name = "user",
        container_app_environment_id = data.azurerm_container_app_environment.public.id,
        target_port = 8080,
        template = {
            name = "apiuser",
            image = "benexdrake012/gamedevsconnect_backend_api_user",
            cpu = 0.5,
            memory = "1.0Gi"
        }
    }
  }
    access_key = random_password.access_key.result
    administrator_login_password = data.terraform_remote_state.db.outputs.mssql_admin_password
}