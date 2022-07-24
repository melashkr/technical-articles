#r "Microsoft.Azure.EventHubs"
#r "Microsoft.Azure.WebJobs.Extensions.Storage"
#r "Microsoft.Azure.Cosmos.Table"
#r "System.Text.Json"

// #r "Microsoft.Azure"
// #r "Microsoft.Azure.Data.Tables"
using Microsoft.Azure.EventHubs;
using System;
using System.Text;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.Cosmos.Table;
using System.Text.Json;
using System.Globalization;
// using Microsoft.Azure;
// using Microsoft.Azure.Data.Tables;

public static async Task Run(EventData[] events, ICollector<IoTRequest> iotOutputTable ,ILogger log)
{   
    var exceptions = new List<Exception>(); 
    // log.LogInformation($"IotTable : {iotOutputTable}");
    // log.LogInformation($"IoTTable-Type: {iotOutputTable.GetType()}");
    foreach (EventData eventData in events)
    {
        try
        {
            string messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
             var PartitionKey = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
             var RowKey = Guid.NewGuid().ToString();
             var timeStamp =  DateTime.UtcNow;//.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            // Replace these two lines with your processing logic.
            // log.LogInformation($"EnqueuedTime : {eventData.EnqueuedTime }"); 
            //log.LogInformation($"offset: {eventData.Offset}");
            log.LogInformation($"C# Event Hub trigger function processed a message: {messageBody}");
            var iotItem = System.Text.Json.JsonSerializer.Deserialize<IoTRequest>(messageBody);
            //log.LogInformation($"IoT Item Speed: {iotItem.deviceId}");
            iotOutputTable.Add(new IoTRequest{
                PartitionKey = PartitionKey, 
                RowKey = RowKey,
                ID = iotItem.ID,
                motorTermprature = iotItem.motorTermprature,
                speed = iotItem.speed,
                locationX = iotItem.locationX,
                locationY = iotItem.locationY,
                deviceId = iotItem.deviceId,
                Protocol = iotItem.Protocol,
                DemoID = iotItem.DemoID,
                timeStampNew = timeStamp
            });

            await Task.Yield();
        }
        catch (Exception e)
        {
            // We need to keep processing the rest of the batch - capture this exception and continue.
            // Also, consider capturing details of the message that failed processing so it can be processed again later.
            exceptions.Add(e);
        }
    }

    // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

    if (exceptions.Count > 1)
        throw new AggregateException(exceptions);

    if (exceptions.Count == 1)
        throw exceptions.Single();
}

 
public class IoTRequest : TableEntity
{
    protected string  PartitionKey { get; set; }
    protected string RowKey { get; set; }
    public int ID { get; set; }
    public double motorTermprature { get; set; }
    public int   speed { get; set; }
    public string locationX { get; set; }
    public string locationY { get; set; }
    public string deviceId  { get; set; }
    public string Protocol { get; set; }
    public int DemoID {get; set;}
    public DateTime timeStampNew {get; set;}
}

