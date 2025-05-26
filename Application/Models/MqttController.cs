using MQTTnet;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models {
    public class MqttController {
        public Guid Id { get; set; }
        public string IP {  get; }
        private readonly MqttClientFactory _factory;
        private readonly IMqttClient _client;
        private readonly MqttClientOptions _options;
        private List<Sensor> _sensors = new List<Sensor>();
        public static MqttController Controller { get; private set; }
        private MqttController(string IP) {
            IP = "192.168.10.20";
            this.IP = IP;
            //Connecting to MQTT Broker
            _factory = new MqttClientFactory();
            _client = _factory.CreateMqttClient();
            _options = new MqttClientOptionsBuilder().WithTcpServer(IP).Build();
            _client.ConnectAsync(_options, CancellationToken.None).Wait();
        }
        public static void IninalizeMqttController(string IP) {
            if (Controller == null) {
                Controller = new MqttController(IP);
            };
        }
        public async Task WriteMessage(string topic, string payload) {

            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await _client.PublishAsync(applicationMessage, CancellationToken.None);
        }

        public async Task SubscribeToTopic (string topic, Action<string,Sensor> action, Sensor sensor) {
            _client.ApplicationMessageReceivedAsync += e => {
                Console.WriteLine(EncodingExtensions.GetString(Encoding.UTF8, e.ApplicationMessage.Payload));
                action(EncodingExtensions.GetString(Encoding.UTF8, e.ApplicationMessage.Payload), sensor);
                return Task.CompletedTask;
            };

            var mqttSubscribeOptions = _factory.CreateSubscribeOptionsBuilder().WithTopicFilter(topic).Build();
            await _client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }

        public LightSensor AddLightSensor(string topic) {
            var sensor = new LightSensor(topic, this);
            _sensors.Add(sensor);
            return sensor;
        }
        public List<LightSensor> GetLights() {
            List<LightSensor> lightSensors = new List<LightSensor>();
            foreach (var sensor in _sensors) {
                if (sensor.GetType() == typeof(LightSensor)) {
                    lightSensors.Add(sensor as LightSensor);
                }
            }
            return lightSensors;
        }
    }
}
