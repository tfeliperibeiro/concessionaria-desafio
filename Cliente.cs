namespace concessionaria_thiago
{
  public class Cliente
  {
    private string nome;
    private string cpf;

    public Cliente(string nome, string cpf)
    {
      this.nome = nome;
      this.cpf = cpf;
    }

    public string Nome
    {
      get { return nome; }
      set { nome = value; }
    }

    public string Cpf
    {
      get { return cpf; }
      set { cpf = value; }
    }

    public override string ToString()
    {
      return nome + " |" + " CPF: " + cpf;
    }
  }
}