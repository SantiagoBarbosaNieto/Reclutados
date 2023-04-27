[System.Serializable]
public class RegateoProduct
{
    public string name;
    public string pluralName;
    public int price;
    public int id;


    public RegateoProduct(string name, string pluralName, int price, int id)
    {
        this.pluralName = pluralName;
        this.name = name;
        this.price = price;
        this.id = id;
    }


}
