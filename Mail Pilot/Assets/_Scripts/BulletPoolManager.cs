using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPoolManager
{
    private PlayerController playerController;
    private static BulletPoolManager m_bulletPoolInstance = null;

    //a structure to contain a collection of bullets
    private Queue<GameObject> m_BulletPool;

    private BulletPoolManager()
    {
        Start();
    }

    public static BulletPoolManager Instance()
    {
        if (m_bulletPoolInstance == null)
        {
            m_bulletPoolInstance = new BulletPoolManager();
        }

        return m_bulletPoolInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();

        m_BulletPool = new Queue<GameObject>();
        
        //adds a series of bullets to the Bullet Pool
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for (var count = 0; count < playerController.MaxBullets; count++)
        {
            var tempBullet = BulletFactory.Instance().CreateBullet();
            tempBullet.SetActive(false);
            m_BulletPool.Enqueue(tempBullet);
        }
    }

    //This function returns a bullet from the Pool
    public GameObject GetBullet()
    {
        if (BulletPoolEmpty())
        {
            return BulletFactory.Instance().CreateBullet();
        }
        var tempBullet = m_BulletPool.Dequeue();
        tempBullet.SetActive(true);
        return tempBullet;
    }

    //this function resets/returns a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        m_BulletPool.Enqueue(bullet);
    }

    //returns pool size
    public int BulletPoolSize()
    {
        return m_BulletPool.Count;
    }

    // checks if the pool is empty
    public bool BulletPoolEmpty()
    {
        if (m_BulletPool.Count == 0)
        {
            return true;
        }
        return false;
    }
}
