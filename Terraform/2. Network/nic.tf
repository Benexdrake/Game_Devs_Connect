// Creates a Network Interface card for VMs
resource "azurerm_network_interface" "public" {
  name                = "nic-${var.application_name}-${var.environment_name}-frontend"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  ip_configuration {
    name                          = "frontend"
    subnet_id                     = azurerm_subnet.public.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.frontend.id
  }
  tags = var.tags   
}