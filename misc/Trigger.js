// Trigger that runs every time a new item is added to the container
function itemAddedTrigger() {
    var context = getContext();
    var request = context.getRequest();
    var response = context.getResponse();

    // Check if the operation is an insert
    // Not really necessary, as you can define this in the portal on creation
    // Just to show in code also
    if (request.getOperationType() === "Create") {
        // Print "item added" to the console
        console.log("item added");
    }

    // Return success status
    response.setBody("Trigger executed successfully.");
}
