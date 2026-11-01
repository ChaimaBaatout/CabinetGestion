using System.Collections.Generic;

namespace CabinetGestion.Models
{
    public class Specialite
    {
        private int id;
        private string nomSpecialite;
        public virtual ICollection<Medecin> medecinList { get; set; }

        public Specialite(int id, string nomSpecialite)
        {
            this.Id = id;
            this.nomSpecialite = nomSpecialite;
        }

        public Specialite():base()
        {

        }

        public int Id { get => id; set => id = value; }
        public string NomSpecialite { get => nomSpecialite; set => nomSpecialite = value; }
        // public ICollection<Medecin> MedecinList { get => medecinList; set => medecinList = value; }
    }
}
