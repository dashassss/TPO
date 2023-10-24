import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        ParkingLot parkingLot = new ParkingLot(3);

        ExecutorService executorService = Executors.newFixedThreadPool(5);

        for (int i = 1; i <= 5; i++) {
            Car car = new Car("Car " + i, parkingLot);
            executorService.submit(car);
        }

        executorService.shutdown();
    }
}
