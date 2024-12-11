using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform customerSpawnPoint;
    [SerializeField] private Vector2 customerArrivalMinMaxTime;
    private float customerArrivalTime;
    private float customerArrivalTimer;

    private TableOccupationChecker tableOccupationChecker;

    void Start()
    {
        tableOccupationChecker = TableOccupationChecker.instance;

        customerArrivalTime = GetCustomerArrivalTime();
    }

    void Update()
    {
        int availableTablesQuantity = tableOccupationChecker.GetAvailableQuantity(); // stores number of available tables
        
        if (availableTablesQuantity != 0)
        {
            customerArrivalTimer += Time.deltaTime;

            if (customerArrivalTimer >= customerArrivalTime)
            {
                int tableIndex = Random.Range(0, availableTablesQuantity); // select random index from the available tables
                Table assignedTable = tableOccupationChecker.GetAvailableTable()[tableIndex]; // stores selected table
                assignedTable.SetOccupation(true); // set the occupation status of the selected table to true
                tableOccupationChecker.UpdateAvailableTableQuantity(); // update the quantity of available tables
                
                Customer spawnedCustomer = Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity).GetComponent<Customer>(); // spawn customer in the door
                spawnedCustomer.SetAssignedTable(assignedTable.gameObject); // set the assigned table to the customer

                customerArrivalTime = GetCustomerArrivalTime(); // reset
                customerArrivalTimer = 0;
            }
        }
        else
        {
            customerArrivalTimer = 0;
        }
    }

    public float GetCustomerArrivalTime() // get random customer arrival time
    {
        return Random.Range(customerArrivalMinMaxTime.x, customerArrivalMinMaxTime.y);
    }
}
