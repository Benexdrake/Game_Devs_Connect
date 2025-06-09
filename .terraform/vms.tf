resource "azurerm_linux_virtual_machine" "vms" {
    for_each = var.vms
  name                = "vm-${var.vms[each.key].name}" // with ping vm-alpha or beta u can access without knowing ip, great for a Gateway
  resource_group_name = data.azurerm_resource_group.main.name
  location            = data.azurerm_resource_group.main.location
  size                = var.vm_config.size
  admin_username      = var.vms[each.key].admin_username
  network_interface_ids = [local.network_interface_ids[each.key].network_interface_id]
  

  admin_ssh_key {
    username   = var.vms[each.key].admin_ssh.username
    public_key = tls_private_key.vm.public_key_openssh
  }

  os_disk {
    caching              = var.vm_config.os_disk.caching
    storage_account_type = var.vm_config.os_disk.storage_account_type
  }

  source_image_reference {
    publisher = var.vm_config.source_image_reference.publisher
    offer     = var.vm_config.source_image_reference.offer
    sku       = var.vm_config.source_image_reference.sku
    version   = var.vm_config.source_image_reference.version
  }

  user_data = base64encode(templatefile("customdata.tftpl", {
      image_name=var.vms[each.key].image.name,
      image_version=var.vms[each.key].image.version,
      port_from=var.vms[each.key].image.port.from,
      port_to=var.vms[each.key].image.port.to,
      acr_name=var.application_name
    }))
}

resource "null_resource" "setup_alpha" {
  depends_on = [azurerm_linux_virtual_machine.vms, local_file.private_key]

  connection {
    type        = "ssh"
    host        = azurerm_public_ip.public.ip_address
    user        = var.vms["alpha"].admin_ssh.username
    private_key = file(var.private_key_path)
  }

  provisioner "remote-exec" {
    inline = [
      "while [ ! -f /var/log/setup_done.log ]; do echo 'Warte auf Setup...'; systemctl status docker | tail -n 2; sleep 10; done",
      "echo 'Setup abgeschlossen.'"
    ]
  }
}