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
//        // Pøehraj první animaèní klip
//        anim.clip = firstClip;
//        anim.Play();
//        StartCoroutine(SwitchAnimation());
//    }

//    private IEnumerator SwitchAnimation()
//    {
//        while (true)
//        {
//            // Poèkej 5 sekund
//            yield return new WaitForSeconds(5f);

//            // Pøepni na druhý klip a pøehraj ho
//            if (isPlayingFirstClip)
//            {
//                anim.clip = secondClip;
//                anim.Play();
//            }
//            // Pøepni zpìt na první klip a pøehraj ho
//            else
//            {
//                anim.clip = firstClip;
//                anim.Play();
//            }

//            // Zmìò hodnotu isPlayingFirstClip
//            isPlayingFirstClip = !isPlayingFirstClip;
//        }
//    }
//}