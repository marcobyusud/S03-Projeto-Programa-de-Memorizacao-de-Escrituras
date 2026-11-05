namespace MemorizadorEscrituras;

public class Referencia
{
    private readonly string _livro;
    private readonly int _capitulo;
    private readonly int _versiculo;
    private readonly int _ultimoVersiculo;

    public Referencia(string livro, int capitulo, int versiculo)
        : this(livro, capitulo, versiculo, versiculo)
    {
    }

    public Referencia(string livro, int capitulo, int primeiroVersiculo, int ultimoVersiculo)
    {
        if (string.IsNullOrWhiteSpace(livro))
        {
            throw new ArgumentException("O nome do livro não pode ficar vazio.", nameof(livro));
        }

        if (capitulo <= 0 || primeiroVersiculo <= 0 || ultimoVersiculo < primeiroVersiculo)
        {
            throw new ArgumentOutOfRangeException(
                nameof(ultimoVersiculo),
                "Capítulo e versículos devem ser positivos, e o último versículo não pode ser menor que o primeiro.");
        }

        _livro = livro;
        _capitulo = capitulo;
        _versiculo = primeiroVersiculo;
        _ultimoVersiculo = ultimoVersiculo;
    }

    public string ObterTexto()
    {
        if (_versiculo == _ultimoVersiculo)
        {
            return $"{_livro} {_capitulo}:{_versiculo}";
        }

        return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
    }
}
