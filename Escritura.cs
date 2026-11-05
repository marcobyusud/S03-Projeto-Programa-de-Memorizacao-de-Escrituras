namespace MemorizadorEscrituras;

public class Escritura
{
    private readonly Referencia _referencia;
    private readonly List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        ArgumentNullException.ThrowIfNull(referencia);

        if (string.IsNullOrWhiteSpace(texto))
        {
            throw new ArgumentException("O texto da escritura não pode ficar vazio.", nameof(texto));
        }

        _referencia = referencia;
        _palavras = texto
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(textoDaPalavra => new Palavra(textoDaPalavra))
            .ToList();
    }

    public void OcultarPalavrasAleatorias(int numeroParaOcultar)
    {
        List<Palavra> palavrasVisiveis = _palavras
            .Where(palavra => !palavra.EstaOculta())
            .ToList();

        int quantidade = Math.Min(numeroParaOcultar, palavrasVisiveis.Count);

        for (int i = 0; i < quantidade; i++)
        {
            int indice = Random.Shared.Next(palavrasVisiveis.Count);
            palavrasVisiveis[indice].Ocultar();
            palavrasVisiveis.RemoveAt(indice);
        }
    }

    public string ObterTexto()
    {
        string textoDasPalavras = string.Join(
            " ",
            _palavras.Select(palavra => palavra.ObterTexto()));

        return $"{_referencia.ObterTexto()}: {textoDasPalavras}";
    }

    public bool EstaCompletamenteOculta()
    {
        return _palavras.All(palavra => palavra.EstaOculta());
    }

    public int ObterQuantidadeDePalavras()
    {
        return _palavras.Count;
    }

    public int ObterQuantidadeDePalavrasOcultas()
    {
        return _palavras.Count(palavra => palavra.EstaOculta());
    }
}
