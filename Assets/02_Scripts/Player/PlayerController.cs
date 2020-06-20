using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //temp
    bool loading;
    //Movement
    public CharacterController controller;
    public GameObject menu3D;

    public float speed;
    public float gravity;
    Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public bool isGrounded;

    //Pickup
    bool isHolding;
    GameObject selectedItem;
    public GameObject pickedItem;
    public GameObject tempParent;
    public AudioSource grab;

    //UI
    public GameObject uiPorte;
    public GameObject uiGrab;
    float distancesSelection;

    float holdingTimer;
    public float holdingWait;
    float distance;
    public float distanceMax;
    public bool verifEnterScene;
    public int nbLvlDonePorte;

    private void Start()
    {
        if (PlayerPrefs.HasKey("saved") == true)
        {

            StartCoroutine(LoadingButBetter());
        }
        speed = 3f;
        uiPorte.SetActive(false);
        uiGrab.SetActive(false);
    }

    void Update()
    {
        nbLvlDonePorte = menu3D.GetComponent<GameManager>().nbLvlDone;
        bool pause = menu3D.GetComponent<SceneAndUI>().pause;
        bool end = menu3D.GetComponent<SceneAndUI>().end;
        if(end == false)
        {
            if (pause == false)
            {
                if (PlayerPrefs.HasKey("saved") == true)
                {
                    if (loading == false)
                    {
                        StartCoroutine(LoadingButBetter());
                    }
                }

                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if (isGrounded == true && velocity.y < 0)
                {
                    velocity.y = -2f;
                }

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;
                velocity.y -= gravity * Time.deltaTime;

                controller.Move(move * speed * Time.deltaTime);
                controller.Move(velocity * Time.deltaTime);

                //Pickup
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag.Equals("Fin"))
                    {
                        GameObject tableau;
                        tableau = hit.transform.gameObject;
                        if (Vector3.Distance(transform.position, tableau.transform.position) < distanceMax)
                        {
                            uiGrab.SetActive(true);

                            if (Input.GetButtonDown("Interact"))
                            {
                                menu3D.GetComponent<SceneAndUI>().End();
                                uiGrab.SetActive(false);
                            }
                        }
                        else
                        {
                            uiGrab.SetActive(false);
                        }
                    }

                    if (hit.transform.gameObject.tag.Equals("Pickable"))
                    {
                        selectedItem = hit.transform.gameObject;
                        if (Vector3.Distance(transform.position, selectedItem.transform.position) < distanceMax)
                        {
                            if (isHolding == false)
                            {
                                uiGrab.SetActive(true);
                            }
                            else
                            {
                                uiGrab.SetActive(false);
                            }
                        }
                        else
                        {
                            uiGrab.SetActive(false);
                        }
                    }
                    else
                    {
                        selectedItem = null;
                        uiGrab.SetActive(false);
                    }

                    if (hit.transform.gameObject.tag.Equals("Porte"))
                    {
                        if (hit.distance <= 1.5)
                        {
                            uiPorte.SetActive(true);
                            if (Input.GetButtonDown("Interact"))
                            {
                                hit.transform.gameObject.GetComponent<Overture_Porte>().Open();
                            }
                        }
                        else
                        {
                            uiPorte.SetActive(false);
                        }
                    }
                    else
                    {
                        uiPorte.SetActive(false);
                    }
                }
                if (holdingTimer > 0)
                {
                    holdingTimer -= Time.deltaTime;
                }
                if (selectedItem != null)
                {
                    distance = Vector3.Distance(selectedItem.transform.position, transform.position);

                    if (distance <= distanceMax)
                    {
                        if (isHolding == false)
                        {
                            if (Input.GetButtonDown("Interact"))
                            {
                                pickedItem = selectedItem;
                                grab.Play();
                                uiGrab.SetActive(false);
                                pickedItem.transform.SetParent(tempParent.transform);
                                pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                                pickedItem.transform.position = tempParent.transform.position;
                                holdingTimer = holdingWait;
                                isHolding = true;
                            }
                        }
                    }
                }
                if (isHolding == true)
                {
                    if (Input.GetButton("Interact") && holdingTimer <= 0)
                    {
                        pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                        pickedItem.transform.SetParent(null);
                        isHolding = false;
                        pickedItem = null;
                    }
                }
                if (pickedItem != null)
                {
                    if (pickedItem.layer.ToString() == "11")
                    {
                        if (verifEnterScene == false)
                        {
                            if (pickedItem.GetComponent<SpecialObject>().nbObjet == menu3D.GetComponent<GameManager>().nbLvlDone + 1)
                            {

                                string sceneToLoad = pickedItem.GetComponent<SpecialObject>().sceneToLoad;
                                menu3D.GetComponent<SceneAndUI>().ActiveScene(sceneToLoad);
                                StartCoroutine(SaveBeforeSceneChange());
                                SaveTransform();
                                if (menu3D.GetComponent<GameManager>().nbLvlDone == 2)
                                {
                                    SaveBureau();
                                    verifEnterScene = true;
                                    menu3D.GetComponent<SceneAndUI>().SceneLoader(sceneToLoad);
                                }
                                else
                                {
                                    SaveTransform();
                                    verifEnterScene = true;
                                    menu3D.GetComponent<SceneAndUI>().SceneLoader(sceneToLoad);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator SaveBeforeSceneChange()
    {
        SaveTransform();
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator Grow()
    {
        float growFactor = 0.05f;
        while (transform.localScale.x < 1)
        {
            transform.localScale = new Vector3(transform.localScale.x + growFactor, transform.localScale.y + growFactor, transform.localScale.z + growFactor);
            yield return new WaitForSeconds(0.05f);
        }
        controller.stepOffset = 0.2f;
        speed = 3f;
    }
    IEnumerator Ungrow()
    {
        float growFactor = 0.05f;
        while (transform.localScale.x > 0.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x - growFactor, transform.localScale.y - growFactor, transform.localScale.z - growFactor);
            yield return new WaitForSeconds(0.05f);
        }
        
        controller.stepOffset = 0.02f;
        speed = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Lilliputien"))
        {
            if(menu3D.GetComponent<GameManager>().nbLvlDone < 3)
            {
                StartCoroutine(Ungrow());
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Lilliputien"))
        {
            if (menu3D.GetComponent<GameManager>().nbLvlDone < 3)
            {
                StartCoroutine(Grow());
            }
        }
    }

    public void SaveTransform()
    {
        PlayerPrefs.SetInt("saved", 1);
        PlayerPrefs.SetFloat("positionX", transform.position.x);
        PlayerPrefs.SetFloat("positionY", transform.position.y);
        PlayerPrefs.SetFloat("positionZ", transform.position.z);
        if(pickedItem != null)
        {
            PlayerPrefs.SetString("pickedItem", pickedItem.name);
        }
        else
        {
            PlayerPrefs.DeleteKey("pickedItem");
        }
        PlayerPrefs.SetInt("nbLvlDone", menu3D.GetComponent<GameManager>().nbLvlDone);
        PlayerPrefs.SetString("activeScene", menu3D.GetComponent<SceneAndUI>().activeScene);
        /*
        Debug.Log("Save");
        SavingSystem.SaveData(this, menu3D.GetComponent<GameManager>(), menu3D.GetComponent<SceneAndUI>());*/
    }
    public void SaveBureau()
    {
        PlayerPrefs.SetInt("saved", 1);
        PlayerPrefs.SetFloat("positionX", transform.position.x);
        PlayerPrefs.SetFloat("positionY", transform.position.y + 0.5f);
        PlayerPrefs.SetFloat("positionZ", transform.position.z + 2);
        if(pickedItem != null)
        {
            PlayerPrefs.SetString("pickedItem", pickedItem.name);
        }
        else
        {
            PlayerPrefs.DeleteKey("pickedItem");
        }
        PlayerPrefs.SetInt("nbLvlDone", menu3D.GetComponent<GameManager>().nbLvlDone);
        PlayerPrefs.SetString("activeScene", menu3D.GetComponent<SceneAndUI>().activeScene);
    }
    public void LoadTransform()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"), PlayerPrefs.GetFloat("positionZ"));

        if (PlayerPrefs.HasKey("pickedItem"))
        {
            pickedItem = GameObject.Find(PlayerPrefs.GetString("pickedItem"));
        }

        if (pickedItem != null)
        {
            pickedItem.transform.SetParent(tempParent.transform);
            pickedItem.GetComponent<Rigidbody>().isKinematic = true;
            pickedItem.transform.position = tempParent.transform.position;
            isHolding = true;
        }

        menu3D.GetComponent<GameManager>().nbLvlDone = PlayerPrefs.GetInt("nbLvlDone");
        menu3D.GetComponent<SceneAndUI>().ActiveScene(PlayerPrefs.GetString("activeScene"));

        loading = true;
        /*
        SaveData data = SavingSystem.LoadData();
        Debug.Log("Load");
        menu3D.GetComponent<GameManager>().nbLvlDone = data.lvlAvancement;
        
        //position joueur
        transform.position = new Vector3(data.positionX, data.positionY, data.positionZ);
        transform.localRotation = Quaternion.Euler(data.rotationX, data.rotationY, data.rotationZ);

        //objet re dans les mains
        pickedItem = GameObject.Find(data.objet);

        if(pickedItem != null)
        {
            pickedItem.transform.SetParent(tempParent.transform);
            pickedItem.GetComponent<Rigidbody>().isKinematic = true;
            pickedItem.transform.position = tempParent.transform.position;
            isHolding = true;
        }

        string activeSceneName = data.scene;
        menu3D.GetComponent<SceneAndUI>().ActiveScene(activeSceneName);
        */
    }

    IEnumerator LoadingButBetter()
    {
        int repeatJustInCase = 0;
        while (repeatJustInCase < 2)
        {
            LoadTransform();
            yield return new WaitForSeconds(0.2f);
            repeatJustInCase += 1;
        }

    }
}
