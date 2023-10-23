import java.util.List;

public class MAin {
    public static void main(String[] args) {
        Necklace necklace = new Necklace();

        PreciousStone diamond = new PreciousStone("Diamond", 2.5, 5000, 0.9, "Diamond");
        SemiPreciousStone amethyst = new SemiPreciousStone("Amethyst", 1.8, 200, 0.8, "Amethyst");

        necklace.addGemstone(diamond);
        necklace.addGemstone(amethyst);

        double totalWeight = necklace.calculateTotalWeight();
        double totalPrice = necklace.calculateTotalPrice();

        System.out.println("Общий вес ожерелья: " + totalWeight + " карат");
        System.out.println("Общая стоимость ожерелья: $" + totalPrice);

        necklace.sortGemstonesByValue();

        List<Gemstone> gemstonesInRange = necklace.findGemstonesByTransparencyRange(0.7, 0.9);
        for (Gemstone gemstone : gemstonesInRange) {
            System.out.println("Найден камень: " + gemstone.getName());
        }
    }
}
