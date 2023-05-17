 resource "azurerm_mssql_server" "sql_server" {
  name                = "${var.prefix}-${var.application}-${var.environment}-mssql-dev-1"
  resource_group_name = var.resource_group_name
  location            = var.location

  #sku_name = "B_Gen5_1"
  version  = "12.0"

  administrator_login          = "mssqluser"
  administrator_login_password = "Q1w2e3r4t5y6."

  #backup_retention_days        = 7
  #geo_redundant_backup_enabled = false
  #storage_mb                   = 5120
  #auto_grow_enabled            = true


  #ssl_enforcement_enabled          = false
  #ssl_minimal_tls_version_enforced = "TLSEnforcementDisabled"

  tags = {
    environment = var.environment
    application = var.application
    owner       = var.owner
  }
}

resource "azurerm_mssql_firewall_rule" "example" {
  name             = "${var.prefix}-${var.application}-${var.environment}-mssql-fw"
  server_id        = azurerm_mssql_server.sql_server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

# resource "azurerm_postgresql_firewall_rule" "psql_firewall_rule" {
#   name                = "${var.prefix}-${var.application}-${var.environment}-psql-fw"
#   resource_group_name = var.resource_group_name
#   server_name         = azurerm_postgresql_server.psql_server.name
#   start_ip_address    = "0.0.0.0"
#   end_ip_address      = "0.0.0.0"
# }


# The Azure SQL Database used in tests
resource "azurerm_mssql_database" "db" {
  name      = "testdb"
  server_id = azurerm_mssql_server.sql_server.id
  sku_name  = "P1"
}

# resource "time_sleep" "wait_15_seconds" {
#   depends_on = [azurerm_mssql_database.db]

#   create_duration = "15s"
# }
