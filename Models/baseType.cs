using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pipliz.JSON;
using UnityEngine;
using MoreDecorations.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Pipliz.JSON;
using UnityEngine;

namespace MoreDecorations.Models
{
    public class baseType
    {
        //ICSNACH0Type ICSType { get; set; }
        public string icon { get; set; }
        public bool isSolid { get; set; }
        public int maxStackSize { get; set; }
        public string mesh { get; set; }
        public bool needsBase { get; set; }
        public string onPlaceAudio { get; set; }
        public string onRemoverAudio { get; set; }
        public string sideall { get; set; }
        Colliders colliders { get; }
        [JsonIgnore]
        JSONNode customData { get; }
        List<string> categories { get; }

        /*public class Boxes
        {
            public List<float> min { get; set; }
            public List<float> max { get; set; }

            public Boxes() { }

            public Boxes(List<float> minCollide, List<float> maxCollide)
            {
                min = minCollide;
                max = maxCollide;
            }
        }

        public bool collidePlayer { get; set; }
        public bool collideSelection { get; set; }
        public List<Boxes> boxes { get; set; } = new List<Boxes>();

        public Colliders() { }

        public Colliders(bool colideplayer, bool collideselection, List<Boxes> collider)
        {
            collidePlayer = colideplayer;
            collideSelection = collideselection;
            boxes = collider;
        }*/
    }
}
