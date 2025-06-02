

using System.ComponentModel;

namespace Application.Models {
    public class TemperatureSensor : Sensor {
        public string Temperature { get; private set; }
        public string Humidity { get; private set; }
        public TemperatureSensor(string name, MqttController controller) : base(name, controller) {
            Action<string,Sensor> updateTemperature = (value, sensor) => {
                sensor.GetType().GetProperty("Temperature").SetValue(sensor, value);
            };
            SubscribeToTopic("/temperature", (Action<string, Sensor>)updateTemperature);
            Action<string, Sensor> updateHumidity = (value, sensor) => {
                sensor.GetType().GetProperty("Humidity").SetValue(sensor, value);
            };
            SubscribeToTopic("/humidity", (Action<string, Sensor>)updateHumidity);
        }
    }
}
