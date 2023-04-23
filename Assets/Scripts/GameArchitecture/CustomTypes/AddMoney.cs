[System.Serializable]
public class AddMoney
{
    public string description;
    public float money;

    public bool isVentas;

    public AddMoney( float money, string description = "", bool isVentas = false) {
        this.description = description;
        this.money = money;
        this.isVentas = isVentas;
    }

}
