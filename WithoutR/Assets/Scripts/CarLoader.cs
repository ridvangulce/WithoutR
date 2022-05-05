using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarLoader : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public Transform spawnPoint;
    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = carPrefabs[selectedCar];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
