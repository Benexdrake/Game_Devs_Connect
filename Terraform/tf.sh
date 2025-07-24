terraform init

terraform $* -var-file "./.Config/env/dev/backend_config.tfvars" -var-file "./.Config/env/dev/config.tfvars"