[System.Serializable]
public class RegateoProduct
{
    public string name { get; private set;}
    public string pluralName {get; private set;}
    public int price {get; private set;}
    public int quantity {get; set;}
    public int id {get; private set;}


    public RegateoProduct(string name, string pluralName, int price, int quantity, int id)
    {
        this.pluralName = pluralName;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.id = id;
    }
}
