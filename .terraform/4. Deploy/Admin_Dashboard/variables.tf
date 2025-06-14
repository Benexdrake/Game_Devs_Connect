variable "application_name" {
  type = string
}

variable "environment_name" {
  type = string
}

variable "resource_group_name" {
  type = string
}

variable "subscription_id" {
  type = string
}

variable "storage_account_name" {
  type = string
}

variable "container_name" {
  type = string
}

variable "subnets" {
  type = map(string)
}

variable "private_key_path" {
  type = string
}

variable "tags" {
  type = map(string)
  default = {
      source = "terraform",
      plattform = "gdc",
      part = "dashboard"
    }
}

variable "dashboard" {
  type = object({
    name = string
    interface = string
    image = object({
      link = string
      port = object({
        from = string
        to = string
      })
    })
    admin_username = string
    admin_ssh = object({
      username = string
    })
    size = string
    os_disk = object({
      caching = string
      storage_account_type = string
    })
    source_image_reference = object({
      publisher = string
      offer = string
      sku = string
      version = string
    })
  })
}