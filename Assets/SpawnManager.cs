using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<SpawnLocation> spawnLocations = new List<SpawnLocation>();

    void Start()
    {
        foreach (var building in spawnLocations)
        {
            if (building.Location.Count >= 10)
            {
                int m416 = 0, smoke = 0, granade = 0, ammo = 0, pistol = 0, shotgun = 0, uzi = 0;
                foreach (var location in building.Location)
                {

                    var randomItem = building.SpawnRandomItem(location.transform.position);
                    Debug.Log(randomItem.Name + randomItem.Chance);

                    if (randomItem.Name == "m416" && m416 < 2)
                    {
                        m416++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "smoke" && smoke < 1) 
                    {
                        smoke++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "granade" && granade < 1) 
                    { 
                        granade++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "ammo" && ammo < 4) 
                    { 
                        ammo++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "pistol" && pistol < 1) 
                    { 
                        pistol++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "shotgun" && shotgun < 1 && Random.Range(0, 3) > 2.5)
                    { 
                        shotgun++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }
                    if (randomItem.Name == "uzi" && uzi < 1 && Random.Range(0, 3) > 2.5) 
                    { 
                        uzi++; Instantiate(randomItem.Prefab, location.transform.position, Quaternion.identity, transform);
                    }


                    //Instantiate(randomItem.Prefab, location.transform.position , Quaternion.identity, transform);

                }
            }

        }
    }





}
