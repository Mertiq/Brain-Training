using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private TextMesh textMesh;

    [HideInInspector] public string letter;
    [HideInInspector] public int Lane;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        SetLetter(0, "B");
    }

    public void SetLetter(int lane, string letter)
    {
        this.Lane = lane;
        this.letter = letter;
        textMesh.text = letter;
        Vector3 newPos;

        if (lane == -1)
        {
            newPos = new Vector3(-5f, transform.position.y, transform.position.z);
        }
        else if (lane == 0)
        {
            newPos = new Vector3(-1.22f, transform.position.y, transform.position.z);

        }
        else
        {
            newPos = new Vector3(1.36f, transform.position.y, transform.position.z);
        }

        transform.position = newPos;
    }
}
