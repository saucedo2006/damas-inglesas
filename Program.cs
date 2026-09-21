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
        Console.Write(tipodeficha[i, j] + " ");
    }
    Console.WriteLine();
}
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
if (tipodeficha[forigen, corigen] == 'B')

{
    if (distanciaFila == 1 && distanciaColumna == 1)
    {
    Console.WriteLine("movimiento valido");
    Console.WriteLine("aqui hay una ficha blanca");
    char fichaamover = (tipodeficha[forigen, corigen]);
    tipodeficha[fdestino, cdestino] = fichaamover;
    tipodeficha[forigen, corigen] = '-';
    }
    else
    {
        Console.WriteLine("movimiento invalido");
    }
   
}
else if (tipodeficha[forigen, corigen] == 'N')
{
    if (distanciaFila == 1 && distanciaColumna == 1)
    {
     Console.WriteLine("movimiento valido");
    char fichaamover = (tipodeficha[forigen, corigen]);
    tipodeficha[fdestino, cdestino] = fichaamover;
    tipodeficha[forigen, corigen] = '-';
    }
    else
    {
        Console.WriteLine("movimiento invalido");
    }
    
}
else
{
    Console.WriteLine("no hay ninguna ficha");
}
Console.WriteLine("  0 1 2 3 4 5 6 7 ");
for (int i = 0; i < 8; i++)
{
    Console.Write(i + " ");
    for (int j = 0; j < 8; j++)
    {
        Console.Write(tipodeficha[i, j] + " ");
    }
    Console.WriteLine();
};




