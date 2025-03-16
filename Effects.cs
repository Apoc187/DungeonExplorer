using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer
{
    public class AttackEffects
    {
        public void Null(string EffectName, int Intensity, int Duration, string Description)
        {
        }

        public void Attack1(string EffectName, int Intensity, int Duration, string Description)
        {
        }

    }
    public class ItemEffects
    {
        public void Null(string EffectName, int Intensity, int Duration, string Description)
        {
        }

        public void Consume(string EffectName, int Intensity, int Duration, string Description)
        {
            Player.Instance.Energy += Intensity;
        }
    }
}

//unused script