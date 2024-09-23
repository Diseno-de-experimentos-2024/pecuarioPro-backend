namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record UpdateToolConditionCommand(int ToolId, int InventoryId, String Condition);