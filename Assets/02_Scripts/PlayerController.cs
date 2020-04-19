using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //temp
    bool billy;
    //Movement
    public CharacterController controller;
    public GameObject menu3D;
   
    public float speed = 12f;
    public float gravity = 9.81f;
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
    float distance;
    public int distanceMax;
    float holdingTimer;
    public float holdingWait;

    static public bool verifEnterScene;
    static public int nbLvl;
    public int nbLvlDonePorte;
    private void Start()
    {
        if(verifEnterScene == true)
        {
            LoadTransform();
            verifEnterScene = false;
        }
    }

    void Update()
    {
        nbLvlDonePorte = nbLvl;
        bool pause = menu3D.GetComponent<SceneAndUI>().pause;
        if(pause == false)
        {
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
                if (hit.transform.gameObject.tag.Equals("Pickable"))
                {
                    selectedItem = hit.transform.gameObject;
                }
                else
                {
                    selectedItem = null;
                }
            }
            if (holdingTimer > 0)
            {
                holdingTimer -= Time.deltaTime;
            }
            if (selectedItem != null)
            {
                distance = Mathf.Sqrt(((selectedItem.transform.position.x - transform.position.x) * (selectedItem.transform.position.x - transform.position.x)) + ((selectedItem.transform.position.y - transform.position.y) * (selectedItem.transform.position.y - transform.position.y)) + ((selectedItem.transform.position.z - transform.position.z) * (selectedItem.transform.position.z - transform.position.z)));
                //distance = Vector3.Distance(transform.position, selectedItem.transform.position);
                if (distance <= distanceMax)
                {
                    if (isHolding == false)
                    {
                        if (Input.GetButtonDown("Interact"))
                        {
                            pickedItem = selectedItem;
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
                    if(verifEnterScene == false)
                    {
                        if (pickedItem.GetComponent<SpecialObject>().nbObjet == nbLvl + 1)
                        {
                            nbLvl += 1;
                            string sceneToLoad = pickedItem.GetComponent<SpecialObject>().sceneToLoad;
                            menu3D.GetComponent<SceneAndUI>().ActiveScene(sceneToLoad);
                            SaveTransform();
                            verifEnterScene = true;
                            menu3D.GetComponent<SceneAndUI>().SceneLoader(sceneToLoad);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Lilliputien"))
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            controller.stepOffset = 0.02f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Lilliputien"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            controller.stepOffset = 0.2f;
        }
    }
    public void SaveTransform()
    {
        Debug.Log("saved");
        SavingSystem.SaveData(this, menu3D.GetComponent<GameManager>(), menu3D.GetComponent<SceneAndUI>());
    }
    public void LoadTransform()
    {
        Debug.Log("loaded");
        SaveData data = SavingSystem.LoadData();

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
    }
}
