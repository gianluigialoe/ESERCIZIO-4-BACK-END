using System;


namespace ESERCIZIO_4_BACK_END
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool utenteLoggato = false;
            string nomeUtente = null;

            while (true)
            {
                Console.WriteLine("1.: Login");
                Console.Write("Inserisci il nome utente: ");
                nomeUtente = Console.ReadLine();
                Utente.MetodoLogin(nomeUtente);
                Console.Clear();
                Console.WriteLine($"Login effettuato per {nomeUtente}");

                bool ricominciaCicloLogin = false;

                do
                {
                    Console.WriteLine("2.: Logout");
                    Console.WriteLine("3.: Verifica ora e data di login");
                    Console.WriteLine("4.: Lista degli accessi");
                    Console.WriteLine("5.: Esci");

                    string scelta = Console.ReadLine();

                    switch (scelta)
                    {
                        case "2":
                            Console.WriteLine($"Logout effettuato per {nomeUtente}");
                            utenteLoggato = true;
                            ricominciaCicloLogin = false;
                            break;

                        case "3":
                            Console.WriteLine("Hai scelto Verifica ora e data di login");
                            Utente.VerificaOraDataLogin();
                            ricominciaCicloLogin = true;
                            break;

                        case "4":
                            Console.WriteLine("Hai scelto Lista degli accessi");
                            Utente.MostraListaAccessi();
                            ricominciaCicloLogin = true;
                            break;

                        case "5":
                            Console.WriteLine("Hai scelto Esci");
                            return;

                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            ricominciaCicloLogin = true;
                            break;
                    }

                } while (ricominciaCicloLogin);
            }
        }
    }

    public static class Utente
    {
        public static List<string> ListaAccessi = new List<string>();

        public static void MetodoLogin(string nomeUtente)
        {
            bool accessoRiuscito = false;

            do
            {
                Console.Write("Inserisci la password: ");
                string password = Console.ReadLine();

                Console.Write("Conferma la password: ");
                string confermaPassword = Console.ReadLine();

                if (password == confermaPassword)
                {
                    Console.WriteLine($"Accesso riuscito per {nomeUtente}");
                    accessoRiuscito = true;

                    AggiungiAccesso($"Login effettuato per {nomeUtente}");
                }
                else
                {
                    Console.WriteLine("Le password non corrispondono. Accesso fallito.");
                    accessoRiuscito = false;
                }
            } while (!accessoRiuscito);
        }

        public static void VerificaOraDataLogin()
        {
            DateTime oraDataLogin = DateTime.Now;
            Console.WriteLine($"Ora e data di login: {oraDataLogin}");
        }

        public static void AggiungiAccesso(string accesso)
        {
            ListaAccessi.Add(accesso);
        }

        public static void MostraListaAccessi()
        {
            Console.WriteLine("Lista degli accessi:");
            foreach (var accesso in ListaAccessi)
            {
                Console.WriteLine(accesso);
            }
        }
    }
}

