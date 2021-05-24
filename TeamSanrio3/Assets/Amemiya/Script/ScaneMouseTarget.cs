using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaneMouseTarget : MonoBehaviour
{
    Rect rect = new Rect(0, 0, 1, 1);
    Vector3 oldpos;
    public Camera camera;
    private bool conflag = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") > 0)
        {
            conflag = true;
        }

        if (conflag == false)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 7.0f;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        
        if (conflag == true)
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
    }
}
