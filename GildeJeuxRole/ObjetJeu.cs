namespace Guildes
{
    public class ObjetJeu
    {
        private string _nomObjet;
        private double _valeur;
        private double _poids;

        public string NomObjet { get => _nomObjet; set => _nomObjet = value; }
        public double Valeur { get => _valeur; set => _valeur = value; }
        public double Poids { get => _poids; set => _poids = value; }
    }
}