namespace MemorizadorEscrituras;

public class Program
{
    // Além do básico, o programa escolhe aleatoriamente entre duas escrituras
    // e mostra o progresso para ajudar a acompanhar a prática.
    private static readonly Escritura[] Biblioteca =
    {
        new(
            new Referencia("Salmos", 23, 1),
            "O Senhor é o meu pastor; nada me faltará."),
        new(
            new Referencia("1 Néfi", 3, 7),
            "E aconteceu que eu, Néfi, disse a meu pai: Eu irei e cumprirei as ordens do Senhor, porque sei que o Senhor nunca dá ordens aos filhos dos homens sem antes preparar um caminho pelo qual suas ordens possam ser cumpridas.")
    };

    public static void Main()
    {
        Escritura escritura = Biblioteca[Random.Shared.Next(Biblioteca.Length)];

        while (true)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();

            if (escritura.EstaCompletamenteOculta())
            {
                Console.WriteLine("Muito bem! Você ocultou todas as palavras.");
                break;
            }

            int progresso = escritura.ObterQuantidadeDePalavrasOcultas() * 100
                / escritura.ObterQuantidadeDePalavras();
            Console.WriteLine($"Progresso: {progresso}%");
            Console.Write("Pressione Enter para continuar ou digite 'sair': ");

            string resposta = Console.ReadLine() ?? "sair";
            if (resposta.Trim().Equals("sair", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            escritura.OcultarPalavrasAleatorias(3);
        }
    }
}
