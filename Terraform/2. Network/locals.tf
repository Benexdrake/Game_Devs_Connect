locals {
  public_address_space            = cidrsubnet(var.base_address_space, 3, 0)
  public_container_address_space  = cidrsubnet(var.base_address_space, 3, 1)
  sql_private_space               = cidrsubnet(var.base_address_space, 3, 2)
  gateway_address_space           = cidrsubnet(var.base_address_space, 3, 4)
}
