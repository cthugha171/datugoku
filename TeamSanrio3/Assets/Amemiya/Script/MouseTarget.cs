using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    //Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    public bool riset = false;
    public PlayerCon playercon;
    public GameObject player;
    public Camera camera;
    Renderer targetrender;
    Vector3 oldpos = new Vector3(0.0f, 0.0f, 0.0f);
    Rect rect = new Rect(0, 0, 1, 1);
    void Start()
    {
        
        transform.parent = camera.transform;
        gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        targetrender = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //var controllerNames = Input.GetJoystickNames();
        float hori = Input.GetAxis("Horizontal2");
        float vert = Input.GetAxis("Vertical2");
        if (playercon.playcon == true && riset == false)
        {
            Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
            pos.x = player.gameObject.transform.position.x;
            pos.y = player.gameObject.transform.position.y;
            pos.z = player.gameObject.transform.position.z;
            gameObject.transform.position = pos;
            Vector3 scale = new Vector3(0.3f, 0.3f, 0.4f);
            gameObject.transform.localScale = scale;
            riset = true;
        }
        if (playercon.playcon == true&&riset == true)
        {
            var pos = camera.WorldToViewportPoint(gameObject.transform.position);
            pos.z = 2.0f;
            var viewpos = pos;
            if (rect.Contains(viewpos))
            {
                oldpos = gameObject.transform.position;
                gameObject.transform.position += new Vector3(hori * 0.1f, vert * 0.1f, 0.0f);

                Debug.Log("いる");
            }
            else
            {
                Debug.Log("出た");
                gameObject.transform.position = oldpos;
            }

        }
        
        if (playercon.playcon == false)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 2.0f;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

    }
}
