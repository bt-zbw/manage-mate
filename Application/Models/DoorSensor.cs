namespace Application.Models {
    public class DoorSensor : Sensor {
        public string Status { get; private set; }
        public DoorSensor(string name, MqttController controller) : base(name, controller) {
            Action<string, Sensor> updateStatus = (value, Sensor) => {
                Sensor.GetType().GetProperty("Status").SetValue(Sensor, value);
            };
            SubscribeToTopic("/status", (Action<string,Sensor>)updateStatus);
        }
        public void OpenDoor() {
            _ = _Controller.WriteMessage(Name + "/status", "Open");
        }
        public void CloseDoor() {
            _ = _Controller.WriteMessage(Name + "/status", "Close");
        }
    }
}
