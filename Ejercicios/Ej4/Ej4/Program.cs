﻿using System;

namespace Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico[] electrodomesticos = new Electrodomestico[10];


            electrodomesticos[0] = new Electrodomestico(330, 12);
            electrodomesticos[1] = new Electrodomestico.Lavadora(12, 12);
            electrodomesticos[2] = new Electrodomestico.Television(12, 23);
            electrodomesticos[3] = new Electrodomestico(12, 52);
            electrodomesticos[4] = new Electrodomestico.Lavadora(18, 54);
            electrodomesticos[5] = new Electrodomestico.Television(97, 32);
            electrodomesticos[6] = new Electrodomestico();
            electrodomesticos[7] = new Electrodomestico.Lavadora();
            electrodomesticos[8] = new Electrodomestico.Television();
            electrodomesticos[9] = new Electrodomestico();


            double totalElectrodomesticos = 0;
            double totalLavadoras = 0;
            double totalTelevisiones = 0;


            foreach (Electrodomestico electrodomestico in electrodomesticos)
            {
                double precio = electrodomestico.precioFinal();
                totalElectrodomesticos += precio;

                if (electrodomestico is Electrodomestico.Lavadora)
                {
                    totalLavadoras += precio;
                }
                else if (electrodomestico is Electrodomestico.Television)
                {
                    totalTelevisiones += precio;
                }
            }


            Console.WriteLine("Precio total de electrodomésticos: " + totalElectrodomesticos);
            Console.WriteLine("Precio total de lavadoras: " + totalLavadoras);
            Console.WriteLine("Precio total de televisiones: " + totalTelevisiones);
        }
    }



    public class Electrodomestico
    {
        private int PrecioBase = 100;
        private string Color = "blanco";
        private char ConsumoEnergetico = 'F';
        private double Peso = 5;

        public int getPrecio
        {
            get { return PrecioBase; }
        }

        public string getColor
        {
            get { return Color; }
        }

        public char getConsumoEnergetico
        {
            get { return ConsumoEnergetico; }
        }

        public double getPeso
        {
            get { return Peso; }
        }

        public Electrodomestico()
        {

        }

        public Electrodomestico(int precioBase, double peso)
        {
            this.PrecioBase = precioBase;
            this.Peso = peso;
        }

        public Electrodomestico(int precioBase, string color, char consumoEnergetico, double peso)
        {
            this.PrecioBase = precioBase;
            this.Color = color;
            this.ConsumoEnergetico = consumoEnergetico;
            this.Peso = peso;
        }

        public char comprobarConsumoEnergetico(char letra)
        {
            if (letra >= 'A' && letra <= 'F')
            {
                return letra;
            }
            return ConsumoEnergetico;
        }

        public string comprobarColor(string color)
        {
            if (color == "blanco" || color == "negro" || color == "rojo" || color == "azul" || color == "gris")
            {
                return color;
            }
            return Color;
        }
        public virtual double precioFinal()
        {
            int precioLetra = 0;
            int precioTamaño = 0;
            int precioFinal = 0;


            if (ConsumoEnergetico == 'A')
            {
                precioLetra = 100;
            }
            if (ConsumoEnergetico == 'B')
            {
                precioLetra = 80;
            }
            if (ConsumoEnergetico == 'C')
            {
                precioLetra = 60;
            }
            if (ConsumoEnergetico == 'D')
            {
                precioLetra = 50;
            }
            if (ConsumoEnergetico == 'E')
            {
                precioLetra = 30;
            }

            if (ConsumoEnergetico == 'F')
            {
                precioLetra = 10;
            }


            if (Peso >= 0 && Peso <= 19)
            {
                precioTamaño = 10;
            }

            if (Peso >= 20 && Peso <= 49)
            {
                precioTamaño = 50;
            }

            if (Peso >= 50 && Peso <= 79)
            {
                precioTamaño = 80;
            }
            if (Peso >= 80)
            {
                precioTamaño = 100;
            }

            precioFinal = precioLetra + precioTamaño;
            return precioFinal;
        }

        public class Lavadora : Electrodomestico
        {

            private int Carga = 5;
            public Lavadora() : base()
            {

            }

            public Lavadora(int precioBase, double peso) : base(precioBase, peso)
            {
                int PrecioBase = precioBase;
                double Peso = peso;
            }

            public Lavadora(int precioBase, string color, char consumoEnergetico, double peso, int Carga) : base(precioBase, color, consumoEnergetico, peso)
            {
                this.Carga = Carga;

            }


            public int getCarga
            {
                get { return Carga; }
            }

            public override double precioFinal()
            {
                double precioLavadora = base.precioFinal();

                if (Carga > 30)
                {
                    precioLavadora += 50;
                }

                return precioLavadora;
            }
        }

        public class Television : Electrodomestico
        {
            int resolucion { get; set; } = 20;
            bool sintonizadorTDT { get; set; } = false;

            public Television()
            {

            }

            public Television(int precioBase, double peso) : base(precioBase, peso)
            {
                int PrecioBase = precioBase;
                double Peso = peso;
            }

            public Television(int precioBase, string color, char consumoEnergetico, double peso, int resolucion, bool sintonizadorTDT) : base(precioBase, color, consumoEnergetico, peso)
            {
                this.resolucion = resolucion;
                this.sintonizadorTDT = sintonizadorTDT;
            }

            public override double precioFinal()
            {
                double precioTelevision = base.precioFinal();
                if (resolucion > 40)
                {
                    precioTelevision = precioTelevision * 1.3;
                }

                if (sintonizadorTDT == true)
                {
                    precioTelevision += 50;
                }
                return precioTelevision;
            }
        }
    }
}
