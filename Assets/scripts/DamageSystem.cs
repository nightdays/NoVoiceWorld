using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    public int dmg = 0;

    public DamageType type = DamageType.Player;

    public void Hurt()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (type)
        {
            case DamageType.Player:
                DamagePlayer(col);
                break;
            case DamageType.Enemy:
                DamageEnemy(col);
                break;
            case DamageType.All:
                DamageAll(col);
                break;
            default: Destroy(gameObject); break;
        }
    }

    void DamagePlayer(Collider2D col)
    {
        if ("Player".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
            col.GetComponent<Player>().Hurt(dmg);
        }
        if ("wall".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
        }
    }

    void DamageEnemy(Collider2D col)
    {
        if ("Enemy".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
            col.GetComponent<Enemy>().Hurt(dmg);
        }
        if ("wall".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
        }
    }

    void DamageAll(Collider2D col)
    {
        if ("Player".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
            col.GetComponent<Player>().Hurt(dmg);
        }
        if ("Enemy".ToUpper().Equals(col.tag.ToUpper()))
        {
            Destroy(gameObject);
            col.GetComponent<Enemy>().Hurt(dmg);
        }
    }


    public enum DamageType
    {
        Player, Enemy, All
    }
}
