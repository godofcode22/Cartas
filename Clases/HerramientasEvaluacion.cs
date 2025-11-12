using System;
using System.Collections.Generic;
using Cartas.Interfaces;
using Cartas.Clases;
namespace Cartas.Clases;

public static class EscenariosEvaluacion
    {
        public static List<JugadorPrincipal> GetJugadores_BJ_Cauteloso()
        {
            return new List<JugadorPrincipal>
            {
                new JugadorPrincipal("Jugador Cauteloso (Prueba)", new JugadorCauteloso(17))
            };
        }

        public static List<ICarta> GetMazo_BJ_DebePedir()
        {
            Console.WriteLine("...cargando mazo 'BJ_DebePedir' (15 puntos iniciales)...");
            var mazoFijo = new List<ICarta>
            {
                new CartaBlackJack("5", "Picas", "Negro", 5),     
                new CartaBlackJack("8", "Treboles", "Negro", 8),  
                new CartaBlackJack("10", "Corazones", "Rojo", 10),
                new CartaBlackJack("K", "Diamantes", "Rojo", 10), 
                new CartaBlackJack("6", "Picas", "Negro", 6),     
                new CartaBlackJack("J", "Picas", "Negro", 10)     
            };
            mazoFijo.Reverse(); 
            return mazoFijo;
        }

        public static List<ICarta> GetMazo_BJ_DebePlantarse()
        {
            Console.WriteLine("...cargando mazo 'BJ_DebePlantarse' (18 puntos iniciales)...");
            var mazoFijo = new List<ICarta>
            {
                new CartaBlackJack("10", "Picas", "Negro", 10),   
                new CartaBlackJack("5", "Treboles", "Negro", 5),  
                new CartaBlackJack("8", "Corazones", "Rojo", 8),  
                new CartaBlackJack("K", "Diamantes", "Rojo", 10), 
                new CartaBlackJack("7", "Picas", "Negro", 7),     
                new CartaBlackJack("J", "Picas", "Negro", 10)     
            };
            mazoFijo.Reverse(); 
            return mazoFijo;
        }

        public static List<JugadorUNO> GetJugadores_UNO_3Players()
        {
            return new List<JugadorUNO>
            {
                new JugadorUNO("Jugador 1 (Prueba)", new ComportamientoAleatorioUNO()),
                new JugadorUNO("Jugador 2 (Prueba)", new ComportamientoCalculadorUNO()),
                new JugadorUNO("Jugador 3 (Prueba)", new ComportamientoAleatorioUNO())
            };
        }

        public static List<ICarta> GetMazo_UNO_ForzarMasCuatro()
        {
            Console.WriteLine("...cargando mazo 'UNO_ForzarMasCuatro' (P1 recibe 7 +4)...");
            var mazoFijo = new List<ICarta>();
            
            for(int i = 0; i < 7; i++) mazoFijo.Add(new CartaUNO("", "+4")); 
            for(int i = 0; i < 7; i++) mazoFijo.Add(new CartaUNO("Rojo", "Numero", i));
            for(int i = 0; i < 7; i++) mazoFijo.Add(new CartaUNO("Azul", "Numero", i)); 
            
            mazoFijo.Add(new CartaUNO("Amarillo", "Numero", 5)); 
            
            for(int i = 0; i < 30; i++) 
                mazoFijo.Add(new CartaUNO("Verde", "Numero", 1));
            
            mazoFijo.Reverse();
            return mazoFijo;
        }
    }
