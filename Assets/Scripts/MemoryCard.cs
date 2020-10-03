using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack = default;
    [SerializeField] SceneController controller = default;

    int _id;
    public int Id { get { return _id; } }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf) cardBack.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
   
}
