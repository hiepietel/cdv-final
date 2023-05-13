module "resource_group" {
    source = "./modules/resource_group"

  application = var.application
  environment = "all"
  owner       = var.owner
  location    = var.location
  prefix      = var.prefix
}

module "postgres_server" {
  source = "./modules/postgres_db"

  resource_group_name = module.resource_group.resource_group_name
  location            = var.location

  environment = var.environment
  application = var.application
  owner       = var.owner
  prefix      = var.prefix
}

module "web_app_api" {
  source = "./modules/web_app_api"

  prefix      = var.prefix
  application = var.application
  environment = var.environment
  owner       = var.owner

  resource_group_name = module.resource_group.resource_group_name
  location            = var.location

  postgres_user     = module.postgres_server.postgres_user
  postgres_password = module.postgres_server.postgres_password
  postgres_host     = module.postgres_server.postgres_host
}

module "web_app_front" {
  source = "./modules/web_app_front"

  prefix      = var.prefix
  application = var.application
  environment = var.environment
  owner       = var.owner

  resource_group_name = module.resource_group.resource_group_name
  location            = var.location

  api_url = module.web_app_api.api_url
}