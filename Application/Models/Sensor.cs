namespace Application.Models {
    public abstract class Sensor {
        public Guid SensorId { get; set; }
        public string Name { get; }
        private readonly MqttController _Controller;
        public Sensor(string name, MqttController controller) {
            Name = name;
            _Controller = controller;
        }
        public void WriteMessage(string message) {
            _ = _Controller.WriteMessage(Name, message);
        }
    }
}
