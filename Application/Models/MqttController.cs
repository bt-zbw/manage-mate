using MQTTnet;

namespace Application.Models {
    public class MqttController {
        public Guid Id { get; set; }
        public string IP {  get; }
        private readonly IMqttClient _client;
        private readonly MqttClientOptions _options;
        public MqttController(string IP) {
            IP = "192.168.10.20";
            this.IP = IP;
            //Connecting to MQTT Broker
            var mqttFactory = new MqttClientFactory();
            _client = mqttFactory.CreateMqttClient();
            _options = new MqttClientOptionsBuilder().WithTcpServer(IP).Build();
        }
        public async Task WriteMessage(string topic, string payload) {

            await _client.ConnectAsync(_options, CancellationToken.None);

            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await _client.PublishAsync(applicationMessage, CancellationToken.None);
        }
    }
}
