public static class Constants {
    public static readonly string semaphoreTag = "Semaphore";
    public static readonly string carTag = "Car";
    public static readonly string[] carPoolKey = {"RedCar", "BlueCar", "OrangeCar"};
    public static readonly string showKey = "Show";
    public static readonly string hideKey = "Hide";

    public static string GetCarPoolKey(CarPoolKey carPoolKeyEnum) {
        return carPoolKey[(int) carPoolKeyEnum];
    }    
}