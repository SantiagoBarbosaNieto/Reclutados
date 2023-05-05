
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a RegateoProduct in the inventory (so quantities can be tracked)
public class RegateoInventoryProduct
{
    public RegateoProduct regateoProduct {get; private set;}
    public int quantity {get; private set;} = 0;

    public RegateoInventoryProduct(RegateoProduct regateoProduct, int quantity)
    {
        this.regateoProduct = regateoProduct;
        this.quantity = quantity;
    }

    public void AddQuantity(int quantity) {
        this.quantity += quantity;
    }

    internal void decreaseQuantity()
    {
        if(this.quantity <= 0)
            return;
        this.quantity -= 1;
    }
    internal void increaseQuantity()
    {
        this.quantity += 1;
    }
}
