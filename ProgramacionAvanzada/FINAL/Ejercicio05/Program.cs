namespace Ejercicio05;

class Program
{
    static void Main(string[] args)
    {
        Lista<string> nodo1 = new Lista<string>{Valor="A"};
        Lista<string> nodo2 = new Lista<string>{Valor="B"};
        Lista<string> nodo3= new Lista<string>{Valor="C"};

        nodo1.Siguiente = nodo2;
        nodo2.Siguiente = nodo3;

        Lista<string> actual = nodo1;
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual=actual.Siguiente;
        }

    }
}
