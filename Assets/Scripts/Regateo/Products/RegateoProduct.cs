[System.Serializable]
public class RegateoProduct
{
    public string name {get; private set;}
    public int price {get; private set;}

    public int id {get; private set;}

    public RegateoProduct(string name, int price, int id)
    {
        this.name = name;
        this.price = price;
        this.id = id;
    }
}
