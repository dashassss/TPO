public class PreciousStone extends Gemstone {
    private String type;

    public PreciousStone(String name, double caratWeight, double price, double transparency, String type) {
        super(name, caratWeight, price, transparency);
        this.type = type;
    }

    public String getType() {
        return type;
    }

    @Override
    public String toString() {
        return "PreciousStone{" +
                "name='" + getName() + '\'' +
                ", caratWeight=" + getCaratWeight() +
                ", price=" + getPrice() +
                ", transparency=" + getTransparency() +
                ", type='" + type + '\'' +
                '}';
    }
}