resource "azurerm_service_plan" "asp" {
  name                = "${var.prefix}-${var.application}-${var.environment}-asp"
  resource_group_name = var.resource_group_name
  location            = var.location
  os_type             = "Linux"
  sku_name            = "B3"

  tags = {
    application = var.application
    environment = var.environment
    owner       = var.owner
  }
}

resource "azurerm_linux_web_app" "webapp" {
  name                = "${var.prefix}-${var.application}-${var.environment}-front"
  resource_group_name = var.resource_group_name
  location            = var.location
  service_plan_id     = azurerm_service_plan.asp.id

  site_config {
    application_stack {
      node_version = "18-lts"
    }
  }


  app_settings = {
    REACT_APP_API_URL = "https://${var.prefix}-${var.application }-${var.environment}-api.azurewebsites.net"
  }

  tags = {
    application = var.application
    environment = var.environment
    owner       = var.owner
  }
}