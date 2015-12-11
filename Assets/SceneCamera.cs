using UnityEngine;
using System.Collections.Generic;

public class SceneCamera : MonoBehaviour
{

    public List<GameObject> players;
    
    Camera camera;
    
    float minX = 0, maxX = 0,
             minY = 0, maxY = 0;
  
    // Use this for initialization
    void Start ()
    {
        BaseCharacter[] characters = (BaseCharacter[])GameObject.FindObjectsOfType(typeof(BaseCharacter));
        foreach (BaseCharacter character in characters)
        {
            players.Add(character.gameObject);        
        }

        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindPlayerBounds();
        CameraAdjust();
	}
    void FindPlayerBounds()
    {
        GameObject minXPlayer = null; GameObject maxXPlayer = null;
        GameObject minYPlayer = null; GameObject maxYPlayer = null;
        minXPlayer = players[0]; maxXPlayer = players[0];
        minYPlayer = players[0]; maxYPlayer = players[0];

        foreach (GameObject player in players)
        {
            Vector3 tempPlayer = player.transform.position;
           
            if (player.transform.position.x < minXPlayer.transform.position.x)
                minXPlayer = player;
            if (player.transform.position.x > maxXPlayer.transform.position.x)
                maxXPlayer = player;
            if (player.transform.position.y < minXPlayer.transform.position.y)
                minYPlayer = player;
            if (player.transform.position.y > maxXPlayer.transform.position.y)
                maxYPlayer = player;

            if (minX < minXPlayer.transform.position.x)
                minX = minXPlayer.transform.position.x;
            if (maxX > maxXPlayer.transform.position.x)
                maxX = maxXPlayer.transform.position.x;

            if (minY < minYPlayer.transform.position.y)
                minY = minXPlayer.transform.position.y;
            if (maxY > maxYPlayer.transform.position.y)
                maxY = maxYPlayer.transform.position.y;


            if (tempPlayer.x < minX)
                minX = tempPlayer.x;
         
            if (tempPlayer.x > maxX)
                maxX = tempPlayer.x;
          

            if (tempPlayer.y < minY)
                minY = tempPlayer.y;
           
            if (tempPlayer.y > maxY)
                maxY = tempPlayer.y;
           
        }
    }
    void CameraAdjust()
    {
        Vector3 screenCenter = Vector3.zero;
        Vector2 cameraBuffer = new Vector2(1, 1);

        foreach (GameObject player in players)
        {
            screenCenter += player.transform.position;
        }

        screenCenter = screenCenter / players.Count;
        Vector3 targetPos = new Vector3(Mathf.Clamp(screenCenter.x,-7,7), Mathf.Clamp(screenCenter.y, -7, 7), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 30 * Time.deltaTime);

        float distance = Mathf.Sqrt(Mathf.Pow(maxX - minX, 2) + Mathf.Pow(maxY - minY, 2));
        
        float camSize = distance;

        camera.orthographicSize = Mathf.Clamp(camSize * 0.5f, 6, 20);
      
    }
}
