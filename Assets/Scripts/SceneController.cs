using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;

    MemoryCard _firstRevealed;
    MemoryCard _secondRevealed;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float ofsetX = 10f;
    public const float ofsetY = -10f;
    int _score;
    
    public bool CanReveal => _secondRevealed == null;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startpos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0) card = originalCard;
                else card = Instantiate(originalCard);
               
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (ofsetX * i) + startpos.x;
                float posY = (ofsetY * j) + startpos.y;
                card.transform.position = new Vector3(posX, posY, startpos.z);
            }
        }
    }
    int[] ShuffleArray(int[] numbers)
    {
        int[] numClones = numbers.Clone() as int[];
        for (int i = 0; i < numClones.Length; i++)
        {
            int tmp = numClones[i];
            int rndNum = Random.Range(i, numClones.Length);
            numClones[i] = numClones[rndNum];
            numClones[rndNum] = tmp;
        }
        return numClones;
    }
    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null) _firstRevealed = card;
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.Id == _secondRevealed.Id)
        {
            _score++;
            Debug.Log($"Счёт: {_score}");
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }
}
