import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Necklace {
    private List<Gemstone> gemstones = new ArrayList<>();

    public void addGemstone(Gemstone gemstone) {
        gemstones.add(gemstone);
    }

    public double calculateTotalWeight() {
        return gemstones.stream().mapToDouble(Gemstone::getCaratWeight).sum();
    }

    public double calculateTotalPrice() {
        return gemstones.stream().mapToDouble(Gemstone::getPrice).sum();
    }

    public void sortGemstonesByValue() {
        gemstones.sort(Comparator.comparingDouble(Gemstone::getPrice));
    }

    public List<Gemstone> findGemstonesByTransparencyRange(double minTransparency, double maxTransparency) {
        List<Gemstone> result = new ArrayList<>();
        for (Gemstone gemstone : gemstones) {
            if (gemstone.getTransparency() >= minTransparency && gemstone.getTransparency() <= maxTransparency) {
                result.add(gemstone);
            }
        }
        return result;
    }
}