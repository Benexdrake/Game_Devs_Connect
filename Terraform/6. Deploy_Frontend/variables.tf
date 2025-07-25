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

variable "X_ACCESS_KEY" {
  type = string
}

variable "DISCORD_ID" {
  type = string
}

variable "DISCORD_SECRET" {
  type = string
}

variable "NEXTAUTH_SECRET" {
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