using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D.Animation;
using UnityEngine.UI;

namespace Completed
{
    public class SwitchPart : MonoBehaviour
    {
        [SerializeField] BodyParts[] bodyParts;
        [SerializeField] string[] labels;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].Init(labels);
            }
        }
    }

    [System.Serializable]
    public class BodyParts
    {
        [SerializeField] Button button;
        [SerializeField] SpriteResolver[] spriteResolver;
        public int id;

        public SpriteResolver[] SpriteResolver { get => spriteResolver; }

        //method to init the button callback
        public void Init(string[] labels)
        {
            if (button != null)
            {
                button.onClick.AddListener(delegate { SwitchParts(labels); });
            }
            else
            {
                Debug.LogWarning("Button reference is not assigned for BodyParts: " + id);
            }
        }

        //method that are going to be triggered by the button, and it will switch the sprites of each resolver list.
        public void SwitchParts(string[] labels)
        {
            id++;
            id = id % labels.Length;

            // Store the selected weapon in PlayerPrefs
            PlayerPrefs.SetInt("SelectedWeapon", id);
            PlayerPrefs.Save();

            foreach (var item in spriteResolver)
            {
                Debug.Log(item.GetCategory() + " " + labels[id] + " " + id);
                item.SetCategoryAndLabel(item.GetCategory(), labels[id]);
            }
        }
    }
}
