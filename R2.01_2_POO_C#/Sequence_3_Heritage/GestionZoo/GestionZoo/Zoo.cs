using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    public class Zoo
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

        public string PresenteSesAnimaux()
        {
            string res = "";
            foreach (Animal a in LesAnimaux)
            {
                res += a + "\n---------------------------------------------\n";
            }
            return res;
        }

        internal string FaitCrierSesAnimaux()
        {
            string res = "";
            foreach (Animal a in LesAnimaux)
            {
                res += $"{a.Nom} : {a.Cri()}\n";
            }
            return res;
        }

        internal Animal Recherche(string? nom)
        {
            return LesAnimaux.Find(x => x.Nom == nom);
        }

        public string NourritUnAnimal(Animal a)
        {
            if (a is IHerbivore)
            {
                return $"{a.Nom} mange {((IHerbivore)a).QteHerbeJour()} {Animal.UM_POIDS} de {((IHerbivore)a).HerbePreferee()} par jour";
            }
            if (a is ICarnivore)
            {
                return $"{a.Nom} mange {((ICarnivore)a).NbProieSemaine()} {((ICarnivore)a).ProiePreferee()} par semaine";
            }
            else
            {
                return "";
            }
        }

        internal string Tuerie(Animal carnivore)
        {
            if (!(carnivore is ICarnivore))
            {
                return $"{carnivore.Nom} n'est pas un animal carnivore du zoo !";
            }
            else
            {
                return $"pour tuer ses proies, {carnivore.Nom} {((ICarnivore)carnivore).Tue()}";
            }
        }

        internal void SupprimeAnimal(Animal animalASupprimer)
        {
            LesAnimaux.Remove(animalASupprimer);
        }

        public void TrieParAge()
        {
            LesAnimaux.Sort((x, y) => (x.Age).CompareTo(y.Age));
        }
    }
}
