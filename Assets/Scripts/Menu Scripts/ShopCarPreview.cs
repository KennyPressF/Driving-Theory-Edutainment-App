using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCarPreview : MonoBehaviour
{
    [SerializeField] List<GameObject> previewCarsList;
    [SerializeField] Vector3 previewCarSize;

    public void SpawnPreviewCar()
    {
        int chosenCarIndex = PlayerPrefs.GetInt("Player Car");
        GameObject previewCar = Instantiate(previewCarsList[chosenCarIndex], transform.position, Quaternion.Euler(0f, 180f, 0f));
        previewCar.transform.localScale = previewCarSize;
        previewCar.transform.parent = gameObject.transform;
    }
}
