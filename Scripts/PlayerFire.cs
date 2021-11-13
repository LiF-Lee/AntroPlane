using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public GameObject fireSkill;
    private GameObject coolTimeViewer;

    public float E_SkillCoolTime = 10.0f;

    private bool canUse_E = true;

    private void Start()
    {
        coolTimeViewer = fireSkill.transform.Find("Skill Delay").gameObject;
    }

    void Update()
    {
        checkPlayerFire();
    }

    private void skillCoolTimeInit()
    {
        canUse_E = false;
        coolTimeViewer.SetActive(true);
        Image fillArea = coolTimeViewer.GetComponent<Image>();
        Text counter = coolTimeViewer.transform.Find("Text").gameObject.GetComponent<Text>();
        StartCoroutine(DecreseCoolTime(fillArea, counter));
    }

    IEnumerator DecreseCoolTime(Image viewer, Text counter)
    {
        if (viewer != null)
        {
            float timer = E_SkillCoolTime;
            Debug.Log(timer);
            float timeSlice = (viewer.fillAmount / E_SkillCoolTime) / 10;
            while (viewer.fillAmount >= 0)
            {
                viewer.fillAmount -= timeSlice;
                counter.text = string.Format("{0:F1}s", timer);
                timer -= 0.1f;
                yield return new WaitForSeconds(0.1f);
                if (viewer.fillAmount <= 0)
                {
                    canUse_E = true;
                    coolTimeViewer.SetActive(false);
                    viewer.fillAmount = 1;
                    break;
                }
            }
        }
        yield return null;
    }

    void checkPlayerFire()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activate_E_skill();
        }
    }

    void activate_E_skill()
    {
        if (canUse_E)
        {
            skillCoolTimeInit();
            GameObject bullet_L = Instantiate(bulletFactory);
            GameObject bullet_R = Instantiate(bulletFactory);
            GameObject bullet_L2 = Instantiate(bulletFactory);
            GameObject bullet_R2 = Instantiate(bulletFactory);

            bullet_L.transform.position = transform.position + new Vector3(-2, 2, 0);
            bullet_R.transform.position = transform.position + new Vector3(2, 2, 0);
            bullet_L2.transform.position = transform.position + new Vector3(-3, -1, 0);
            bullet_R2.transform.position = transform.position + new Vector3(3, -1, 0);
        }
    }
}
