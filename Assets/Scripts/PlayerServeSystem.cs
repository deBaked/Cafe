using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerServeSystem : MonoBehaviour
{
    public CustomerOrders customerOrders_sc;
    public CafeItem selectedItem;
    public int selectedItemIndex;
    public int correctItemNum, firstRanNum, secondRanNum;

    public Transform itemGrid;
    [SerializeField] public List<GameObject> availableItems;

    void Start()
    {
        customerOrders_sc.GenerateRandomOrder();
        ShuffleItemGrid();
    }

    public void SetChosenItem(int itemIndex)
    {
        selectedItem = (CafeItem)itemIndex;
        selectedItemIndex = itemIndex;
    }

    public void ShuffleItemGrid()
    {
        Debug.unityLogger.Log("Shuffling item grid");

        correctItemNum = (int)customerOrders_sc.requestedItem;
        
        // Pick first item guess
        do
        {
            firstRanNum = Random.Range(0, availableItems.Count);
        }
        while (firstRanNum == correctItemNum);

        // Pick second item guess
        do
        {
            secondRanNum = Random.Range(0, availableItems.Count);
        }
        while (secondRanNum == firstRanNum || secondRanNum == correctItemNum);

        foreach (GameObject item in availableItems)
        {
            item.SetActive(false);
        }
        
        for (int i = 0; i < availableItems.Count; i++)
        {
            // if (i != firstRanNum || i != secondRanNum || i != correctItemNum)
            // {
            //     Debug.logger.Log("Item " + i + " and " +  firstRanNum + " and " + secondRanNum + " and " + correctItemNum);
            //     availableItems[i].SetActive(false);
            // }
            if (i == firstRanNum || i == secondRanNum || i == correctItemNum)
            {
                availableItems[i].transform.SetSiblingIndex(Random.Range(0, 2));
                availableItems[i].SetActive(true);
            }
        }
    }
    
    public void ServeCustomer()
    {
        bool correct = customerOrders_sc.CheckOrder(selectedItem);
        
        
        if (correct)
        {
            Debug.Log("Correct order served!");
            
            customerOrders_sc.GenerateRandomOrder();
            // Reward player
            // Add money
            // Increase score
            
            ShuffleItemGrid();
        }
        else
        {
            Debug.Log("Wrong order!");

            // Penalty logic
            // Angry customer
            // Lose reputation
        }
    }
}
