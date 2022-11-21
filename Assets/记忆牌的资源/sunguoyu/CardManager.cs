using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    public const float originalX = -3;
    public const float originalY = -2;

    public Card cardprefab;
    public Sprite[] images;

    public SpriteRenderer winning;

    private Card _firstRevealed;
    private Card _secondRevealed;
    private List<int> cardNumbers;
    // 被揭开的卡
    private List<Card> faceCards;

    //private int _score = 0;
    //private int _step = 0;
    public static bool canReveal = true;

    private AudioSource myaudio;
    public AudioClip winAudio;
    public AudioClip noAudio;
    public AudioClip yesAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        myaudio = GetComponent<AudioSource>();

        faceCards = new List<Card>();
        cardNumbers = new List<int>{0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        canReveal = true;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                Card oneCard;
                oneCard = Instantiate(cardprefab);
                int tmp = Random.Range(0, cardNumbers.Count);
                int id = cardNumbers[tmp];
                cardNumbers.RemoveAt(tmp);
                oneCard.SetCard(id,images[id]);
                float posX = (offsetX * i) + originalX;
                float posY = (offsetY * j) + originalY;
                oneCard.transform.position = new Vector3(posX, posY, 1);
            }
        }

        winning.enabled = false;
    }
// 当揭开第二张卡后，点击状态改为false，然后再判断是否两张卡片相同
    public  void CardRevealed(Card mycard)
    {
        faceCards.Add(mycard);
        if (faceCards.Count == 2)
        {
            canReveal = false;
            StartCoroutine (CheckMatch ());
        }

    }

    private IEnumerator CheckMatch() 
    {
        Card card1 = faceCards[0];
        Card card2 = faceCards[1];
        if (card1.ID == card2.ID)
        {
            if (UIManager._score == 5)
            {
                //Debug.Log("win");
                UIManager._score++;
                myaudio.clip = winAudio;
                myaudio.Play();
                winning.enabled = true;
            }
            else
            {
                UIManager._score++;
                myaudio.clip = yesAudio;
                myaudio.Play();
                //Debug.Log(_score);
            }

            yield return new WaitForSeconds(1.0f);

        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            myaudio.clip = noAudio;
            myaudio.Play();
            card1.Unreveal();
            card2.Unreveal();
        }

        faceCards = new List<Card>();
        canReveal = true;
    }

    public void Restart()
    {
        
    }

    
}
