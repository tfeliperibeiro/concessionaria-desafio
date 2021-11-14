using System.Collections.Generic;

namespace concessionaria_thiago
{
  public class Manutencao
  {
    private string oficina;
    private string data;
    private List<string> pecas = new List<string>();

    public Manutencao(string oficina, string data, List<string> pecas)
    {
      this.oficina = oficina;
      this.data = data;
      this.pecas = pecas;
    }

    public string Oficina
    {
      get { return oficina; }
      set { oficina = value; }
    }

    public string Data
    {
      get { return data; }
      set { data = value; }
    }

    public List<string> Pecas
    {
      get { return pecas; }
      set { pecas = value; }
    }

    public override string ToString()
    {
      return "\n Carro possui manutenção -> Oficina: " + oficina + " |" + " Data da manutenção: " + data + " |" + " Peças trocadas: \n" + string.Join(", ", pecas);
    }
  }
}