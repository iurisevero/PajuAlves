public static class Constants {
    public static readonly string semaphoreTag = "Semaphore";
    public static readonly string carTag = "Car";
    public static readonly string[] carPoolKey = {
        "YellowCar",
        "OrangeCar",
        "BlueTruck",
        "PinkTruck",
        "Ambulance"
    };
    public static readonly string showKey = "Show";
    public static readonly string hideKey = "Hide";
    public static readonly float maxCountDown = 100.0f;

    public static string GetCarPoolKey(CarPoolKey carPoolKeyEnum) {
        return carPoolKey[(int) carPoolKeyEnum];
    }    
}