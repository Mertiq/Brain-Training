using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Paint_GameManager : MonoBehaviour
{
	Paint_LevelGenerator levelGenerator;
	GameObject AIBoard;
	GameObject playerBoard;
	List<GameObject>dots = new List<GameObject>();
	List<Color> colors = new List<Color>();

	public List<GameObject> colorPalettes = new List<GameObject>();

	[SerializeField] private GameObject fadePanel;
	

	int paintedDotCount;
	Color selectedColor = Color.white;

	int levelCount = 0;

	[SerializeField] private bool isGameEnd;
	public delegate void GameEnd ();
	public static event GameEnd OnGameEnd;   
	private void Start()
	{
		MainMenuAnimationController.FadeOutAnim(fadePanel);
		levelGenerator = GetComponent<Paint_LevelGenerator>();
		colors.Add(Color.blue);
		colors.Add(Color.red);
		colors.Add(Color.green);

		AIBoard = GameObject.Find("Board");
		playerBoard = GameObject.Find("PlayerBoard");

		// add all ai dots into dots list
		for (var i = 0; i < AIBoard.transform.childCount; i++)
		{
			for (var j = 0; j < AIBoard.transform.GetChild(i).childCount; j++)
			{
				dots.Add(AIBoard.transform.GetChild(i).GetChild(j).gameObject);
			}
		}

		// make all player board's dots paintable
		for (var i = 0; i < playerBoard.transform.childCount; i++)
		{
			for (var j = 0; j < playerBoard.transform.GetChild(i).childCount; j++)
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

        foreach (var dot in dots.Where(dot => PaintOrNot()))
        {
	        dot.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 3)];
	        paintedDotCount++;
        }
	}

	private static bool PaintOrNot()
	{
		return Random.Range(0, 2) == 0;
	}

	private void Update()
	{
		if (isGameEnd)
		{
			OnGameEnd?.Invoke();
			Time.timeScale = 0;
			isGameEnd = !isGameEnd;
		}
		SetSelectedColor();
		if (!Input.GetMouseButtonDown(0)) return;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (!Physics.Raycast(ray, out var hit, 100)) return;
		GameObject clickedDot = null;

		if (hit.collider.CompareTag("Dot"))
			clickedDot = hit.collider.gameObject;
		else if (hit.collider.CompareTag("Color"))
		{
			selectedColor = hit.collider.gameObject.GetComponent<SpriteRenderer>().color;
			FindObjectOfType<AudioManager>().PlaySound("change");
		}
		else
			return;

		if (clickedDot == null) return;
		if (!clickedDot.GetComponent<Paint_Dot>().paintable) return;
		clickedDot.GetComponent<SpriteRenderer>().color = selectedColor;

		if (!clickedDot.GetComponent<Paint_Dot>().painted)
		{
			if (selectedColor != Color.white)
			{
				paintedDotCount--;
				clickedDot.GetComponent<Paint_Dot>().painted = true;
				FindObjectOfType<AudioManager>().PlaySound("paint");
			}
		}
		else
		{
			if (selectedColor == Color.white)
			{
				paintedDotCount++;
				clickedDot.GetComponent<Paint_Dot>().painted = false;
				FindObjectOfType<AudioManager>().PlaySound("white");
			}
		}

		if (paintedDotCount == 0)
		{
			//check board
			Invoke("Control", .5f);
		}
	}

	private void Control()
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
		OnGameEnd?.Invoke();
		Time.timeScale = 0;
		levelCount++;
		//NewLevel();
		FindObjectOfType<AudioManager>().PlaySound("end");
	}

	private void NewLevel()
	{
		for (var i = 0; i < AIBoard.transform.childCount; i++)
		{
			for (var j = 0; j < AIBoard.transform.GetChild(i).childCount; j++)
			{
				AIBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				playerBoard.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Paint_Dot>().painted = false;
			}
		}
		PaintTheAIBoard();
	}

	private void SetSelectedColor()
    {
		foreach (var item in colorPalettes)
		{
			item.SetActive(item.name == ColorToString(selectedColor));
		}
	}

	private static string ColorToString(Color color)
    {
		if (color == Color.red)
			return "red";
	    if (color == Color.blue)
			return "blue";
		if (color == Color.green)
			return "green";
		return color == Color.white ? "white" : "";
    }

}

