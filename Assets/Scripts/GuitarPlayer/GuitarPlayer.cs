//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GuitarPlayer : MonoBehaviour
//{
//    public Animation anim;
//    public AnimationClip firstClip;
//    public AnimationClip secondClip;
//    private bool isPlayingFirstClip = true;

//    private void Start()
//    {
//        // P�ehraj prvn� anima�n� klip
//        anim.clip = firstClip;
//        anim.Play();
//        StartCoroutine(SwitchAnimation());
//    }

//    private IEnumerator SwitchAnimation()
//    {
//        while (true)
//        {
//            // Po�kej 5 sekund
//            yield return new WaitForSeconds(5f);

//            // P�epni na druh� klip a p�ehraj ho
//            if (isPlayingFirstClip)
//            {
//                anim.clip = secondClip;
//                anim.Play();
//            }
//            // P�epni zp�t na prvn� klip a p�ehraj ho
//            else
//            {
//                anim.clip = firstClip;
//                anim.Play();
//            }

//            // Zm�� hodnotu isPlayingFirstClip
//            isPlayingFirstClip = !isPlayingFirstClip;
//        }
//    }
//}