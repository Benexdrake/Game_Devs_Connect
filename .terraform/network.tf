// Create Virtual Network
resource "azurerm_virtual_network" "main" {
    name                = "vnet-${var.application_name}-${var.environment_name}"
    location            = data.azurerm_resource_group.main.location
    resource_group_name = data.azurerm_resource_group.main.name
    address_space       = [var.base_address_space]
}

// Create Subnet
resource "azurerm_subnet" "public" {
    name                  = "snet-public"
    resource_group_name   = data.azurerm_resource_group.main.name
    virtual_network_name  = azurerm_virtual_network.main.name
    address_prefixes      = [local.public_address_space]
}

resource "azurerm_subnet" "private" {
    name                  = "snet-private"
    resource_group_name   = data.azurerm_resource_group.main.name
    virtual_network_name  = azurerm_virtual_network.main.name
    address_prefixes      = [local.private_address_space]
}

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
    destination_port_ranges     = ["22", "80"]
    source_address_prefix       = "*"
    destination_address_prefix  = "*"
  }
}

resource "azurerm_network_security_group" "private_nsg" {
  name                = "ngs-${var.application_name}-${var.environment_name}-private"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  security_rule {
    name                       = "Allow-From-VNet"
    priority                   = 100
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "*"
    source_address_prefix      = "VirtualNetwork"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "Deny-All-Inbound"
    priority                   = 200
    direction                  = "Inbound"
    access                     = "Deny"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "*"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "Allow-All-Outbound"
    priority                   = 100
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "*"
    source_port_range          = "*"
    destination_port_range     = "*"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }
}


// Combine Subnet with NSG
resource "azurerm_subnet_network_security_group_association" "public_nsg_subnet" {
  subnet_id                 = azurerm_subnet.public.id
  network_security_group_id = azurerm_network_security_group.public_nsg.id
}

resource "azurerm_subnet_network_security_group_association" "private_nsg_subnet" {
  subnet_id                 = azurerm_subnet.private.id
  network_security_group_id = azurerm_network_security_group.private_nsg.id
}

// Creates a Public static IP
resource "azurerm_public_ip" "public" {
  name                = "pip-${var.application_name}-${var.environment_name}-alpha"
  resource_group_name = data.azurerm_resource_group.main.name
  location            = data.azurerm_resource_group.main.location
  allocation_method   = "Static"
}

// Creates a Network Interface card for VMs
resource "azurerm_network_interface" "public" {
  name                = "nic-${var.application_name}-${var.environment_name}-alpha"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  ip_configuration {
    name                          = "public"
    subnet_id                     = azurerm_subnet.public.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.public.id
  }   
}

resource "azurerm_network_interface" "private" {
  name                = "nic-${var.application_name}-${var.environment_name}-beta"
  location            = data.azurerm_resource_group.main.location
  resource_group_name = data.azurerm_resource_group.main.name

  ip_configuration {
    name                          = "privat"
    subnet_id                     = azurerm_subnet.private.id
    private_ip_address_allocation = "Static"
    private_ip_address = "10.0.0.20"
  }   
}