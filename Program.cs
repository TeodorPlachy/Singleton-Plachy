using System;
using System.Runtime.InteropServices;

namespace Singleton{

    public class Singleton
    {
        // Statické pole pro uložení jediné instance třídy
        private static Singleton instance = null;
        // Zámek pro zajištění bezpečnosti vláken
        private static readonly object padlock = new object();
        // Soukromý konstruktor, aby nedošlo k vytvoření instance zvenčí
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }

                    return instance;
                }
            }
        }
        // Příklad metody v Singletonu
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is working.");
        }
    }

    class Program
    {
        static void Main(string[] args){
            // Získání instance Singletonu a volání metody
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();
            // Získání další instance Singletonu a volání metody
            Singleton anotherSingleton = Singleton.Instance;
            anotherSingleton.DoSomething();
            // Ověření, že obě instance jsou shodné
            if (singleton == anotherSingleton)
            {
                Console.WriteLine("Both instances are the same.");
            }
        }
    }
    
    
}