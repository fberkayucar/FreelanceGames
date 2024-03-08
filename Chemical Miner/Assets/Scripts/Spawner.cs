using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Hook hook;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    Lists lists = new Lists();
    [SerializeField]
    private GameObject player;
    public string bilesen;

    private List<string> addedObjects = new List<string>();

    private void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        Spawn(-5f, -1.5f);
        Spawn(-1.8f, -3f);
        Spawn(1.8f, -3f);
        Spawn(5f, -1.5f);
    }

    void Spawn(float x, float y)
    {
        string temp;
        string final;
        // Instantiate edilen prefab'� al
        GameObject spawnedPrefab = Instantiate(prefab, new Vector3(x, y, 0f), Quaternion.identity);

        // Prefab'�n i�indeki TextMeshProUGUI ��esini bul
        TextMeshProUGUI itemText = spawnedPrefab.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI playerText = player.GetComponentInChildren<TextMeshProUGUI>();

        // Yeni bir kimyasal form�l se�
        string newFormula;
        bool formulaExists;

        do
        {
            newFormula = lists.kimyasalFormuller[Random.Range(0, lists.kimyasalFormuller.Count)];

            formulaExists = false;


            if (addedObjects.Contains(newFormula))
            {
                formulaExists = true;
            }

        } while (formulaExists);

        // Yeni form�l� ekle
        addedObjects.Add(newFormula);

        itemText.text = newFormula;

        // G�ncellenmi� kontrol yap�s�
        if (addedObjects.Count == 4)
        {
            temp = addedObjects[Random.Range(0, addedObjects.Count)];
            bilesen = temp;
            lists.kimyasalBilesenlerFormuller.TryGetValue(temp, out final);
            playerText.text = final;
            addedObjects.Clear();
        }
        Debug.Log(bilesen);
    }

}
