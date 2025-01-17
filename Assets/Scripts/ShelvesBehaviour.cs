using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShelvesBehaviour : BasicBehaviour
{
    [SerializeField]
    private BookBehaviour[] books;

    [SerializeField]
    private GameObject storeBookButton;

    public override void EnterInteraction()
    {
        base.EnterInteraction();

        foreach(BookBehaviour book in books)
        {
            book.SetToFlyingPosition();
        }

        if (storeBookButton.activeSelf == false) storeBookButton.SetActive(true);
    }
}
