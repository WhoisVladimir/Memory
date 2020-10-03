using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] MemoryCard originalCard = default;
    [SerializeField] Sprite[] images = default;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float ofsetX = 10f;
    public const float ofsetY = -10f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startpos = originalCard.transform.position;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0) card = originalCard;
                else card = Instantiate(originalCard);
                int id = Random.Range(0, images.Length);
                card.SetCard(id, images[id]);

                float posX = (ofsetX * i) + startpos.x;
                float posY = (ofsetY * j) + startpos.y;
                card.transform.position = new Vector3(posX, posY, startpos.z);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
