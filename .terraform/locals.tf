locals {
  public_address_space   = cidrsubnet(var.base_address_space, 2, 0) //28
  private_address_space   = cidrsubnet(var.base_address_space, 2, 1) //28

  network_interface_ids = {
    "alpha" = {
        network_interface_id = azurerm_network_interface.public.id
    },
    "beta" = {
        network_interface_id = azurerm_network_interface.private.id
    }
  }
}
