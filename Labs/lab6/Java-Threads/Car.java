public class Car implements Runnable {
    private String name;
    private ParkingLot parkingLot;

    public Car(String name, ParkingLot parkingLot) {
        this.name = name;
        this.parkingLot = parkingLot;
    }

    @Override
    public void run() {
        System.out.println(name + " ждет место на стоянке.");
        boolean parked = parkingLot.parkCar();

        if (parked) {
            System.out.println(name + " припарковался на стоянке.");
            try {
                // Автомобиль остается на стоянке некоторое время
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
            System.out.println(name + " уехал с стоянки.");
            parkingLot.leaveCar();
        } else {
            System.out.println(name + " уехал на другую стоянку, так как нет места.");
        }
    }
}