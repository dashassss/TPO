import java.util.concurrent.Semaphore;

public class ParkingLot {
    private Semaphore parkingSpaces;

    public ParkingLot(int numberOfSpaces) {
        parkingSpaces = new Semaphore(numberOfSpaces, true);
    }

    public boolean parkCar() {
        return parkingSpaces.tryAcquire();
    }

    public void leaveCar() {
        parkingSpaces.release();
    }
}