// For demo -> DB "Zoo", container "Animals", partitionKey "/region"
function createAnimal(animalName, animalRegion) {
    var context = getContext();
    var container = context.getCollection();
    var response = context.getResponse();

    // Generate a random id
    var id = Math.floor(Math.random() * 1000).toString();

    // Create a new item for the animal to insert into container
    var newItem = {
        id: id,
        name: animalName
    };

    // Insert the item into the container, specifying the partition key value
    container.createDocument(container.getSelfLink(), newItem, { partitionKey: animalRegion }, function (error, itemCreated) {
        if (error) {
            throw new Error("Error creating the item: " + error.message);
        }

        response.setBody(itemCreated);
    });
}
