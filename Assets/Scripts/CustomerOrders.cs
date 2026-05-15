using TMPro;
using UnityEngine;

public class CustomerOrders : MonoBehaviour
{
    private CafeItem prevItem;
    public CafeItem requestedItem;
    public TMP_Text ItemToServe;
    
    

     public void GenerateRandomOrder()
    {
        do
        {
            int itemCount = System.Enum.GetValues(typeof(CafeItem)).Length;

            requestedItem = (CafeItem)Random.Range(0, itemCount);
        }
        while (requestedItem == prevItem);
        
        prevItem = requestedItem;
        
        Debug.Log(gameObject.name + " wants: " + requestedItem);
        ItemToServe.text = requestedItem.ToString();
    }

    public bool CheckOrder(CafeItem selectedItem)
    {
        return selectedItem == requestedItem;
    }


    void Update()
    {
        
    }
}
