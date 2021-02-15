using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mapObject;
    public SpriteRenderer mapRenderer;

    [SerializeField] private int maxHeight = 15;
    [SerializeField] private int maxWidth = 17;
    [SerializeField] private int currentScore;

    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    [SerializeField] private Text scoreText;


    void Start()
    {
        CreateMap();
    }

    void CreateMap()
    {
        mapObject = new GameObject("Map");
        mapRenderer = mapObject.AddComponent<SpriteRenderer>();

        Texture2D txt = new Texture2D(maxWidth, maxHeight);

        for (int x = 0; x < maxWidth; x++)
        {
            for (int y = 0; y < maxHeight; y++)
            {


                #region Set pixel

                if (x % 2 != 0)
                {
                    if (y % 2 != 0)
                    {
                        txt.SetPixel(x, y, color1);
                    }
                    else
                    {
                        txt.SetPixel(x, y, color2);
                    }
                }
                else
                {
                    if (y % 2 != 0)
                    {
                        txt.SetPixel(x, y, color2);
                    }
                    else
                    {
                        txt.SetPixel(x, y, color1);
                    }
                }
                #endregion Set pixel
            }
        }

        txt.Apply();
        Rect rect = new Rect(0, 0, maxWidth, maxHeight);
        Sprite sprite = Sprite.Create(txt, rect, Vector2.one * .5f, 1, 0, SpriteMeshType.FullRect);
        mapRenderer.sprite = sprite;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "" + currentScore;
    }
}