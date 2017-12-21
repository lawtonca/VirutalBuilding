using UnityEngine;
using System.Collections;

public class GenerateMap : MonoBehaviour
{
    public Transform target;
    public Texture2D marker;
    public float camHeight = 1.0f;
    public bool freezeRotation = true;
    public float camDistance = 2.0f;
    public bool pixelBased = false;
    public bool fromTop = false;
    public bool fromRight = false;
    public float xLocation = 50;
    public float yLocation = 50;
    public int widthPercentage = 50;
    public int heigthPercentage = 50;
    public int widthPixels = 200;
    public int heigthPixels = 200;
    private int hsize;
    private int vsize;
    private int hloc;
    private int vloc;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        angles.x = 90;
        angles.y = target.transform.eulerAngles.y;
        transform.eulerAngles = angles;
        Draw();
    }

    void Update()
    {

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + camHeight, target.transform.position.z);
        GetComponent<Camera>().orthographicSize = camDistance;

        if (freezeRotation)
        {
            Vector3 angles = transform.eulerAngles;
            angles.y = target.transform.eulerAngles.y;
            transform.eulerAngles = angles;
        }
    }

    void Draw()
    {

        if (!pixelBased)
        {
            hsize = Mathf.RoundToInt(widthPercentage * 0.01f * Screen.width);
            vsize = Mathf.RoundToInt(heigthPercentage * 0.01f * Screen.height);
        }
        else
        {
            hsize = widthPixels;
            vsize = heigthPixels;
        }

        if (!fromRight)
        {
            hloc = Mathf.RoundToInt(xLocation * 0.01f * Screen.width);
        }
        else
        {
            hloc = Mathf.RoundToInt( (Screen.width - hsize) - (xLocation * 0.01f * Screen.width));
        }

        if (!fromTop)
        {
            vloc =  Mathf.RoundToInt(yLocation * 0.01f * Screen.height);
        }
        else
        {
            vloc =  Mathf.RoundToInt((Screen.height - vsize) - (yLocation * 0.01f * Screen.height));
        }

        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);

    }

    void OnGUI(){
	Vector3 markerPos = GetComponent<Camera>(). GetComponent<Camera>().WorldToViewportPoint  (target.position);
	int pointX =  Mathf.RoundToInt((GetComponent<Camera>().pixelRect.xMin + GetComponent<Camera>().pixelRect.xMax) * markerPos.x);
	int pointY =  Mathf.RoundToInt(Screen.height - (GetComponent<Camera>().pixelRect.yMin + GetComponent<Camera>().pixelRect.yMax) * markerPos.y);
	GUI.DrawTexture( new Rect(pointX-(marker.width * 0.5f),pointY-(marker.height * 0.5f),marker.width,marker.height), marker, ScaleMode.StretchToFill, true, 10.0f);

}

}