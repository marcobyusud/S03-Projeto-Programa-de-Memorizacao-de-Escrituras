namespace MemorizadorEscrituras;

public class Palavra
{
    private readonly string _texto;
    private bool _estaOculta;

    public Palavra(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            throw new ArgumentException("A palavra não pode ficar vazia.", nameof(texto));
        }

        _texto = texto;
        _estaOculta = false;
    }

    public void Ocultar()
    {
        _estaOculta = true;
    }

    public bool EstaOculta()
    {
        return _estaOculta;
    }

    public string ObterTexto()
    {
        if (!_estaOculta)
        {
            return _texto;
        }

        return string.Concat(_texto.Select(caractere =>
            char.IsLetterOrDigit(caractere) ? '_' : caractere));
    }
}
