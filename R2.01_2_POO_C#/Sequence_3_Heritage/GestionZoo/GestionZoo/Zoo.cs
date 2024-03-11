using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    internal class Zoo
    {
        List<Animal> lesAnimaux;

        public Zoo(List<Animal> lesAnimaux)
        {
            this.LesAnimaux = lesAnimaux;
        }
        public Zoo()
        {
            this.LesAnimaux = new List<Animal>();
        }

        public List<Animal> LesAnimaux
        {
            get
            {
                return this.lesAnimaux;
            }

            set
            {
                this.lesAnimaux = value;
            }
        }
    }
}
