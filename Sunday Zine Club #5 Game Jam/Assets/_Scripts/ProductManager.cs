using UnityEngine;
using System.Collections.Generic;

public class ProductManager : MonoBehaviour
{
    public static ProductManager instance;
    [SerializeField] public List<ProductsSO> products;

    private void Awake()
    {
        instance = this;
    }

    public List<ProductsSO> GetProducts()
    {
        return products;
    }

    public ProductsSO RandomlySelectProduct()
    {
        return products[Random.Range(0, products.Count)];
    }
}