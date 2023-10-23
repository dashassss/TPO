import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        ParkingLot parkingLot = new ParkingLot(3); // Здесь 3 - количество мест на стоянке

        ExecutorService executorService = Executors.newFixedThreadPool(5); // 5 потоков для 5 автомобилей

        for (int i = 1; i <= 5; i++) {
            Car car = new Car("Car " + i, parkingLot);
            executorService.submit(car);
        }

        executorService.shutdown();
    }
}
