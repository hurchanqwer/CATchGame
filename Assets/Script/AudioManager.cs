using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public static AudioManager instance;

    // 다른 오브젝트의 자식 오브젝트 리스트를 저장할 변수
   
    public Transform arrow;
    public float minDis = 0;
    public Vector3 minDisRat;
    float Dis; 
    private void Awake()
    {
        instance = this;
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        arrow.LookAt(AudioManager.instance.minDisRat);
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
    private void LateUpdate()
    {
        RatScan();
    }

    public void RatScan()
    {
        Transform otherObjectTransform = GameObject.Find("RatList").transform;
        foreach (Transform child in otherObjectTransform)
        {
            Dis = Mathf.Abs(Vector3.Distance(transform.position, child.position));

            if (minDis == 0)
            {
                minDis = Dis;
                minDisRat = child.position;
            }
            else if (minDis > Dis)
            {
                minDis = Dis;
                minDisRat = child.position;
            }
        }

    }
}

