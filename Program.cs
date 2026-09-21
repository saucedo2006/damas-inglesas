using System;
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
while (true)
{
Console.WriteLine("escribe la fila y columna de origen y destino: Ej: 2 1 1 2");
string entrada = Console.ReadLine();

string[] partes = entrada.Split(' ');
int forigen = Convert.ToInt32(partes[0]);
int corigen = Convert.ToInt32(partes[1]);
int fdestino = Convert.ToInt32(partes[2]);
int cdestino = Convert.ToInt32(partes[3]);
int distanciaFila = Math.Abs(fdestino - forigen);
int distanciaColumna = Math.Abs(cdestino - corigen);


Console.WriteLine("movimiento registrado:" + partes[0] + partes[1]);
Console.WriteLine("Destino:" + partes[2] + partes[3]);
if (tipodeficha[forigen, corigen] == turno)


{
    if (distanciaFila == 1 && distanciaColumna == 1)
    if((turno == 'B' && fdestino > forigen) || (turno == 'N' && fdestino < forigen))
    {
    Console.WriteLine("movimiento valido");
    Console.WriteLine("aqui hay una ficha ");
    char fichaamover = (tipodeficha[forigen, corigen]);
    tipodeficha[fdestino, cdestino] = fichaamover;
    tipodeficha[forigen, corigen] = '-';
    if (turno == 'B')
    {
        turno = 'N';
    }
    else
    {
        turno = 'B';
    }
    }
    else if (distanciaFila == 2 && distanciaColumna == 2)
    {
        int filaMedia = (forigen + fdestino) / 2;
        int columnaMedia = (corigen + cdestino) / 2;
        if (tipodeficha[filaMedia, columnaMedia] != '-' && tipodeficha[filaMedia, columnaMedia] != turno)
        {
            Console.WriteLine("movimiento valido");
            char fichaamover = (tipodeficha[forigen, corigen]);
            tipodeficha[fdestino, cdestino] = fichaamover;
            tipodeficha[forigen, corigen] = '-';
            tipodeficha[filaMedia, columnaMedia] = '-';
            if (turno == 'B')
            {
                turno = 'N';
            }
            else
            {
                turno = 'B';
            }
        }
        else
        {
            Console.WriteLine("movimiento invalido");
        }
    }
    else
    {
        Console.WriteLine("movimiento invalido");
    }
   
}

else
{
    Console.WriteLine("no es tu turno");
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
};



