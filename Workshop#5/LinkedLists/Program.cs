using LinkedLists;

DoublyLinkedList<IComparable> list = new DoublyLinkedList<IComparable>();
string? tipoLista = null;
int opcion;

do
{
    Console.WriteLine("\n--- MENU ---");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atras");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar moda(s)");
    Console.WriteLine("6. Mostrar grafico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opcion: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("La opcion debe ser un numero");
        opcion = -1;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Ingresa un dato: ");
            string input = Console.ReadLine()!.ToLower();

            string tipoActual;
            int numero = 0;
            double decimal_ = 0;

            if (int.TryParse(input, out numero))
                tipoActual = "int";
            else if (double.TryParse(input, out decimal_))
                tipoActual = "double";
            else
                tipoActual = "string";

            if (tipoLista == null)
                tipoLista = tipoActual;

            if (tipoActual != tipoLista)
            {
                Console.WriteLine("Error: debe ingresar datos del mismo tipo (" + tipoLista + ")");
                break;
            }

            if (tipoActual == "int")
                list.Insert(numero);
            else if (tipoActual == "double")
                list.Insert(decimal_);
            else
                list.Insert(input);
            break;

        case 2:
            Console.WriteLine("Lista hacia adelante:");
            list.PrintForward();
            break;

        case 3:
            Console.WriteLine("Lista hacia atras:");
            list.PrintBackward();
            break;

        case 4:
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente:");
            list.PrintForward();
            break;

        case 5:
            list.GetMode();
            break;

        case 6:
            list.PrintChart();
            break;

        case 7:
            Console.Write("Ingresa el dato a buscar: ");
            string buscarInput = Console.ReadLine()!.ToLower();
            bool encontrado = false;

            if (int.TryParse(buscarInput, out int buscarInt))
                encontrado = list.Exists(buscarInt);
            else if (double.TryParse(buscarInput, out double buscarDouble))
                encontrado = list.Exists(buscarDouble);
            else
                encontrado = list.Exists(buscarInput);

            if (encontrado)
                Console.WriteLine(buscarInput + " existe en la lista");
            else
                Console.WriteLine(buscarInput + " no existe en la lista");
            break;

        case 8:
            Console.Write("Ingresa el dato a eliminar: ");
            string eliminarInput = Console.ReadLine()!.ToLower();

            if (int.TryParse(eliminarInput, out int eliminarInt))
                list.RemoveFirst(eliminarInt);
            else if (double.TryParse(eliminarInput, out double eliminarDouble))
                list.RemoveFirst(eliminarDouble);
            else
                list.RemoveFirst(eliminarInput);

            Console.WriteLine("Primera ocurrencia eliminada");
            list.PrintForward();
            break;

        case 9:
            Console.Write("Ingresa el dato a eliminar: ");
            string eliminarTodosInput = Console.ReadLine()!.ToLower();

            if (int.TryParse(eliminarTodosInput, out int eliminarTodosInt))
                list.RemoveAll(eliminarTodosInt);
            else if (double.TryParse(eliminarTodosInput, out double eliminarTodosDouble))
                list.RemoveAll(eliminarTodosDouble);
            else
                list.RemoveAll(eliminarTodosInput);

            Console.WriteLine("Todas las ocurrencias eliminadas");
            list.PrintForward();
            break;

        case 0:
            Console.WriteLine("Hasta luego!");
            break;

        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
} while (opcion != 0);