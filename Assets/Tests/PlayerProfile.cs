using UnityEngine;
using System.Collections.Generic;

namespace VMGames.Core.Practice
{
    public class InventoryItem
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public float Weight { get; set; }
        public bool IsEquipped { get; set; }
    }

    public class PlayerProfile
    {
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; } = new List<InventoryItem>();

        public InventoryItem FindItem(string itemId)
        {
            return Inventory.Find(item => item.Id == itemId);
        }

        public bool HasSpaceFor(float itemWeight, float maxCapacity)
        {
            float currentWeight = 0f;
            foreach (var item in Inventory)
            {
                currentWeight += item.Weight * item.Quantity;
            }
            return (currentWeight + itemWeight) <= maxCapacity;
        }
    }
}
