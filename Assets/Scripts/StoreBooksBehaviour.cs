using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBooksBehaviour : BasicBehaviour
{
    [SerializeField]
    private BookBehaviour[] books;

    public override void EnterInteraction()
    {
        base.EnterInteraction();

        foreach(BookBehaviour book in books)
        {
            book.SetToShelfPosition();
        }

        gameObject.SetActive(false);
    }
}
