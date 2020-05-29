using System;
using UnityEngine;

namespace DeadBreach.ECS.MonoBehaviours
{
    public class SkillBarManager : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSkill(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSkill(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSkill(2);
            if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSkill(3);
            if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSkill(4);
            if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSkill(5);
            if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSkill(6);
            if (Input.GetKeyDown(KeyCode.Alpha8)) SelectSkill(7);
            if (Input.GetKeyDown(KeyCode.Alpha9)) SelectSkill(8);
            if (Input.GetKeyDown(KeyCode.Alpha0)) SelectSkill(9);
        }

        public void OnSkillButtonPressed(int index) => SelectSkill(index);

        private static void SelectSkill(int index)
        {
            Debug.Log($"SkillBarManager : SelectSkill : {index}");
            //if player has skill[index]
            //if skill[index] has active effect
            //if skill[index] is not selected
            //mark skill[index] as selected
            //else
            //unmark skill[index] as selected
        }
    }
}
