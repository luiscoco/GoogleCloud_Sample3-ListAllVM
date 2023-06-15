using Google.Cloud.Compute.V1;

string projectId = "focus-cache-387205";
// Initialize client that will be used to send requests. This client only needs to be created
// once, and can be reused for multiple requests.
InstancesClient client = await InstancesClient.CreateAsync();
IList<Instance> allInstances = new List<Instance>();

// Make the request to list all VM instances in a project.
await foreach (var instancesByZone in client.AggregatedListAsync(projectId))
{
    // The result contains a KeyValuePair collection, where the key is a zone and the value
    // is a collection of instances in that zone.
    Console.WriteLine($"Instances for zone: {instancesByZone.Key}");
    foreach (var instance in instancesByZone.Value.Instances)
    {
        Console.WriteLine($"-- Name: {instance.Name}");
        allInstances.Add(instance);
    }
}
