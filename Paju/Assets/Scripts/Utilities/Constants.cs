public static class Constants {
    public static readonly string semaphoreTag = "Semaphore";
    public static readonly string carTag = "Car";
    public static readonly string[] carPoolKey = {"RedCar", "BlueCar", "OrangeCar"};

    public static string GetCarPoolKey(CarPoolKey carPoolKeyEnum) {
        return carPoolKey[(int) carPoolKeyEnum];
    }    
}