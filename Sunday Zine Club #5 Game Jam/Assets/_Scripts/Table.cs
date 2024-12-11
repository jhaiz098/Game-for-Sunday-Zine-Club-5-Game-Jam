using UnityEngine;

public class Table : MonoBehaviour
{
    private bool isOccupied = false;

    public void SetOccupation(bool _isOccupied)
    {
        this.isOccupied = _isOccupied;
    }

    public bool GetOccupation()
    {
        return this.isOccupied;
    }
}
