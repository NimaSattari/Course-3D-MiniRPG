using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;

        private void OnTriggerEnter(Collider other)
        {
            if (dialogue == null)
            {
                return;
            }
            other.GetComponent<PlayerConversant>().StartDialogue(this, dialogue);
        }

        public string GetName()
        {
            return conversantName;
        }
    }
}