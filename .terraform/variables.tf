variable "application_name" {
  type = string
}

variable "environment_name" {
  type = string
}

variable "resource_group_name" {
  type = string
}

variable "storage_account_name" {
  type = string
}

variable "container_name" {
  type = string
}

variable "key" {
  type = string
}

variable "subscription_id" {
  type = string
}

variable "base_address_space" {
  type = string
}

variable "private_key_path" {
  type = string
}

variable "vm_config" {
  type = object({
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

variable "vms" {
  type = map( object({
    name = string
    image = object({
      name = string
      version = string
      port = object({
        from = string
        to = string
      })
    })
    admin_username = string
    admin_ssh = object({
      username = string
    })
  })
  )
}