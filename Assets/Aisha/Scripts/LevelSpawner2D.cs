using UnityEngine;

public class LevelSpawner2D : MonoBehaviour
{
    [SerializeField] Texture2D levelTexture; // texture

    public GameObject rObjectToSpawn;
    public GameObject gObjectToSpawn;
    public GameObject bObjectToSpawn;

    public float zPos; // objects depth
    public float xPos; // objects spacing
    public float pixelSize;


    private void Start()
    {
        SpawnLevel();
    }
   

    #region Red

    //Check if there is space to spawn object
    private bool CanSpawnRedObject(Texture2D image, int startX, int startY, bool[,] occupied)
    {
        int redPixelCount = 0;

        for (int y = 0; y < Mathf.CeilToInt(pixelSize); y++)
        {
            for (int x = 0; x < Mathf.CeilToInt(pixelSize); x++)
            {
                int pixelX = startX + x;
                int pixelY = startY + y;

                if (pixelX >= image.width || pixelY >= image.height)
                {
                    continue;
                }

                if (occupied[pixelX, pixelY])
                {
                    return false;
                }

                Color pixelColor = image.GetPixel(pixelX, pixelY);

                if (IsRed(pixelColor))
                {
                    redPixelCount++;
                }
            }
        }

        return redPixelCount >= pixelSize;
    }

    void SpawnRedObjectFromImage()
    {
        if (levelTexture == null)
        {
            Debug.Log("No level texture found");
            return;
        }

        bool[,] occupiedPixels = new bool[levelTexture.width, levelTexture.height];

        int rObjectCount = 0;

        for (float y = 0; y < levelTexture.height; y += pixelSize)
        {
            for (float x = 0; x < levelTexture.width; x += pixelSize)
            {
                if (CanSpawnRedObject(levelTexture, Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels))
                {
                    MarkOccupied(Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels);
                    Vector3 spawnPosition = new Vector3(x * xPos, zPos, y * xPos) + transform.position;
                    Instantiate(rObjectToSpawn, spawnPosition, Quaternion.identity);
                    rObjectCount++;

                    Debug.Log("Objects spanwed in red space" + rObjectToSpawn);
                }
            }
        }
    }

    private bool IsRed(Color color)
    {
        return color.r > 0 && color.g < 1 && color.b < 1;
    }

    #endregion

    #region Green
    private bool CanSpawnGreenObject(Texture2D image, int startX, int startY, bool[,] occupied)
    {
        
        int greenPixelCount = 0;
        


        for (int y = 0; y < Mathf.CeilToInt(pixelSize); y++)
        {
            for (int x = 0; x < Mathf.CeilToInt(pixelSize); x++)
            {
                int pixelX = startX + x;
                int pixelY = startY + y;

                if (pixelX >= image.width || pixelY >= image.height)
                {
                    continue;
                }

                if (occupied[pixelX, pixelY])
                {
                    return false;
                }

                Color pixelColor = image.GetPixel(pixelX, pixelY);

                

                if (IsGreen(pixelColor))
                {
                    greenPixelCount++;
                }

            }
        }

        return greenPixelCount >= pixelSize;
    }

    void SpawnGreenObjectFromImage()
    {
        if (levelTexture == null)
        {
            Debug.Log("No level texture found");
            return;
        }

        bool[,] occupiedPixels = new bool[levelTexture.width, levelTexture.height];

        int gObjectCount = 0;

        for (float y = 0; y < levelTexture.height; y += pixelSize)
        {
            for (float x = 0; x < levelTexture.width; x += pixelSize)
            {
                if (CanSpawnGreenObject(levelTexture, Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels))
                {
                    MarkOccupied(Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels);
                    Vector3 spawnPosition = new Vector3(x * xPos, zPos, y * xPos) + transform.position;
                    Instantiate(gObjectToSpawn, spawnPosition, Quaternion.identity);
                    gObjectCount++;

                    Debug.Log("Objects spanwed in red space" + gObjectToSpawn);
                }
            }
        }
    }

    private bool IsGreen(Color color)
    {
        return color.g > 0 && color.r < 1 && color.b < 1;
    }
    #endregion

    #region Blue 
    private bool CanSpawnBlueObject(Texture2D image, int startX, int startY, bool[,] occupied)
    {

        int bluePixelCount = 0;



        for (int y = 0; y < Mathf.CeilToInt(pixelSize); y++)
        {
            for (int x = 0; x < Mathf.CeilToInt(pixelSize); x++)
            {
                int pixelX = startX + x;
                int pixelY = startY + y;

                if (pixelX >= image.width || pixelY >= image.height)
                {
                    continue;
                }

                if (occupied[pixelX, pixelY])
                {
                    return false;
                }

                Color pixelColor = image.GetPixel(pixelX, pixelY);



                if (IsBlue(pixelColor))
                {
                    bluePixelCount++;
                }

            }
        }

        return bluePixelCount >= pixelSize;
    }

    void SpawnBlueObjectFromImage()
    {
        if (levelTexture == null)
        {
            Debug.Log("No level texture found");
            return;
        }

        bool[,] occupiedPixels = new bool[levelTexture.width, levelTexture.height];

        int bObjectCount = 0;

        for (float y = 0; y < levelTexture.height; y += pixelSize)
        {
            for (float x = 0; x < levelTexture.width; x += pixelSize)
            {
                if (CanSpawnGreenObject(levelTexture, Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels))
                {
                    MarkOccupied(Mathf.FloorToInt(x), Mathf.FloorToInt(y), occupiedPixels);
                    Vector3 spawnPosition = new Vector3(x * xPos, zPos, y * xPos) + transform.position;
                    Instantiate(bObjectToSpawn, spawnPosition, Quaternion.identity);
                    bObjectCount++;

                    Debug.Log("Objects spanwed in red space" + bObjectToSpawn);
                }
            }
        }
    }

    private bool IsBlue(Color color)
    {
        return color.b > 0 && color.r < 1 && color.g < 1;
    }
    #endregion


    void SpawnLevel()
    {
        SpawnRedObjectFromImage();
        SpawnBlueObjectFromImage();
        SpawnGreenObjectFromImage();
    }

    //Marks an occupied space
    private void MarkOccupied(int startX, int startY, bool[,] occupied)
    {
        for (int y = 0; y < Mathf.CeilToInt(pixelSize); y++)
        {
            for (int x = 0; x < Mathf.CeilToInt(pixelSize); x++)
            {
                int pixelX = startX + x;
                int pixelY = startY + y;

                if (pixelX > -occupied.GetLength(0) || pixelY >= occupied.GetLength(1))
                {
                    continue;
                }

                occupied[pixelX, pixelY] = true;

       
            }
        }
 
    }


    

    

   

    
}
