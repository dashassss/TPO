public class Gemstone {
    private String name;
    private double caratWeight;
    private double price;
    private double transparency;

    public Gemstone(String name, double caratWeight, double price, double transparency) {
        this.name = name;
        this.caratWeight = caratWeight;
        this.price = price;
        this.transparency = transparency;
    }

    public String getName() {
        return name;
    }

    public double getCaratWeight() {
        return caratWeight;
    }

    public double getPrice() {
        return price;
    }

    public double getTransparency() {
        return transparency;
    }

    @Override
    public String toString() {
        return "Gemstone{" +
                "name='" + name + '\'' +
                ", caratWeight=" + caratWeight +
                ", price=" + price +
                ", transparency=" + transparency +
                '}';
    }
}