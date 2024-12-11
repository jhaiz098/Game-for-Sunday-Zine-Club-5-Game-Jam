using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxOrderQuantity;
    private List<ProductsSO> orders = new List<ProductsSO>();
    private int orderQuantity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
