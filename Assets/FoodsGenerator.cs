using UnityEngine;
using System.Collections;

public class FoodsGenerator : MonoBehaviour
{
    public GameObject[] allLocations;

    private int nbFoodsMax = 2;
    private int nbFoodMin = 0;

    public void showSomeFoods()
    {
        HideAllFood();
        float bonus =(float)nbFoodsMax / (float)GameManager.instance.nbDay;
        nbFoodMin = Mathf.RoundToInt(bonus);
        int nbFood = Random.Range(nbFoodMin, nbFoodsMax + 1);

        while(nbFood > 0)
        {
            int id = Random.Range(0, allLocations.Length);
            if (allLocations[id].activeInHierarchy == false)
            {
                allLocations[id].SetActive(true);
                nbFood--;
            }
        }

    }

    public void HideAllFood()
    {
        for(int i = 0; i<allLocations.Length; i++)
        {
            allLocations[i].SetActive(false);
        }
    }
}
