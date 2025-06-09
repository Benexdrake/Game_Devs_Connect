application_name        = "gamedevsconnect"
storage_account_name    = "stterraformlearning"
container_name          = "tfstate"
key                     = "terraform.tfstate"
environment_name    = "dev"
base_address_space  = "10.0.0.0/24"
private_key_path    = "./.ssh/vm"

vm_config = {
    size = "Standard_A1_v2"
    os_disk = {
      caching = "ReadWrite"
      storage_account_type = "Standard_LRS"
    }
    source_image_reference = {
      publisher = "Canonical"
      offer     = "0001-com-ubuntu-server-jammy"
      sku       = "22_04-lts"
      version   = "latest"
    }
}

vms = {
  "alpha" = {
    name = "alpha"
    image = {
      name = "nginx"
      version = "1.0"
      port = {
        from = "80"
        to = "80"
      }
    }
    admin_username = "ubuntu"
    admin_ssh = {
      username = "ubuntu"
    }
  },
  "beta" = {
    name = "beta"
    image = {
      name = "nginx"
      version = "2.0"
      port = {
        from = "80"
        to = "80"
      }
    }
    admin_username = "ubuntu"
    admin_ssh = {
      username = "ubuntu"
    }
  }
}