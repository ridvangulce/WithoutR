using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarShopDatabase",menuName = "Shopping/Cars shop database")]
public class CarShopDatabase : ScriptableObject
{
   public Car[] cars;

   public int CarsCount
   {
      get { return cars.Length; }
   }
   public Car GetCar(int index)
   {
      return cars[index];
   }

   public void PurchaseCar(int index)
   {
      cars[index].isPurchased = true;
   }
}
