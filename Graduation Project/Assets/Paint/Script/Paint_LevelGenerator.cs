using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Paint_LevelGenerator : MonoBehaviour
{
    public Texture2D[] maps;

	private void Awake()
	{
		maps = Resources.LoadAll<Texture2D>("Paint");
	}

	public List<Color> GenerateLevel(int level)
	{
		List<Color> colors = new List<Color>();

		for (int j = maps[level].height - 1; j >= 0; j--)
		{
			for (int i = 0; i < maps[level].width; i++)
			{
				if (maps[level].GetPixel(i, j).a == 0)
				{
					colors.Add(Color.white);
				}
				else
				{
					colors.Add(maps[level].GetPixel(i, j));
				}
			}
		}
		return colors;
	}
}

