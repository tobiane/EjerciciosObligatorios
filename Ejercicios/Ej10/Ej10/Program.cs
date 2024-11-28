﻿using System;
using System.Collections.Generic;

namespace ej10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carta> baraja = new List<Carta>
            {
                new Carta(1, "Oro"), new Carta(2, "Oro"), new Carta(3, "Oro"), new Carta(4, "Oro"),
                new Carta(5, "Oro"), new Carta(6, "Oro"), new Carta(7, "Oro"), new Carta(10, "Oro"),
                new Carta(11, "Oro"), new Carta(12, "Oro"), new Carta(1, "Copa"), new Carta(2, "Copa"),
                new Carta(3, "Copa"), new Carta(4, "Copa"), new Carta(5, "Copa"), new Carta(6, "Copa"),
                new Carta(7, "Copa"), new Carta(10, "Copa"), new Carta(11, "Copa"), new Carta(12, "Copa"),
                new Carta(1, "Espada"), new Carta(2, "Espada"), new Carta(3, "Espada"), new Carta(4, "Espada"),
                new Carta(5, "Espada"), new Carta(6, "Espada"), new Carta(7, "Espada"), new Carta(10, "Espada"),
                new Carta(11, "Espada"), new Carta(12, "Espada"), new Carta(1, "Basto"), new Carta(2, "Basto"),
                new Carta(3, "Basto"), new Carta(4, "Basto"), new Carta(5, "Basto"), new Carta(6, "Basto"),
                new Carta(7, "Basto"), new Carta(10, "Basto"), new Carta(11, "Basto"), new Carta(12, "Basto")
            };

            int cantidad;
            Console.WriteLine("Cuantas cartas quiere pedir");
            cantidad = int.Parse(Console.ReadLine());


            Baraja barajaCom = new Baraja(baraja);

            barajaCom.Barajar();

            barajaCom.SiguienteCarta();

            Console.WriteLine("Repartiendo " + cantidad + " cartas:");
            barajaCom.DarCartas(cantidad);

            barajaCom.CartasDisponibles();
            barajaCom.CartasMonton();
            barajaCom.Mostrar();

            Console.ReadKey();
        }
    }

    public class Carta
    {
        public int Numero { get; set; }
        public string Palo { get; set; }

        public Carta(int numero, string palo)
        {
            Numero = numero;
            Palo = palo;
        }
    }

    public class Baraja
    {
        private List<Carta> cartas;
        private List<Carta> monton;

        public Baraja(List<Carta> barajaInicial)
        {
            cartas = new List<Carta>(barajaInicial);
            monton = new List<Carta>();
        }

        public void Barajar()
        {
            Random rnd = new Random();
            for (int i = cartas.Count - 1; i > 0; i--)
            {
                int random = rnd.Next(i + 1);
                Carta temp = cartas[i];
                cartas[i] = cartas[random];
                cartas[random] = temp;
            }
        }

        public void Mostrar()
        {
            if (cartas.Count == 0)
            {
                Console.WriteLine("No quedan cartas en la baraja.");
            }
            else
            {
                Console.WriteLine("Cartas en la baraja:");
                foreach (var carta in cartas)
                {
                    Console.WriteLine(carta.Numero + " de " + carta.Palo);
                }
            }
        }

        public void SiguienteCarta()
        {
            if (cartas.Count > 0)
            {
                var carta = cartas[0];
                Console.WriteLine("Sacaste: " + carta.Numero + " de " + carta.Palo);
                monton.Add(carta);
                cartas.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("La baraja está vacia");
            }
        }

        public void CartasDisponibles()
        {
            Console.WriteLine("Quedan " + cartas.Count + " cartas en la baraja");
        }

        public void DarCartas(int cantidad)
        {
            if (cartas.Count >= cantidad)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    var carta = cartas[0];
                    Console.WriteLine(carta.Numero + " de " + carta.Palo);
                    monton.Add(carta);
                    cartas.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("No hay suficientes cartas para repartir.");
            }
        }


        public void CartasMonton()
        {
            if (monton.Count == 0)
            {
                Console.WriteLine("No hay cartas en el montón.");
            }
            else
            {
                Console.WriteLine("Cartas que han salido:");
                foreach (var carta in monton)
                {
                    Console.WriteLine(carta.Numero + " de " + carta.Palo);
                }
            }
        }
    }
}
