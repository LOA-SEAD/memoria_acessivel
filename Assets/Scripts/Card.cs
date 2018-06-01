﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public CardNumber cardNumber;
    private bool found = false;
    private bool flipped = false;
    private MemoryPairing memoryPairing;

	// Use this for initialization
	void Start () {
        memoryPairing = FindObjectOfType<MemoryPairing>();
	}

    private void OnMouseEnter()
    {
        SelectCard();
    }
    private void OnMouseExit()
    {
        DeselectCard();
    }

    /*private void OnMouseOver()
    {
    }*/

    private void OnMouseDown()
    {
        if (MemoryPairing.canSelect) {
            if(!found && !flipped)
            {
                ActivateCard();
            }
            else
            {

            }
        }
    }

    private void SelectCard()
    {
        this.GetComponent<AudioSource>().Play();
        //Activate hover effect
    }
    private void DeselectCard()
    {
        //Deactivate hover effect
    }
    
    public void ActivateCard() {
        Flip();
        StartCoroutine(memoryPairing.ActivateCard(this));
    }

    public void SetAsFound()
    {
        GetComponent<AudioSource>().volume = 0.5f;
        found = true;
        SpriteRenderer[] cardSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer sprite in cardSprites)
        {
            sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }

    private void Flip() {
        transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
        flipped = true;
    }
    public void UnFlip() {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        flipped = false;
    }
}