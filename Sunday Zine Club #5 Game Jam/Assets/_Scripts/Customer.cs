using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private int minOrderQuantity;
    [SerializeField] private int maxOrderQuantity;

    private GameObject assignedTable;
    private GameObject assignedChair;
    private List<ProductsSO> orders = new List<ProductsSO>();
    private int orderQuantity;

    private float waitTime = 0.2f;

    private ProductManager productManager;
    private Rigidbody2D rb;

    void Start()
    {
        productManager = ProductManager.instance;
        rb = GetComponent<Rigidbody2D>();

        orderQuantity = GetOrderQuantity();

        for (int i = 0; i < orderQuantity; i++)
        {
            orders.Add(productManager.RandomlySelectProduct());
        }
    }

    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            if (assignedChair == null)
            {
                // select random chair around the table to sit down to
                Transform chairs = assignedTable.transform.GetChild(1);
                int chairQuantity = chairs.transform.childCount;
                int selectedChairIndex = Random.Range(0, chairQuantity);

                assignedChair = chairs.GetChild(selectedChairIndex).gameObject;
            }

            if (assignedChair != null)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, assignedChair.transform.position, movementSpeed * Time.deltaTime));
            }
        }
    }

    public void SetAssignedTable(GameObject assignedTable)
    {
        this.assignedTable = assignedTable;
    }

    private int GetOrderQuantity()
    {
        return Random.Range(minOrderQuantity, maxOrderQuantity);
    }
}
