public class SemiPreciousStone extends Gemstone {
    private String variety;

    public SemiPreciousStone(String name, double caratWeight, double price, double transparency, String variety) {
        super(name, caratWeight, price, transparency);
        this.variety = variety;
    }

    public String getVariety() {
        return variety;
    }

    @Override
    public String toString() {
        return "SemiPreciousStone{" +
                "name='" + getName() + '\'' +
                ", caratWeight=" + getCaratWeight() +
                ", price=" + getPrice() +
                ", transparency=" + getTransparency() +
                ", variety='" + variety + '\'' +
                '}';
    }
}