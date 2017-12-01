using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{

    public int dmg = 0;

    public DamageType type = DamageType.Player;

    public void  Hurt() {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch(type){
            case DamageType.Player : 
                if("Player".ToUpper().Equals(col.tag.ToUpper())){
                    col.GetComponent<Player>().Hurt(dmg);
                }
            break;
            case DamageType.Enemy : 
                if("Enemy".ToUpper().Equals(col.tag.ToUpper())){
                    col.GetComponent<Enemy>().Hurt(dmg);
                }
            break;
            case DamageType.All : 
                if("Player".ToUpper().Equals(col.tag.ToUpper())){
                    col.GetComponent<Player>().Hurt(dmg);
                }
                if("Enemy".ToUpper().Equals(col.tag.ToUpper())){
                    col.GetComponent<Enemy>().Hurt(dmg);
                }
            break;
        }
        DestroyObject(this);
    }

    public enum DamageType {
        Player,Enemy,All
    }
}
