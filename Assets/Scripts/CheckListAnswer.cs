using UnityEngine;
using UnityEngine.UI;

public class CheckListAswner : MonoBehaviour
{
    public GameObject[] checkMin;
    public GameObject[] checkMax;
    public PuzzleBooksButtons books;
    public Sprite checkOn;


    public void UpdateCheck()
    {
        if (books.booksCorrects[0])
        {
            checkMin[0].GetComponent<Image>().sprite = checkOn;
            checkMax[0].GetComponent<Image>().sprite = checkOn;
        }
        if (books.booksCorrects[1])
        {
            checkMin[1].GetComponent<Image>().sprite = checkOn;
            checkMax[1].GetComponent<Image>().sprite = checkOn;
        }
        if (books.booksCorrects[2])
        {
            checkMin[2].GetComponent<Image>().sprite = checkOn;
            checkMax[2].GetComponent<Image>().sprite = checkOn;
        }
        if (books.booksCorrects[3])
        {
            checkMin[3].GetComponent<Image>().sprite = checkOn;
            checkMax[3].GetComponent<Image>().sprite = checkOn;
        }
    }
}
