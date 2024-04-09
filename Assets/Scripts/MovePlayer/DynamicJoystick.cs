using Unity.VisualScripting;
using UnityEngine;

public class DynamicJoystick : MonoBehaviour
{
    public static DynamicJoystick instance;

    public GameObject joystickPrefab;
    public GameObject joystickbg;

    public GameObject currentjoybg;
    public GameObject currentJoystick;
    public Vector2 bugdiff;
   
    public bool touchingScreen = false;

    private Vector3 startpos;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    public float horinput;


    [SerializeField] private float joysize;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (StartDelay.instance.gameon)
        {
            if (Input.touchCount > 0)
            {
                print("dokunma algýlandý");
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    print("oluþturacaðým");

                    currentjoybg = Instantiate(joystickbg, Input.GetTouch(0).position + bugdiff, Quaternion.identity);
                    currentJoystick = Instantiate(joystickPrefab, Input.GetTouch(0).position, Quaternion.identity);

                    startpos = currentJoystick.transform.position;
                    maxX = startpos.x + 100;
                    minX = startpos.x - 100;
                    minY = startpos.y - 100;
                    maxY = startpos.y + 100;
                    currentJoystick.transform.SetParent(GameObject.Find("RealCanvas").transform, false);

                    currentjoybg.transform.SetParent(GameObject.Find("RealCanvas").transform, false);
                    currentjoybg.transform.SetSiblingIndex(0);
                }
                touchingScreen = true;
            }
            else
            {

                if (touchingScreen)
                {

                    if (currentJoystick != null)
                    {
                        Destroy(currentJoystick);
                        Destroy(currentjoybg);
                        PlayerMovement.instance.hordirection = 0;
                    }
                    touchingScreen = false;
                }
            }


            if (touchingScreen)
            {
                currentJoystick.transform.position = Input.GetTouch(0).position;

                Vector3 currentposition = currentJoystick.transform.position;

                float x = currentposition.x;
                float y = currentposition.y;

                x = Mathf.Clamp(x, minX, maxX);
                y = Mathf.Clamp(y, minY, maxY);

                currentJoystick.transform.position = new Vector3(x, y, currentJoystick.transform.position.z);

                float diff = x - startpos.x;

                horinput = 2f * ((x - minX) / (maxX - minX)) - 1f;
                PlayerMovement.instance.hordirection = horinput;






            }


        }
    
    }
}
