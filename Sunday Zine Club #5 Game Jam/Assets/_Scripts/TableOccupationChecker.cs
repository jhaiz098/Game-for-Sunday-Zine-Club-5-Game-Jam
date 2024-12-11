using UnityEngine;
using System.Collections.Generic;

public class TableOccupationChecker : MonoBehaviour
{
    public static TableOccupationChecker instance;

    [SerializeField] private List<Table> tables = new List<Table>();
    private int availableTableQuantity;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        availableTableQuantity = GetAvailableTable().Count;
    }

    public int GetAvailableQuantity()
    {
        return availableTableQuantity;
    }

    public List<Table> GetAvailableTable()
    {
        List<Table> availableTables = new List<Table>();

        foreach (Table table in tables)
        {
            if (table.GetOccupation() == false)
            {
                availableTables.Add(table);
            }
        }

        return availableTables;
    }

    public void UpdateAvailableTableQuantity()
    {
        availableTableQuantity = GetAvailableTable().Count;
    }
}
