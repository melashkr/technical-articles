
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;

namespace Demo 
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int count = 3000;
            Console.WriteLine($"Start Simulator demo with {count}");
            await AMQP_Demo(count);
            await MQTT_Demo(count);
            await HTTP_Demo(count);
            Console.WriteLine("End Simulator demo");      

        }

        public static async Task AMQP_Demo(int ParamInstancesCount)
        {
            int InstancesCount = ParamInstancesCount;
            var connectionString = "HostName=PoCProtocolsHub.azure-devices.net;DeviceId=Device-AMQP;SharedAccessKey=RXaqbIbfFIGTfx2WL9rlKQeA0fkpHTBHGpE0kDkl69A=";
            var deviceId = "Device-AMQP";
            IoTHubServices srv = new IoTHubServices(connectionString, deviceId, TransportType.Amqp);
            Console.WriteLine("Start ....");
            for (int i = 0; i < InstancesCount; i++)
            {
                Random rand = new();
                TraktorInfo msg = new TraktorInfo()
                {
                    DemoID = InstancesCount,
                    ID = i + 1,
                    deviceId = deviceId,
                    Protocol = "Amqp",
                    motorTermprature = rand.Next(-10, 60),
                    speed = rand.Next(0, 120),
                    locationX = "48.266518",
                    locationY = "16.396200"
                };
                await srv.SendAsync(msg);

            }


            Console.WriteLine("Finished ....");
        }

        public static async Task MQTT_Demo(int ParamInstancesCount)
        {
            Random rand = new();
            int InstancesCount = ParamInstancesCount;
            var connectionString = "HostName=PoCProtocolsHub.azure-devices.net;DeviceId=Device-MQTT;SharedAccessKey=m7ds6SRGwa/a/QH7zcMrTx+a8i+ic+OVq4JFs3/qYxg=";
            var deviceId = "Device-MQTT";
            IoTHubServices srv = new IoTHubServices(connectionString, deviceId, TransportType.Mqtt);
            Console.WriteLine("Start ....");
            for (int i = 0; i < InstancesCount; i++)
            {
                TraktorInfo msg = new TraktorInfo()
                {
                    DemoID = InstancesCount,
                    ID = i + 1,
                    deviceId = deviceId,
                    Protocol = "MQTT",
                    motorTermprature = rand.Next(-10, 60),
                    speed = rand.Next(0, 120),
                    locationX = "48.266518",
                    locationY = "16.396200"
                };
                await srv.SendAsync(msg);
                
            }


            Console.WriteLine("Finished ....");
        }

        public static async Task HTTP_Demo(int ParamInstancesCount)
        {
            Random rand = new();
            int InstancesCount = ParamInstancesCount;
            var connectionString = "HostName=PoCProtocolsHub.azure-devices.net;DeviceId=Device-Http;SharedAccessKey=CDGHJxZ6s2aT4l6fD5oV1/U4Zz30K0S9BLsdEvBh664=";
            var deviceId = "Device-Http";
            IoTHubServices srv = new IoTHubServices(connectionString, deviceId, TransportType.Http1);
            Console.WriteLine("Start ....");
            for (int i = 0; i < InstancesCount; i++)
            {
                TraktorInfo msg = new TraktorInfo()
                {
                    DemoID = InstancesCount,
                    ID = i + 1,
                    deviceId = deviceId,
                    Protocol = "Http",
                    motorTermprature = rand.Next(-10, 60),
                    speed = rand.Next(0, 120),
                    locationX = "48.266518",
                    locationY = "16.396200"
                };
                await srv.SendAsync(msg);
                
            }


            Console.WriteLine("Finished ....");
        }

    }


    // Interface to provide generic constraints
    public interface IIoTHubMessage { }

    // Message class for temperature values
    public class TraktorInfo : IIoTHubMessage
    {
        public int ID { get; set; }
        public double motorTermprature { get; set; }
        public int speed { get; set; }
        public string locationX { get; set; }
        public string locationY { get; set; }
        public string deviceId { get; internal set; }
        public string Protocol { get; internal set; }
        public int DemoID { get; internal set; }
    }

    // Service class to communicate with the Azure IoT Hub
    public class IoTHubServices
    {
        private DeviceClient _deviceClient;
        private string _deviceId;

        // Creates the service class instance with your IoTHub connection string and your unique device id
        public IoTHubServices(string connectionString, string deviceId, TransportType transportType)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString, transportType);
            _deviceId = deviceId;
        }

        // sends messages to IoT Hub - generic constraint to send only specific message types
        public async Task SendAsync<T>(T message) where T : class, IIoTHubMessage
        {
            string serializedMessage = JsonConvert.SerializeObject(message);
            Message iotHubMessage = new Message(Encoding.UTF8.GetBytes(serializedMessage));
            await _deviceClient.SendEventAsync(iotHubMessage);
        }
    }

}