output "sql_host" {
  value = azurerm_mssql_server.sql_server.name
}

output "sql_user" {
  value = azurerm_mssql_server.sql_server.administrator_login
}

output "sql_password" {
  value = azurerm_mssql_server.sql_server.administrator_login_password
}