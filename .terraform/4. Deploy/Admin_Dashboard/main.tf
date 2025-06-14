data "azurerm_resource_group" "main" {
  name = var.resource_group_name
}

data "azurerm_network_interface" "public_dashboard" {
  name = "nic-${var.application_name}-${var.environment_name}-public-dashboard"
  resource_group_name = data.azurerm_resource_group.main.name
}

data "azurerm_public_ip" "dashboard" {
  name = "pip-${var.application_name}-${var.environment_name}-dashboard"
  resource_group_name = data.azurerm_resource_group.main.name
}

resource "tls_private_key" "vm" {
  algorithm = "RSA"
  rsa_bits = 4096
}

resource "local_file" "private_key" {
  content = tls_private_key.vm.private_key_pem
  filename = pathexpand(var.private_key_path)
  file_permission = "0600"
}

resource "local_file" "public_key" {
  content = tls_private_key.vm.public_key_openssh
  filename = pathexpand("${var.private_key_path}.pub")
}