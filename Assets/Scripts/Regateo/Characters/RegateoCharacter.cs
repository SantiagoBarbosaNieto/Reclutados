using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RegateoCharacter {

    public RegateoCharacterSO regateoCharacterSO {get; private set;}

    public List<RegateoOrder> orders {get; private set;}

    private RegateoCharacter(){}

    public RegateoCharacter(RegateoCharacterSO regateoCharacterSO, List<RegateoOrder> orders)
    {
        this.regateoCharacterSO = regateoCharacterSO;
        this.orders = orders;
    }

    public float GetTolerance() {
        return regateoCharacterSO.tolerancia;
    }

    public string GetName() {
        return regateoCharacterSO.GetName();
    }

    public Sprite GetImage() {
        return regateoCharacterSO.GetSprite();
    }

    public void RemoveOrder(RegateoOrder order) {
        orders.Remove(order);
    }

    public bool OrdersAvailable() {
        return orders.Count > 0;
    }

    public int OrdersCount() {
        return orders.Count;
    }

    public string GenerateSaludo()
    {
        return regateoCharacterSO.GenerateSaludo();
    }

    public string GeneratePedido(RegateoOrder order)
    {
        return regateoCharacterSO.GeneratePedido(order.amount, order.product.name, order.product.pluralName);
    }


    public string GenerateDespedida()
    {
        return regateoCharacterSO.GenerateDespedida();
    }

    public string GenerateMalTrato()
    {
        return regateoCharacterSO.GenerateMalTrato();
    }

    public string GenerateTrato()
    {
        return regateoCharacterSO.GenerateTrato();
    }

    public string GenerateRechazo() {
        return regateoCharacterSO.GenerateRechazo();
    }

    public void DecreaseTolerancia(float decrement) {
        regateoCharacterSO.DecreaseTolerancia(decrement);
    }
}

public class RegateoOrder {

    public string dialog {get; private set;}
    public string offer {get; private set;}
    public RegateoProduct product {get; private set;}
    public int amount {get; private set;}

    public RegateoOrder(string dialog, RegateoProduct product, int amount)
    {
        this.dialog = dialog;
        this.product = product;
        this.amount = amount;
        this.offer = GenerateOfferMessage();
    }

    private string GenerateOfferMessage() {
        string productPlurable = amount > 1 ? product.pluralName : product.name;

        string total = string.Format("{0:C0}", amount * product.price);

        string message = $"{amount} {productPlurable} por {product.price} pesos cada {product.name}: {total}";

        return message;
    }

    public int GetPrice() {
        return amount * product.price;
    }
}
