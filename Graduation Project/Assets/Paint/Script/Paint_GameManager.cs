using System.Collections.Generic;
using UnityEngine;

public class Paint_GameManager : MonoBehaviour
{
	Paint_LevelGenerator levelGenerator;
	GameObject AIBoard;
	GameObject playerBoard;
	List<GameObject>dots = new List<GameObject>();
	List<Color> colors = new List<Color>();

	public List<GameObject> colorPalettes = new List<GameObject>();

	int paintedDotCount;
	Color selectedColor = Color.white;

	int levelCount = 0;

	private void Start()
	{
		levelGenerator = GetComponent<Paint_LevelGenerator>();
		colors.Add(Color.blue);
		colors.Add(Color.red);
		colors.Add(Color.green);

		AIBoard = GameObject.Find("Board");
		playerBoard = GameObject.Find("PlayerBoard");

		// add all ai dots into dots list
		for (int i = 0; i < AIBoard.transform.childCount; i++)
		{
			for (int j = 0; j < AIBoard.transform.GetChild(i).childCount; j++)
			{
				dots.Add(AIBoard.transform.GetChild(i).GetChild(j).gameObject);
			}
		}

		// make all player board's dots paintable
		for (int i = 0; i < playerBoard.transform.childCount; i++)
		{
			for (int j = 0; j < playerBoard.transform.GetChild(i).childCount; j++)
			{
				playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Paint_Dot>().paintable = true;
			}
		}

		PaintTheAIBoard();
	}

	void PaintTheAIBoard()
	{
        //Resources dosyasından bölümleri çekiyor
        //colors = levelGenerator.GenerateLevel(levelCount);
        //for (int i = 0; i < dots.Count; i++)
        //{
        //	//Debug.Log(colors[i]);
        //	dots[i].GetComponent<SpriteRenderer>().color = colors[i];
        //	if (colors[i] != Color.white)
        //	{
        //		paintedDotCount++;
        //	}
        //}

        foreach (GameObject dot in dots)
        {
            if (PaintOrNot())
            {
                dot.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 3)];
                paintedDotCount++;
            }
        }
    }

	bool PaintOrNot()
	{
		if(Random.Range(0, 2) == 0)
			return true;
		else
			return false;
	}

	private void Update()
	{
		SetSelectedColor();
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				GameObject clickedDot = null;

				if (hit.collider.CompareTag("Dot"))
					clickedDot = hit.collider.gameObject;
				else if (hit.collider.CompareTag("Color"))
					selectedColor = hit.collider.gameObject.GetComponent<SpriteRenderer>().color;
				else
					return;

				if (clickedDot != null)
				{
					if (clickedDot.GetComponent<Paint_Dot>().paintable)
					{
						clickedDot.GetComponent<SpriteRenderer>().color = selectedColor;

						if (!clickedDot.GetComponent<Paint_Dot>().painted)
						{
							if (selectedColor != Color.white)
							{
								paintedDotCount--;
								clickedDot.GetComponent<Paint_Dot>().painted = true;
							}
						}
						else
						{
							if (selectedColor == Color.white)
							{
								paintedDotCount++;
								clickedDot.GetComponent<Paint_Dot>().painted = false;
							}
						}

						if (paintedDotCount == 0)
						{
							//check board
							Invoke("Control", .5f);
						}
					}
				}
			}
		}
	}

	void Control()
	{
		for (int i = 0; i < AIBoard.transform.childCount; i++)
		{
			for (int j = 0; j < AIBoard.transform.GetChild(i).childCount; j++)
			{
				if(AIBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color != 
					playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color)
				{
					return;
				}
			}
		}
		levelCount++;
		NewLevel();
	}
	
	void NewLevel()
	{
		for (int i = 0; i < AIBoard.transform.childCount; i++)
		{
			for (int j = 0; j < AIBoard.transform.GetChild(i).childCount; j++)
			{
				AIBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Paint_Dot>().painted = false;
			}
		}
		PaintTheAIBoard();
	}

	void SetSelectedColor()
    {
		foreach (var item in colorPalettes)
		{
			if (item.name == ColorToString(selectedColor))
				item.SetActive(true);
			else
				item.SetActive(false);
		}
	}

	string ColorToString(Color color)
    {
		if (color == Color.red)
			return "red";
		else if (color == Color.blue)
			return "blue";
		else if (color == Color.green)
			return "green";
		else if (color == Color.white)
			return "white";
		else
			return "";
	}

}

