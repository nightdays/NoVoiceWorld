using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOption : MonoBehaviour
{

    public Transform arrow;

    //选项数组
    public Transform[] buttons;

    // 这个属性用于决定箭头的位置
    public int selectedIndex;

    //世界管理器
    public World world;

    //移动箭头时的声音
    public AudioClip moveSound;
    //选定某一项，回车的声音
    public AudioClip okSound;


    // Use this for initialization
    void Start()
    {

        //获取世界管理器
        world = Object.FindObjectOfType<World>();

        //默认情况下，箭头指向第一个位置
        selectedIndex = 0;

        //初始化设置箭头位置
        UpdateArrowPosition();

    }

    void Update()
    {
        //切换
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            //按键播放声音
            world.sound.PlaySE(moveSound);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            world.sound.PlaySE(moveSound);
        }

        //回车键
        if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log(selectedIndex);
            switch(selectedIndex) {
                //开始
                case 0: 
                Game.ScreenUI().FadeAndGo("GameScreen");
                this.enabled  = false;
                break;
                //继续
                case 1:
                break;
                //退出 调用下面的方法就是退出程序 固定写法 但在编辑器中无法测试 只有编译之后才能使用
                case 2: Application.Quit();
                break;
            }
        }

        selectedIndex = Mathf.Clamp(selectedIndex, 0, 2);
        UpdateArrowPosition();
    }

    void UpdateArrowPosition()
    {
        Vector3 newPosition = new Vector3(buttons[selectedIndex].position.x - 1f, buttons[selectedIndex].position.y, arrow.position.z);
        arrow.position = newPosition;
    }
}
