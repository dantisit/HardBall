using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeObjectsOnLocation : MonoBehaviour
{
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private GameObject[] ObjectsToOn;
    [SerializeField] private GameObject[] ObjectsToOff;

    private void Update()
    {
        if ( !(targetObjects.All(o => o == null)) ) return; // Проверяем все ли объекты массива уничтожены

        DoOnObject();
        DoOffObject();
        enabled = false;
    }

    private void DoOnObject() 
    {
        for (int i = ObjectsToOn.Length - 1; i >= 0; i--)
        {
            int CountOfChild = ObjectsToOn[i].transform.childCount;

            ObjectsToOn[i].SetActive(true);

            if (CountOfChild == 0) return; // Проверяем есть ли объекта дети

            for (int j = CountOfChild - 1; j >= 0; j--) 
            {
                if (ObjectsToOn[i].transform.GetChild(j).TryGetComponent<ChangeEffects>(out ChangeEffects Effect)) // Получаем эффект объекта
                {
                    Effect.DoEffectOn();
                }
            } 
        }
    }

    private void DoOffObject() 
    {
        for (int i = ObjectsToOff.Length - 1; i >= 0; i--) 
        {
            int CountOfChild = ObjectsToOff[i].transform.childCount;

            if (CountOfChild == 0) return; // Проверяем есть ли у объекта дети

            for (int j = CountOfChild - 1; j >= 0; j--)
            {
                if (ObjectsToOff[i].transform.GetChild(j).TryGetComponent<ChangeEffects>(out ChangeEffects Effect)) 
                { 
                    Effect.DoEffectOff();
                }
            }

            Destroy(ObjectsToOff[i]);
        } 
            
    }
}
