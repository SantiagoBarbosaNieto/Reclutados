[System.Serializable]
public class TransitionItem
{
    public int day;
    public int id;
    public string description;
    public float money;

    public TransitionItem(int day, int id, string description, float money) {
        this.day = day;
        this.id = id;
        this.description = description;
        this.money = money;
    }

}
