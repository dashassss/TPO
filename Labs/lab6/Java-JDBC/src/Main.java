import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.List;

public class Main {
    public static void main(String[] args) throws SQLException {
        try (Connection connection = DatabaseConnection.getConnection()) {
            ClockStoreQueries clockStoreQueries = new ClockStoreQueries(connection);

            // Вывести марки заданного типа часов
            List<String> brandsByType = clockStoreQueries.getBrandsByType("Механические");
            System.out.println("Марки механических часов: " + brandsByType);

            // Вывести информацию о механических часах, цена на которые не превышает заданную
            List<String> mechanicalClockInfo = clockStoreQueries.getMechanicalClockInfo(150.0);
            System.out.println("Информация о механических часах: " + mechanicalClockInfo);

            // Вывести марки часов, изготовленных в заданной стране
            List<String> brandsByCountry = clockStoreQueries.getBrandsByCountry("Страна A");
            System.out.println("Марки часов, изготовленных в заданной стране: " + brandsByCountry);

            // Вывести производителей, общая сумма часов которых в магазине не превышает заданную
            List<String> manufacturersByTotalPrice = clockStoreQueries.getManufacturersByTotalPrice(1000.0);
            System.out.println("Производители: " + manufacturersByTotalPrice);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}