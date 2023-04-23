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
            //TODO implementar con distribucion de probabilidad de los productos
            int randomIndex = Random.Range(0, potentialProducts.Count);
            RegateoProduct randomProduct = potentialProducts[randomIndex];

            if(products.ContainsKey(randomProduct))
                products[randomProduct]++;
            else
                products[randomProduct] = 1;
        }

        return new RegateoCharacter(regateoCharacterSO, products);

    }


}

[System.Serializable]
public class RegateoCharacter {

    public RegateoCharacterSO regateoCharacterSO {get; private set;}

    public Dictionary<RegateoProduct, int> products {get; private set;}

    public RegateoCharacter(RegateoCharacterSO regateoCharacterSO, Dictionary<RegateoProduct, int> products)
    {
        this.regateoCharacterSO = regateoCharacterSO;
        this.products = products;
    }

    public string GenerateSaludo()
    {
        return regateoCharacterSO.GenerateSaludo();
    }

    public string GeneratePedido(int cantidad, string producto)
    {
        return regateoCharacterSO.GeneratePedido(cantidad, producto);
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
