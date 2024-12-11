using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Vector2 customerArrivalMinMaxTime;
    private float customerArrivalTime;
    private float customerArrivalTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customerArrivalTime = GetCustomerArrivalTime();
    }

    // Update is called once per frame
    void Update()
    {
        customerArrivalTimer += Time.deltaTime;

        if (customerArrivalTimer >= customerArrivalTime)
        {
            customerArrivalTime = GetCustomerArrivalTime();
            customerArrivalTimer = 0;
        }
    }

    public float GetCustomerArrivalTime()
    {
        return Random.Range(customerArrivalMinMaxTime.x, customerArrivalMinMaxTime.y);
    }
}
