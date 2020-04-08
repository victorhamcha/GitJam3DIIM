using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    [SerializeField] private GameObject[] recipeIngredient;
    [SerializeField] private GameObject[] currentIngredient;
    private int i = -1;

    private void OnTriggerEnter(Collider other)
    {
        GameObject objCol = other.gameObject;
        Debug.Log(objCol);
        if(IsInRecipe(objCol) && IsNotAlreadyInRecipe(objCol))
        {
            Debug.Log("Good ingredient");
            currentIngredient[i] = objCol;
            //objCol.SetActive(false); // deactivate the ingredient as it is in the recipe
        }
        else if(!IsNotAlreadyInRecipe(objCol))
        {
            Debug.Log("Already in");
        }
        else if (!IsInRecipe(objCol))
        {
            Debug.Log("Bad ingredient");
        }

        if (IsTheRecipeGood())
        {
            Debug.Log("Recipe Complete !");
        }
        else
            Debug.Log("No not yet :(");
    }

    private bool IsInRecipe(GameObject checkme)
    {
        bool isIn = false;
        for (int j = 0; j < recipeIngredient.Length; j++)
        {
            if (recipeIngredient[j].gameObject == checkme)
            {
                i = j;
                isIn = true;
                break;
            }
        }
        return isIn;
    }

    private bool IsNotAlreadyInRecipe(GameObject checkme)
    {
        bool isNotIn = true;
        for (int j = 0; j < currentIngredient.Length; j++)
        {
            if (currentIngredient[j].gameObject == checkme)
            {
                isNotIn = false;
                break;
            }
        }
        return isNotIn;
    }

    private bool IsTheRecipeGood()
    {
        bool good = false;
        for (int j = 0; j < recipeIngredient.Length; j++)
        {
            if (recipeIngredient[j].gameObject == currentIngredient[j].gameObject && recipeIngredient[j] != null && currentIngredient[j] != null)
            {
                good = true;
            }
            else
            {
                good = false;
                break;
            }
        }
        return good;
    }
}
