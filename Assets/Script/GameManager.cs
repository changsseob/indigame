using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    


    [SerializeField]
    public bool mode; // false  = 사격,  true = 빌드 , Player 에서 컨트롤함.
    public bool isPanelOff = true;
    public UnityEngine.Camera mainCamera; //Ray용 메인카메라
    [SerializeField]
    public List<GameObject> MAP = new List<GameObject>();
    public GameObject BuildPanel;



    //싱글톤용 코드.
    private static GameManager Instance = null;
    public static GameManager instance
    {
        get
        { return Instance; }
        set { }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //빌드모드 && 마우스인풋
        if (Input.GetMouseButtonDown(0) && mode && isPanelOff)
        {
            Ray ray = (UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition));
            //RaycastHit2D hit = Physics.Raycast(mainCamera.transform.position, , out hit, 30.0F);
            //Physics2D.Raycast(mainCamera.transform.position, UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity,              1 << LayerMask.NameToLayer("MAP"));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                Debug.Log("감지" + hit.transform.name);
                GameObject temp = hit.transform.gameObject;
                
                foreach (GameObject g in MAP)
                {
                    if(g.transform.position == hit.transform.position)
                    {
                        g.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1);
                        BuildPanel.SetActive(true);
                        isPanelOff = false;
                    }
                    else
                    {
                        g.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 10);
                    }
                }
            }
            //if (hit.collider != null)
            //{

             //   Debug.Log("감지"+hit.transform.name);

           // }

        }

    }
    public void FixPanelOn()
    {
        isPanelOff = false;
    }
    public void cancelFix()
    {
        foreach (GameObject g in MAP)
        {
            isPanelOff = true;
            g.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 10);
        }
    }

}
