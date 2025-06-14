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

variable "base_address_space" {
  type = string
}

variable "private_key_path" {
  type = string
}

variable "tags" {
  type = map(string)
  default = {
      source = "terraform",
      plattform = "gdc",
      part = "network"
    }
}