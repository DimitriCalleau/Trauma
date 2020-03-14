[System.Serializable]
public class SaveData
{
    //Joueur
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    
    //Objet
    public float objetX;
    public float objetY;
    public float objetZ;
    public string objet;

    //Avancement
    public int lvlAvancement;
    public int nbDeaths;

    public SaveData(PlayerController playerCtrl, GameManager gameManager)
    {

        lvlAvancement = gameManager.nbLvlDone;
        //Objet
        if(playerCtrl.pickedItem != null)
        {
            objet = playerCtrl.pickedItem.name;
        }

        //Player
        positionX = playerCtrl.transform.position.x;
        positionY = playerCtrl.transform.position.y;
        positionZ = playerCtrl.transform.position.z;
        rotationX = playerCtrl.transform.localRotation.x;
        rotationY = playerCtrl.transform.localRotation.y;
        rotationZ = playerCtrl.transform.localRotation.z;
    }
}