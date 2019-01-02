using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelController : MonoBehaviour
{
    public Button cameraMoveableButton;
    public GameObject mainPanel;
    public GameObject blockInformation;
    public GameObject playerInformation;

    private Camera characterCamera;///

    private static float mainPainelMaxHight;
    private static float mainPainelMinHight;
    private static float mainPainelVelocity = -210;
    private bool mainPanelMoveable;

    private Vector3 originalCameraPos;
    private bool viewChangeable;

    private const int mainCameraVelocity = 2;

    private GameObject resoucesInfoPanel;
    private GameObject attributesInfoPanel;

    void Start()
    {
        mainPanelMoveable = false;
        characterCamera = this.gameObject.GetComponent<Camera>();
        viewChangeable = false;


        //resoucesInfoPanel   = GameObject.Instantiate(Resources.Load<GameObject>("PreFab/Ui/main/ResourcesInformation"));
        //attributesInfoPanel = GameObject.Instantiate(Resources.Load<GameObject>("PreFab/Ui/main/AttributesInformation"));
    }

    void Update()
    {

        mainPainelMaxHight = mainPanel.transform.position.y;
        mainPainelMinHight = characterCamera.pixelRect.y;
        //mainPanelMove();
        if ( Input.GetKeyDown(KeyCode.Y) )
        {
            viewChangeable = !viewChangeable;
        }
    }

    public void CollapseButtonOnClick()
    {
        if ( mainPanel.transform.position.y == mainPainelMaxHight ||
             mainPanel.transform.position.y == mainPainelMinHight )
        {
            mainPanelMoveable = true;
        }
    }
    public void CameraMoveableButtonOnClick()
    {
        viewChangeable = !viewChangeable;
    }

    public void changeCameraView(GlobalManager world)
    {
        originalCameraPos = world.CurrentPlayer.Location + new Vector3(-1 ,19 ,-3);


        float x = originalCameraPos.x;
        float z = originalCameraPos.z;
        float y = Input.GetAxis("Mouse ScrollWheel") * -1 * mainCameraVelocity * 10;


        y = ( characterCamera.transform.position.y + y < 16f ) ? 16f : characterCamera.transform.position.y + y;
        if ( viewChangeable || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
        {
            x = characterCamera.transform.position.x + Input.GetAxis("Horizontal") * mainCameraVelocity;
            z = characterCamera.transform.position.z + Input.GetAxis("Vertical") * mainCameraVelocity;
        }
        characterCamera.transform.position = new Vector3(x ,y ,z);

        ////y = ( characterCamera.transform.position.y + y <= originalCameraPos.y ) ? characterCamera.transform.position.y - originalCameraPos.y : y;
        ////originalCameraPos = world.CurrentPlayer.Location + new Vector3(5 ,13 ,-6);
        ////if (!viewChangeable)
        ////{            
        ////    //characterCamera.transform.position = originalCameraPos;            
        ////}
        ////else
        //if ( viewChangeable )
        //{
        //    /*
        //    Vector3 m_p = characterCamera.ScreenToWorldPoint(Input.mousePosition);// Input.mousePosition;
        //    Vector3 x_p = characterCamera.ScreenToWorldPoint(new Vector3( characterCamera.pixelRect.xMax ,0 ,0));

        //    if ( Input.mousePosition.x > characterCamera.pixelRect.xMax - 10 || Input.mousePosition.x < characterCamera.pixelRect.xMin + 10 ||
        //        Input.mousePosition.y > characterCamera.pixelRect.yMax - 10 || Input.mousePosition.y < characterCamera.pixelRect.yMin + 10 )
        //    {
        //        Debug.Log("out of range "+m_p + " " + x_p);
        //    }
        //    else
        //    {
        //        Debug.Log("in range");
        //    }
        //    */

        //    x = Input.GetAxis("Horizontal") * mainCameraVelocity;
        //    //y = Input.GetAxis("Mouse ScrollWheel") * -1 * mainCameraVelocity * 10;
        //    z = Input.GetAxis("Vertical") * mainCameraVelocity;

        //    //Debug.Log(Input.GetAxis("Mouse ScrollWheel") + " " + y);
        //    /*y = (characterCamera.transform.position.y + y <= originalCameraPos.y ) ? characterCamera.transform.position.y - originalCameraPos.y : y;*///不要潛到地底下

        //    //characterCamera.transform.position += new Vector3(x ,y ,z);
        //}

    }


    public void displayBlockInformation(/*Block*/)
    {
        //Block...
    }
    public void displaPlayerInformation(Group player)
    {
        //Player...
    }


    /*====================================private================================================================*/
    //private void mainPanelMove()
    //{
    //    if ( mainPanelMoveable )
    //    {
    //        mainPanel.transform.position += new Vector3(0 ,mainPainelVelocity * Time.deltaTime ,0);

    //        if ( mainPanel.transform.position.y >= mainPainelMaxHight )
    //        {
    //            mainPanelMoveable = false;
    //            mainPanel.transform.position = new Vector3(mainPanel.transform.position.x
    //                                                       ,mainPainelMaxHight
    //                                                       ,mainPanel.transform.position.z);
    //            mainPainelVelocity *= -1;
    //            //collapseButton.transform.Find("Text").GetComponent<Text>().text = "▼";
    //        }
    //        else if ( mainPanel.transform.position.y <= mainPainelMinHight )
    //        {
    //            mainPanelMoveable = false;
    //            mainPanel.transform.position = new Vector3(mainPanel.transform.position.x
    //                                                       ,mainPainelMinHight
    //                                                       ,mainPanel.transform.position.z);
    //            mainPainelVelocity *= -1;
    //            //collapseButton.transform.Find("Text").GetComponent<Text>().text = "▲";
    //        }
    //    }
    //}
}
