using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer  cardBack;

    private int id;

    public int ID
    {
        get { return id; }
    }

    public void SetCard(int _id, Sprite _sprite)
    {
        id = _id;
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    public void OnMouseDown()
    {
        if (cardBack.enabled && CardManager.canReveal == true)
        {
            cardBack.enabled = false;
            FindObjectOfType<CardManager>().CardRevealed(this);
            UIManager._step++;
        }
        //throw new NotImplementedException();
    }

    public void Unreveal()
    {
        cardBack.enabled = true;
    }

   
}
