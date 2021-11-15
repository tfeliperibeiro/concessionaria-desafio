using System.Collections.Generic;

namespace concessionaria_thiago
{
  public class Carro
  {
    private string modelo;
    private string marca;
    private double kmRodados;
    private string cor;
    private bool status;
    private int id;
    private Cliente cliente;
    private List<Manutencao> manutencao = new List<Manutencao>();

    public string Modelo
    {
      get { return modelo; }
      set { modelo = value; }
    }
    public string Marca
    {
      get { return marca; }
      set { marca = value; }
    }
    public double KmRodados
    {
      get { return kmRodados; }
      set { kmRodados = value; }
    }
    public string Cor
    {
      get { return cor; }
      set { cor = value; }
    }
    public bool Status
    {
      get { return status; }
      set { status = value; }
    }
    public Cliente Cliente
    {
      get { return cliente; }
      set { cliente = value; }
    }
    public List<Manutencao> Manutencao
    {
      get { return manutencao; }
      set { manutencao = value; }
    }

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public Carro(string modelo, string marca, int kmRodados, string cor, bool status, int id)
    {
      this.modelo = modelo;
      this.marca = marca;
      this.kmRodados = kmRodados;
      this.cor = cor;
      this.status = status;
      this.id = id;
    }

    public override string ToString()
    {
      return "ID: " + id + " |" + " Marca: " + marca + " |" + " Modelo: " + modelo + " |" + " KM Rodados: " + kmRodados + " |" + " Cor: " + cor + " | " + "Status: " + $"{(status == false ? "Em estoque " : "Vendido para: ")}" + string.Join(",", cliente) + string.Join(",", manutencao);
    }
  }
}