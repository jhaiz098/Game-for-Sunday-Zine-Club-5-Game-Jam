using UnityEngine;
using System.Collections.Generic;

public class TableOccupationChecker : MonoBehaviour
{
    [SerializeField] private List<Table> tables = new List<Table>();

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
}
