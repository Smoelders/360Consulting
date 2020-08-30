namespace _ParkhausSimulation
{
    /// <summary>
    /// Wir erzeugen eine Klasse 'Fahrzeuge', diese ermöglicht es uns, die ID an alle Fahrzeugtypen zu vererben. 
    /// Bei zwei Klassen, könnten wir die ID auch manuell in jede Sub-Class setzen, jedoch erspart uns die Vererbung weitere Arbeitsschritte beim hinzufügen weiterer Fahrzeugtypen.
    /// Die ID wird als String deklariert, weil ein Nummernschild sowohl aus Zahlen als auch aus Buchstaben besteht.
    /// </summary>

    public abstract class Fahrzeuge
    {
        public string Id { get; private set; }

        protected Fahrzeuge(string id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
