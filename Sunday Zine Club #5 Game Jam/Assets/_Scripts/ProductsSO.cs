using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Scriptable Objects/ProductSO")]
public class ProductsSO : ScriptableObject
{
    public string productName;
    public int cost;
    public Sprite icon;
}
