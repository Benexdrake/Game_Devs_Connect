resource "azurerm_linux_virtual_machine" "frontend" {
  depends_on = [ tls_private_key.vm,  local_file.public_key]
  name                  = "frontend"
  resource_group_name   = data.azurerm_resource_group.main.name
  location              = data.azurerm_resource_group.main.location
  size                  = local.vm.size
  admin_username        = local.vm.admin_username
  network_interface_ids = [data.azurerm_network_interface.frontend.id]  

  admin_ssh_key {
    username   = local.vm.admin_ssh.username
    public_key = tls_private_key.vm.public_key_openssh
  }

  os_disk {
    caching              = local.vm.os_disk.caching
    storage_account_type = local.vm.os_disk.storage_account_type
  }

  source_image_reference {
    publisher = local.vm.source_image_reference.publisher
    offer     = local.vm.source_image_reference.offer
    sku       = local.vm.source_image_reference.sku
    version   = local.vm.source_image_reference.version
  }

  user_data = base64encode(templatefile("customdata.tftpl", {
      IMAGE_NAME=local.vm.image
      DOMAIN_NAME="gamedevsconnect.ddns.net"
      BACKEND_URL= data.azurerm_container_app.gateway.latest_revision_fqdn
      NEXTAUTH_SECRET= var.NEXTAUTH_SECRET
      DISCORD_ID= var.DISCORD_ID
      DISCORD_SECRET= var.DISCORD_SECRET
      X_ACCESS_KEY= var.X_ACCESS_KEY
    }))

  tags = var.tags
}

resource "null_resource" "setup_frontend" {
  depends_on = [azurerm_linux_virtual_machine.frontend]

  connection {
    type        = "ssh"
    host        = data.azurerm_public_ip.frontend.ip_address
    user        = local.vm.admin_ssh.username
    private_key = file(var.private_key_path)
  }

  provisioner "remote-exec" {
    inline = [
      "while [ ! -f /var/log/setup_done.log ]; do echo 'Warte auf Setup...'; systemctl status docker | tail -n 2; sleep 10; done",
      "echo 'Setup abgeschlossen.'"
    ]
  }
}