using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowNavi : MonoBehaviour
{
    // �ٸ� ������Ʈ�� �ڽ� ������Ʈ ����Ʈ�� ������ ����
    
    private void Awake()
    {
        
    }
    void Update()
    {
    
        transform.LookAt(AudioManager.instance.minDisRat);
    }
    
}