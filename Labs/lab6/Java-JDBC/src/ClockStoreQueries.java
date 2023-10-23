import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ClockStoreQueries {
    private Connection connection;

    public ClockStoreQueries(Connection connection) {
        this.connection = connection;
    }

    // Вывести марки заданного типа часов.
    public List<String> getBrandsByType(String clockType) {
        List<String> brands = new ArrayList<>();
        String query = "SELECT DISTINCT brand FROM clocks WHERE type = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(query)) {
            preparedStatement.setString(1, clockType);
            ResultSet resultSet = preparedStatement.executeQuery();
            while (resultSet.next()) {
                brands.add(resultSet.getString("brand"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return brands;
    }

    // Вывести информацию о механических часах, цена на которые не превышает заданную.
    public List<String> getMechanicalClockInfo(double maxPrice) {
        List<String> info = new ArrayList<>();
        String query = "SELECT brand, price FROM Clocks WHERE type = 'Механические' AND price <= ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(query)) {
            preparedStatement.setDouble(1, maxPrice);
            ResultSet resultSet = preparedStatement.executeQuery();
            while (resultSet.next()) {
                String brand = resultSet.getString("brand");
                double price = resultSet.getDouble("price");
                info.add("Марка: " + brand + ", Цена: " + price);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return info;
    }

    // Вывести марки часов, изготовленных в заданной стране.
    public List<String> getBrandsByCountry(String country) {
        List<String> brands = new ArrayList<>();
        String query = "SELECT C.brand " +
                "FROM Clocks C " +
                "JOIN Manufacturers M ON C.manufacturer_id = M.manufacturer_id " +
                "WHERE M.country = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(query)) {
            preparedStatement.setString(1, country);
            ResultSet resultSet = preparedStatement.executeQuery();
            while (resultSet.next()) {
                brands.add(resultSet.getString("brand"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return brands;
    }

    // Вывести производителей, общая сумма часов которых в магазине не превышает заданную.
    public List<String> getManufacturersByTotalPrice(double maxTotalPrice) {
        List<String> manufacturers = new ArrayList<>();
        String query = "SELECT M.name, SUM(C.price * C.quantity) AS total_price " +
                "FROM Manufacturers M " +
                "JOIN Clocks C ON M.manufacturer_id = C.manufacturer_id " +
                "GROUP BY M.name " +
                "HAVING total_price <= ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(query)) {
            preparedStatement.setDouble(1, maxTotalPrice);
            ResultSet resultSet = preparedStatement.executeQuery();
            while (resultSet.next()) {
                String manufacturerName = resultSet.getString("name");
                double totalPrice = resultSet.getDouble("total_price");
                manufacturers.add("Производитель: " + manufacturerName + ", Общая сумма: " + totalPrice);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return manufacturers;
    }
}
