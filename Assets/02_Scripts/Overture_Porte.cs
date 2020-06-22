using UnityEngine;

public class Overture_Porte : MonoBehaviour
{
    public int lvlToUnlock;
    public int NblvlDone;
    public GameObject menu;

    bool opened;
    public Animator animator;
    public AudioSource soundOuvrir;
    public AudioSource soundFermer;

    //PorteViolet;
    public AudioSource soundLock;
    public GameObject Porte;

    // Start is called before the first frame update
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(menu == true)
        {
            NblvlDone = menu.GetComponent<GameManager>().nbLvlDone;
        }
        else
        {
            NblvlDone = 0;
        }

    }

    public void Open()
    {
        if (NblvlDone >= lvlToUnlock)
        {
            if (opened == false)
            {
                animator.SetBool("Open", true);
                if(soundOuvrir != null && soundFermer != null)
                {
                    soundFermer.Stop();
                    soundOuvrir.Play();
                }
                opened = true;
            }
            else
            {
                animator.SetBool("Open", false);
                if (soundOuvrir != null && soundFermer != null)
                {
                    soundOuvrir.Stop();
                    soundFermer.Play();
                }
                opened = false;
            }
        }
        else
        {
            if(soundLock != null)
            {
                soundLock.Play();
            }
        }
    }
}
