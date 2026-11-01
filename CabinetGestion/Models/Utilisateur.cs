namespace CabinetGestion.Models
{
    public class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
        public static int nbUtilisateur;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }

        public Utilisateur(int id, string nom, string prenom, string email, string mdp)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;
            nbUtilisateur++;
        }

        public Utilisateur()
        {
            nbUtilisateur++;
        }

        public Utilisateur(Utilisateur u)
        {
            this.id = u.Id;
            this.nom = u.Nom;
            this.prenom = u.Prenom;
            this.Email = u.Email;
            this.mdp = u.mdp;
            nbUtilisateur++;
        }
    }
}
