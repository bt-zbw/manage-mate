using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Application.Models {
    public abstract class Sensor{
        public  Guid SensorId { get; set; }
        public string Name { get; }
        protected MqttController _Controller;

        public Sensor(string name, MqttController controller) {
            Name = name;
            _Controller = controller;
        }
        public void WriteMessage(string message) {
            _ = _Controller.WriteMessage(Name, message);
        }
        public void SubscribeToTopic(String field, Action<string,Sensor> action) {
            _ = _Controller.SubscribeToTopic(Name + field, action, this);
        }
    }
}
