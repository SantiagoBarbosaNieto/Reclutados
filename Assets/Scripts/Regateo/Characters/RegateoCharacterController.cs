using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RegateoCharacterController
{
    private RegateoCharacter regateoCharacter;

    // Creates RegateoCharacter controller for one character generated 
    public RegateoCharacterController(RegateoCharacter character)
    {
        this.regateoCharacter = character;
    }

    public string Greet() {
        return regateoCharacter.GenerateSaludo();
    }

    public bool OrdersAvailable() {
        return regateoCharacter.products.Count > 0;
    }

    public RegateoOrder GenerateOrder() {

        if(regateoCharacter.products.Count == 0) {
            Debug.LogError("No hay productos en espera para el personaje: " + regateoCharacter.regateoCharacterSO.name);
            return null;
        }

        Dictionary<RegateoProduct, int> regateoProducts = regateoCharacter.products;

        // Get random product and remove it from the dictionary
        int randomIndex = Random.Range(0, regateoProducts.Count);

        KeyValuePair<RegateoProduct, int> randomProduct = regateoProducts.ElementAt(randomIndex);
        regateoProducts.Remove(randomProduct.Key);

        string message = regateoCharacter.GeneratePedido(randomProduct.Value, randomProduct.Key.name);

        return new RegateoOrder(message, randomProduct.Key, randomProduct.Value);
    }

    public string ReactRejection() {
        return regateoCharacter.GenerateRechazo();
    }

    public string RejectDeal() {
        return regateoCharacter.GenerateRechazo();
    }

    public string SayGoodbye() {
        return regateoCharacter.GenerateDespedida();
    }

    public class RegateoOrder {
        public string message {get; private set;}
        public RegateoProduct product {get; private set;}
        public int amount {get; private set;}

        public RegateoOrder(string message, RegateoProduct product, int amount)
        {
            this.message = message;
            this.product = product;
            this.amount = amount;
        }
    }
}
