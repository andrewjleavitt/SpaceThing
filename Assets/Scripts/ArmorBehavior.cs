public class ArmorBehavior {

    public string armorName;
    public float durability;

    public ArmorBehavior(string newArmorName, float newDurability) {
        armorName = newArmorName;
        durability = newDurability;
    }

    public string Status() {
        return durability.ToString();
    }
}