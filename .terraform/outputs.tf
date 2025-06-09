output "vm_private_ips" {
  value = {
    for vm_name, nic in azurerm_linux_virtual_machine.vms :
    vm_name => nic.private_ip_address
  }
}

output "vm_public_ips" {
  value = {
    for vm_name, nic in azurerm_linux_virtual_machine.vms :
    vm_name => "http://${nic.public_ip_address}"
  }
}