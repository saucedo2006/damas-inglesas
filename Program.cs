using System;
using System.Collections.Generic;
using System.IO;
char[,] tipodeficha = {
                {'-','B','-','B','-','B','-','B'},
                {'B','-','B','-','B','-','B','-'},
                {'-','B','-','B','-','B','-','B'},
                {'-','-','-','-','-','-','-','-'},
                {'-','-','-','-','-','-','-','-'},
                {'N','-','N','-','N','-','N','-'},
                {'-','N','-','N','-','N','-','N'},
                {'N','-','N','-','N','-','N','-'}
            };
Console.WriteLine("  0 1 2 3 4 5 6 7 ");
for (int i = 0; i < 8; i++)
{
    Console.Write(i + " ");
    for (int j = 0; j < 8; j++)
    {
        if (tipodeficha[i, j] == 'B')
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
        }
        else if (tipodeficha[i, j] == 'N')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.Write(tipodeficha[i, j] + " ");
        Console.ResetColor();
    }
    
    
    Console.WriteLine();
}
char turno = 'B';
List<string> Historial = new List<string>();

while (true)
{
    DateTime tiempoinicio = DateTime.Now;

    Console.WriteLine("Turno de: " + turno);
     Console.WriteLine("escribe la fila y columna de origen : Ej: 2 1 ");
   string entrada = Console.ReadLine();
   if (string.IsNullOrEmpty(entrada))
   {
    Console.WriteLine("Entrada vacía. Por favor, ingresa la fila y columna de origen.");
    continue;
   }
   if (entrada.ToLower() == "me rindo")
   {
    char ganador = (turno == 'B') ? 'N' : 'B';
    Console.WriteLine("El jugador " + ganador + " gana por rendición.");
    File.WriteAllLines("historial.txt", Historial);
    break;
   }
   TimeSpan tiempoTranscurrido = DateTime.Now - tiempoinicio;
   if (tiempoTranscurrido.TotalMinutes > 3)
   {
    Console.WriteLine("se te acabo el tiempo, va el otro jugador");
    char ganador = (turno == 'B') ? 'N' : 'B';
    Console.WriteLine("El jugador " + ganador + " gana.");
    File.WriteAllLines("historial.txt", Historial);
    continue;
   }

string[] partes = entrada.Split(' ');
if (partes.Length < 2) continue;
int forigen = Convert.ToInt32(partes[0]);
int corigen = Convert.ToInt32(partes[1]);




if (tipodeficha[forigen, corigen] == turno)
    {
        Console.WriteLine("presione la flecha izquierda o derecha para mover la ficha");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        int fdestino=0;
        int cdestino=0;
        
        if (turno == 'B')
        {
           if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                fdestino = forigen + 1;
                cdestino = corigen -1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                fdestino = forigen + 1;
                cdestino = corigen + 1;
            }
        }
        else if (turno == 'N')
        {
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                fdestino = forigen - 1;
                cdestino = corigen - 1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                fdestino = forigen - 1;
                cdestino = corigen + 1;
            }
        }

       if (fdestino >= 0 && fdestino < 8 && cdestino >= 0 && cdestino < 8)
        {
            char fichaactual = tipodeficha[forigen, corigen];
            bool esReina = (fichaactual == 'R' || fichaactual == 'M');
            char rival = (turno == 'B') ? 'N' : 'B';
            char rivalReina = (turno == 'B') ? 'M' : 'R';
            char destinoActual = tipodeficha[fdestino, cdestino];

            bool direccionValida = esReina || (turno == 'B' && fdestino > forigen) || (turno == 'N' && fdestino < forigen);

            if (direccionValida)
            {
                // 1. Movimiento normal a casilla vacía
                if (destinoActual == '-')
                {
                    tipodeficha[fdestino, cdestino] = fichaactual;
                    tipodeficha[forigen, corigen] = '-';
                    Historial.Add(turno + " movió de (" + forigen + ", " + corigen + ") a (" + fdestino + ", " + cdestino + ")");
                    
                    if ((turno == 'B' && fdestino == 7) && fichaactual != 'R')
                    {
                        tipodeficha[fdestino, cdestino] = 'R';
                        Historial.Add(turno + " se convirtió en reina en (" + fdestino + ", " + cdestino + ")");
                    }
                    else if ((turno == 'N' && fdestino == 0) && fichaactual != 'M')
                    {
                        tipodeficha[fdestino, cdestino] = 'M';
                        Historial.Add(turno + " se convirtió en reina en (" + fdestino + ", " + cdestino + ")");
                    }
                    
                    turno = (turno == 'B') ? 'N' : 'B';
                }
                // 2. Comer ficha rival haciendo salto
                else if (destinoActual == rival || destinoActual == rivalReina)
                {
                    int fSalto = fdestino + (fdestino - forigen);
                    int cSalto = cdestino + (cdestino - corigen);

                    if (fSalto >= 0 && fSalto < 8 && cSalto >= 0 && cSalto < 8 && tipodeficha[fSalto, cSalto] == '-')
                    {
                        tipodeficha[fSalto, cSalto] = fichaactual; 
                        tipodeficha[forigen, corigen] = '-';       
                        tipodeficha[fdestino, cdestino] = '-';     
                        
                        Historial.Add(turno + " comió ficha saltando a (" + fSalto + "," + cSalto + ")");

                        if ((turno == 'B' && fSalto == 7) && fichaactual != 'R')
                        {
                            tipodeficha[fSalto, cSalto] = 'R';
                            Historial.Add(turno + " se convirtió en reina en (" + fSalto + "," + cSalto + ")");
                        }
                        else if ((turno == 'N' && fSalto == 0) && fichaactual != 'M')
                        {
                            tipodeficha[fSalto, cSalto] = 'M';
                            Historial.Add(turno + " se convirtió en reina en (" + fSalto + "," + cSalto + ")");
                        }

                        turno = (turno == 'B') ? 'N' : 'B';
                    }
                    else
                    {
                        Console.WriteLine("No puedes saltar (casilla detrás ocupada o fuera del tablero).");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento inválido. La casilla está ocupada.");
                }
            }
            else
            {
                Console.WriteLine("Movimiento inválido para fichas normales (solo avanzan hacia adelante).");
            }
        }
        else
        {
            Console.WriteLine("Movimiento fuera de los límites del tablero.");
        }
int fichasB = 0;
int fichasN = 0;

for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        if (tipodeficha[i, j] == 'B')
        {
            fichasB++;
        }
        else if (tipodeficha[i, j] == 'N')
        {
            fichasN++;
        }
    }
} if (fichasB == 0)
{
    Console.WriteLine("Fichas negras ganan");
    File.WriteAllLines("historial.txt", Historial);
    break;
}
else if (fichasN == 0)
{
    Console.WriteLine("Fichas azules ganan");
    File.WriteAllLines("historial.txt", Historial);
    break;
}

Console.Clear();
Console.WriteLine("  0 1 2 3 4 5 6 7 ");
for (int i = 0; i < 8; i++)
{
    Console.Write(i + " ");
    for (int j = 0; j < 8; j++)
    {
        if (tipodeficha[i, j] == 'B')
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
        }
        else if (tipodeficha[i, j] == 'N')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.Write(tipodeficha[i, j] + " ");
        Console.ResetColor();
    }
    Console.WriteLine();
}
}
}





