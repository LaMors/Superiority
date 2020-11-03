using System.Collections.Generic;
using UnityEngine;


public class GameFeild : MonoBehaviour
{

	[SerializeField]
	private List<Sprite> sprites = new List<Sprite>();

	[SerializeField]
	private GameObject _hexes;

	[SerializeField]
	private GameObject canvas;

	private float kTemperature = 1;
	private float[,] wet;
	private int height = 100;
	private int width = 100;
	private Vector3[,] tirlesCoordinates;
	private GameObject[,] hexes;
	private float exponent = 2.718f;
	private float freq = 1;
	private float[,] elevation;
	private float[,] temperature;
	private float x = 0;
	private float y = 0;

    void Start ()
	{
		canvas = Instantiate(canvas);


		EventAggregator.SummonPanelVisibility("All", false);

		height = StartDataHolder.worldHeightHolder;

		width = StartDataHolder.worldWidthHolder;

		tirlesCoordinates = new Vector3[width, height];

		hexes = new GameObject[width, height];

		exponent = StartDataHolder.elevelevationHolder;

		kTemperature = StartDataHolder.temperatureHolder;

		freq = StartDataHolder.biomeSizeHolder;

		Cell.CellsCollections = hexes;

		Сreatur_hexes();

		GetTextures();
	}


	private void Сreatur_hexes()
	{

		var scaleHex = _hexes.GetComponent<Transform>().localScale.x;
		var _cellRadius = _hexes.GetComponent<CircleCollider2D>().radius * scaleHex;


		for (int i = 0; i < width; i++)
		{

			for (int j = 0; j < height; j++)
			{

				hexes[i, j] = Instantiate(_hexes, new Vector3(x, y, 1), Quaternion.identity);
				var cell = hexes[i, j].GetComponent<Cell>();
				tirlesCoordinates[i, j] = new Vector3(x, y, 1);

				y = y + _cellRadius * 2;

				cell.Index = new Vector2Int(i, j);
				cell.Radius = _cellRadius + 0.2f;

			}
			y = tirlesCoordinates[i, 0].y;

			if (y == 0)
			{
				y = _cellRadius;
			}
			else
			{
				y = 0;
			}

			x = tirlesCoordinates[i, 0].x + _cellRadius * 1.1547005383792515f * 1.5f;

		}


	}

	private void GetTextures()
	{

		elevation = new float[height, width];

		temperature = new float[height, width];

		wet = new float[height, width];

		float rand = Random.Range(0f, 10.1f);

		 for (int i = 0; i < height; i++)
			{
			for (int j = 0; j < width; j++)
				{

				float nx = (tirlesCoordinates[i, j].x / width - 0.5f) + rand, ny = (tirlesCoordinates[i, j].y / height - 0.5f) + rand;
				elevation[i, j] = 2 * (0.5f - Mathf.Abs(0.5f - Mathf.PerlinNoise(freq * nx, freq * ny)));


				elevation[i, j] = Mathf.Pow(elevation[i, j], exponent);

				}
			}

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{

				float nx = (tirlesCoordinates[i, j].x / width - 0.5f) + rand, ny = (tirlesCoordinates[i, j].y / height - 0.5f) + rand;

				float k = Mathf.Abs(j - (width / 2));
				k = k / width;

				temperature[i, j] = (Mathf.PerlinNoise (freq * (nx+1), freq * (ny+1))) - k + kTemperature;

			}
		}

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				float nx = (tirlesCoordinates[i, j].x / width - 0.5f) + rand, ny = (tirlesCoordinates[i, j].y / height - 0.5f) + rand;

				wet[i, j] = Mathf.PerlinNoise(freq * (nx-1), freq * (ny-1));

			}
		}

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				hexes[i, j].GetComponent<SpriteRenderer>().sprite = sprites.Find(item => item.name == Biome(elevation[i, j], temperature[i, j], wet[i, j]));
				
			}
		}



	}

	private string Biome(float elevation, float temperature, float wet)
	{
		if (elevation <= 0.8f && temperature < 0.1f)
		{
			return "Ice";
		}

		if (elevation <= 0.07f && temperature >= 0.1f)
		{
			return "Ocean";
		}

		if (elevation > 0.07f && elevation <= 0.15f && temperature >= 0.1f)
		{
			return "Water";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.1f && temperature <= 0.2f)
		{
			return "Tundra";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.2f && temperature <= 0.7f && wet < 0.25f )
		{
			return "Steppe";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.2f && temperature <= 0.7f && wet >= 0.25f && wet < 0.35f)
		{
			return "Forest"; 
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.2f && temperature <= 0.7f && wet >= 0.35f && wet < 0.45f)
		{
			return "Undergrowth";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.2f && temperature <= 0.7f && wet >= 0.45f && wet <= 0.7f)
		{
			return "Plain";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.2f && temperature <= 0.7f && wet > 0.7f)
		{
			return "Swamp";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.7f && wet > 0.6f)
		{
			return "Jungle";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.7f  && wet <= 0.3f)
		{
			return "Sand";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.7f && wet > 0.3f && wet <= 0.45f)
		{
			return "Desert";
		}

		if (elevation <= 0.8f && elevation > 0.15f && temperature > 0.7f && wet > 0.45f && wet <= 0.6f)
		{
			return "Savannah";
		}

		if (elevation <= 0.9f && elevation > 0.8f && temperature > 0.7f && wet <= 0.6f)
		{
			return "Dune";
		}

		if (elevation <= 0.9f && elevation > 0.8f && temperature <= 0.7f)
		{
			return "Hills";
		}

		if (elevation <= 0.9f && elevation > 0.8f && temperature > 0.7f && wet > 0.6f)
		{
			return "Hills";
		}

		if (elevation > 0.9f && temperature > 0.7f && wet <= 0.6f)
		{
			return "DesertMountains";
		}

		if (elevation > 0.9f && temperature <= 0.7f && wet > 0.6f)
		{
			return "Mountain";
		}
		
		return "Mountain";
	}



}


