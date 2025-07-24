// Create Network Security Group
resource "azurerm_network_security_group" "public_nsg" {
  name                = "ngs-${var.application_name}-${var.environment_name}-public"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  security_rule {
    name                        = "remote"
    priority                    = 100
    direction                   = "Inbound"
    access                      = "Allow"
    protocol                    = "Tcp"
    source_port_range           = "*"
    destination_port_ranges     = ["22", "80", "443"]
    source_address_prefix       = "*"
    destination_address_prefix  = "*"
  }

  security_rule {
    name                       = "AllowOutboundAll"
    priority                   = 100
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "*"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }
  tags = var.tags
}


resource "azurerm_network_security_group" "private_sql_nsg" {
  name                = "ngs-${var.application_name}-${var.environment_name}-sql"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  security_rule {
    name                       = "Allow-PrivateEndpoint"
    priority                   = 110
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "*"
    source_address_prefix      = "10.0.0.0/24"
    destination_address_prefix = "*"
  }
  tags = var.tags
}


// Combine Subnet with NSG
resource "azurerm_subnet_network_security_group_association" "public_nsg_subnet" {
  subnet_id                 = azurerm_subnet.public.id
  network_security_group_id = azurerm_network_security_group.public_nsg.id
}

resource "azurerm_subnet_network_security_group_association" "public_container_nsg_subnet" {
  subnet_id                 = azurerm_subnet.public_container.id
  network_security_group_id = azurerm_network_security_group.public_nsg.id
}

resource "azurerm_subnet_network_security_group_association" "sql_nsg_subnet" {
  subnet_id                 = azurerm_subnet.private_sql_subnet.id
  network_security_group_id = azurerm_network_security_group.private_sql_nsg.id
}