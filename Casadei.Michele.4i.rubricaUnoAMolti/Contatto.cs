using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casadei.Michele._4i.rubricaUnoAMolti
{
    public enum TipoContatto { nessuno, Email, Telefono, Web, Instagram }

    public class Contatto
    {
        public int IdPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Valore { get; set; }

        public Contatto() { }
        public Contatto(string r)
        {
            string[] values = r.Split(';');

            if(values.Count() != 3) 
            {
                throw new Exception("Le righe di contatti.csv devono essere di tre colonne");
            }
                

            if(int.TryParse(values[0], out int id) && Enum.TryParse(values[1], out TipoContatto c))
            {
                this.IdPersona = id;
                this.Tipo = c;
                this.Valore = values[2];
            }
        }
        public static Contatto MakeContatto(string r)
        {
            string[] values = r.Split(';');

            TipoContatto c;
            Enum.TryParse(values[1], out c);

            switch (c)
            {
                case TipoContatto.Email:
                    return new ContattoEmail(r);
                    break;
                case TipoContatto.Telefono:
                    return new ContattoTelefono(r);
                    break;
                case TipoContatto.Web:
                    return new ContattoWeb(r);
                    break;
                default:
                    return new Contatto(r);
                    break;
            }
            return new Contatto(r);
        }
    }
    public class ContattoEmail : Contatto
    {
        public ContattoEmail() { }
        public ContattoEmail(string r)
            : base(r) { }
    }
    public class ContattoTelefono : Contatto
    {
        public ContattoTelefono() { }
        public ContattoTelefono(string r)
            : base(r) { }
    }
    public class ContattoWeb : Contatto
    {
        public ContattoWeb() { }
        public ContattoWeb(string r)
            : base(r) { }
    }
    public class Contatti : List<Contatto>
    {
        public Contatti() { }

        public Contatti(string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(Contatto.MakeContatto((fin.ReadLine())));
            }
            fin.Close();
        }
    }
}
