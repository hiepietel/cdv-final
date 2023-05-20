module "resource_group" {
  source = "./modules/resource_group"

  application = var.application
  environment = var.environment
  owner       = var.owner
  location    = var.location
  prefix      = var.prefix
}

module "azurerm_mssql_server" {
  source = "./modules/mssqlserver_db"

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

  sql_user     = module.azurerm_mssql_server.sql_user
  sql_password = module.azurerm_mssql_server.sql_password
  sql_host     = module.azurerm_mssql_server.sql_host
}


module "storage_front" {
  source = "./modules/storage_account"

  application         = var.application
  environment         = var.environment
  owner               = var.owner
  location            = var.location
  resource_group_name = module.resource_group.resource_group_name
}