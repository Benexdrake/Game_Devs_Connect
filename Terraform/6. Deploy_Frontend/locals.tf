locals {
  vm = {
    name      = "frontend",
    interface = "frontend",
    image = "benexdrake012/gamedevsconnect_frontend:latest",
    admin_username = "ubuntu",
    admin_ssh = {
      username = "ubuntu"
    }
    size = "Standard_A2_v2"
    os_disk = {
      caching               = "ReadWrite"
      storage_account_type  = "Standard_LRS"
    }
    source_image_reference = {
      publisher = "Canonical"
      offer     = "0001-com-ubuntu-server-jammy"
      sku       = "22_04-lts"
      version   = "latest"
    }
}
}