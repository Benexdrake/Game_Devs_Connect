terraform init -reconfigure -backend-config="../.Config/env/dev/backend_config.tfvars"
mkdir ../.ssh
terraform $* -var-file "../.Config/env/dev/backend_config.tfvars" -var-file "../.Config/env/dev/config.tfvars" -lock=false