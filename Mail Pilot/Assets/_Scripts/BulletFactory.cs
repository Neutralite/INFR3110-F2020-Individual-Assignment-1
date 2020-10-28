using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory
{
    private PlayerController playerController;
    private static BulletFactory m_bulletFactoryInstance = null;

    private BulletFactory()
    {
        Start();
    }

    public static BulletFactory Instance()
    {
        if(m_bulletFactoryInstance == null)
        {
            m_bulletFactoryInstance = new BulletFactory();
        }

        return m_bulletFactoryInstance;
    }

    public GameObject CreateBullet(Vector3 location = new Vector3())
    {
        var newBullet = MonoBehaviour.Instantiate(playerController.bullet, location, Quaternion.identity);
        newBullet.name = "Bullet " + newBullet.GetHashCode();
        return newBullet;
    }

    public GameObject CreatePopper(Vector3 location = new Vector3())
    {
        var newBullet = MonoBehaviour.Instantiate(playerController.popper, location, Quaternion.identity);
        newBullet.name = "Popper " + newBullet.GetHashCode();
        return newBullet;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

}
