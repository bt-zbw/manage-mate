

using System.ComponentModel;

namespace Application.Models {
    public class LightSensor : Sensor {
        public string Status { get; private set; }
        public LightSensor(string name, MqttController controller) : base(name, controller) {
            Action<string,Sensor> updateStatus = (value, sensor) => {
                sensor.GetType().GetProperty("Status").SetValue(sensor, value);
            };
            SubscribeToTopic((Action<string, Sensor>)updateStatus);
        }

        public void TurnOnLight() {
            _ = _Controller.WriteMessage(Name, "On");
        }
        public void TurnOffLight() {
            _ = _Controller.WriteMessage(Name, "Off");
        }
    }
}
