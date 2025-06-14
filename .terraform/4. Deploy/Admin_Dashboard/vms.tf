resource "azurerm_linux_virtual_machine" "admin_dashboard" {
  depends_on = [ tls_private_key.vm,  local_file.public_key]
  name                  = "vm-admin-dashboard"
  resource_group_name   = data.azurerm_resource_group.main.name
  location              = data.azurerm_resource_group.main.location
  size                  = var.dashboard.size
  admin_username        = var.dashboard.admin_username
  network_interface_ids = [data.azurerm_network_interface.public_dashboard.id]  

  admin_ssh_key {
    username   = var.dashboard.admin_ssh.username
    public_key = tls_private_key.vm.public_key_openssh
  }

  os_disk {
    caching              = var.dashboard.os_disk.caching
    storage_account_type = var.dashboard.os_disk.storage_account_type
  }

  source_image_reference {
    publisher = var.dashboard.source_image_reference.publisher
    offer     = var.dashboard.source_image_reference.offer
    sku       = var.dashboard.source_image_reference.sku
    version   = var.dashboard.source_image_reference.version
  }

  # user_data = base64encode(templatefile("customdata.tftpl", {
  #     image=var.dashboard.image.link
  #     port_from=var.dashboard.image.port.from,
  #     port_to=var.dashboard.image.port.to
  #   }))

  tags = var.tags
}

# resource "null_resource" "setup_dashboard" {
#   depends_on = [azurerm_linux_virtual_machine.admin_dashboard]

#   connection {
#     type        = "ssh"
#     host        = data.azurerm_public_ip.dashboard.ip_address
#     user        = var.dashboard.admin_ssh.username
#     private_key = file(var.private_key_path)
#   }

#   provisioner "remote-exec" {
#     inline = [
#       "while [ ! -f /var/log/setup_done.log ]; do echo 'Warte auf Setup...'; systemctl status docker | tail -n 2; sleep 10; done",
#       "echo 'Setup abgeschlossen.'"
#     ]
#   }
# }