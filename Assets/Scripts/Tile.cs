using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isMine;
    public int adjacentMines

    public void Reveal()
    {

    }

    private void OnMouseDown()
    {
        if (isMine)
        {
            Debug.Log("Game Over");
        }
        else
        {
            Reveal();
        }
    }
}
