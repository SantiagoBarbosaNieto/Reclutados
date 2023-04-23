using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RegateoCharacterFactory
{
    static int productMin = 2;
    static int productMax = 4;

    public static RegateoCharacter CreateRegateoCharacter(RegateoCharacterSO regateoCharacterSO, List<RegateoProduct> potentialProducts) {
        int productAmount = Random.Range(productMin, productMax);
        
        Dictionary<RegateoProduct, int> products = new Dictionary<RegateoProduct, int>();

        for (int i = 0; i < productAmount; i++) {
            //TODO probar distribucion
            RegateoProduct randomProduct = GetRandomProduct(potentialProducts, regateoCharacterSO);

            if(products.ContainsKey(randomProduct))
                products[randomProduct]++;
            else
                products[randomProduct] = 1;
        }
        
        List<RegateoOrder> orders = new List<RegateoOrder>();

        foreach(var product in products) {
            orders.Add(new RegateoOrder(regateoCharacterSO.GeneratePedido(product.Value, product.Key.name), product.Key, product.Value));
        }

        return new RegateoCharacter(regateoCharacterSO, orders);

    }

    private static RegateoProduct GetRandomProduct(List<RegateoProduct> potentialProducts, RegateoCharacterSO regateoCharacterSO) {

        if(potentialProducts.Count == 0)
            throw new System.Exception("No hay productos disponibles");

        // TODO aplicar distribucion

        return potentialProducts[Random.Range(0, potentialProducts.Count)];

    }


}
