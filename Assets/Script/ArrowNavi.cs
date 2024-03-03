using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowNavi : MonoBehaviour
{
    // 다른 오브젝트의 자식 오브젝트 리스트를 저장할 변수
    
    private void Awake()
    {
        
    }
    void Update()
    {
    
        transform.LookAt(AudioManager.instance.minDisRat);
    }
    
}