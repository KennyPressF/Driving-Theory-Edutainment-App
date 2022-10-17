using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Car Stats", fileName = "New Car Stats")]

public class CarStatsSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string carName = "Enter Car Name Here";
    [SerializeField] int carDurability;
    [SerializeField] int carFuelCapacity;
    [SerializeField] int carHandling;
    [SerializeField] int carCost;
    [SerializeField] public bool carIsUnlocked;

    public string GetCarName()
    {
        return carName;
    }

    public int GetCarDurability()
    {
        return carDurability;
    }

    public void UpgradeCarDurability()
    {
        carDurability++;
    }

    public int GetCarFuelCapacity()
    {
        return carFuelCapacity;
    }
    public void UpgradeCarFuelCapacity()
    {
        carFuelCapacity++;
    }

    public int GetCarHandling()
    {
        return carHandling;
    }
    public void UpgradeCarHandling()
    {
        carHandling++;
    }

    public int GetCarCost()
    {
        return carCost;
    }

}
