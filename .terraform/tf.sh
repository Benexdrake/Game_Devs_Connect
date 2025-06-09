terraform init -reconfigure -backend-config=secrets.tfvars

echo "" > ./.ssh/vm

terraform $* -var-file "./secrets.tfvars" -lock=false