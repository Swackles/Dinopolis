using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Triggers.Children
{
    class SpawnDinosaurs : TextBox, IChild
    {
        [SerializeField]
        GameObject[] Locations = null;

        public void Action()
        {
            GameObject Dinosaur = Resources.Load("Prefabs/Dinosaur") as GameObject;
            
            foreach (GameObject Location in Locations)
            {
                GameObject instance = Instantiate(Dinosaur, Location.transform.position, Quaternion.identity);
                instance.transform.rotation = Location.transform.rotation;
                instance.transform.localScale = Location.transform.localScale;
            }

            base.Action();
        }
    }
}
