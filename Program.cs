using System;
using System.Collections.Generic;

namespace concessionaria_thiago
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Bem vindo a concessionaria Newbies 🚗");
      Console.WriteLine("-----------------------");
      Console.WriteLine();

      List<Carro> carros = new List<Carro>();

      int id = 0;

      bool sair = false;

      while (!sair)
      {
        int menu = Menu();
        Console.Clear();
        switch (menu)
        {
          case 1:
            carros.Add(AdicionarCarro(++id));
            break;
          case 2:
            ListarCarros(carros);
            break;
          case 3:
            PesquisarModeloMarcaCor(carros);
            break;
          case 4:
            PesquisarPorKmRodado(carros);
            break;
          case 5:
            PesquisarPorStatus(carros);
            break;
          case 6:
            adicionarManutencao(carros);
            break;
          case 7:
            venderCarro(carros);
            break;
          case 8:
            sair = true;
            break;
          default:
            Console.WriteLine("Opção inválida");
            Console.WriteLine("--------------");
            break;
        }
      }
    }
    static int Menu()
    {
      Console.WriteLine("Digite 1 para inserir um novo carro");
      Console.WriteLine("Digite 2 para listar todos os carros");
      Console.WriteLine("Digite 3 para pesquisar carro");
      Console.WriteLine("Digite 4 para pesquisar por KM rodado");
      Console.WriteLine("Digite 5 para pesquisar carro por status");
      Console.WriteLine("Digite 6 para adicionar manutenção");
      Console.WriteLine("Digite 7 para vender um carro");
      Console.WriteLine("Digite 8 Sair");
      string opcao = validaString(Console.ReadLine());
      return Int32.Parse(opcao);
    }
    static Carro AdicionarCarro(int id)
    {
      Console.WriteLine("Digite o modelo do carro");
      string modelo = Console.ReadLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine("Digite a marca do carro");
      string marca = Console.ReadLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine("Digite o KM rodado");
      string kmRodados = validaString(Console.ReadLine());
      Console.WriteLine("-----------------------");
      Console.WriteLine("Digite a cor do carro");
      string cor = Console.ReadLine();
      Console.WriteLine("-----------------------");
      Console.WriteLine("Carro adicionado com sucesso!!");
      Console.WriteLine("----------------------------");
      return new Carro(modelo, marca, Int32.Parse(kmRodados), cor, false, id);
    }
    static void ListarCarros(List<Carro> carros)
    {
      if (carros.Count != 0)
      {
        for (int i = 0; i < carros.Count; i++)
        {
          Console.WriteLine(carros[i]);
          Console.WriteLine("-----------------------");
        }
      }
      else
      {
        Console.WriteLine("Nenhum carro cadastrado!!");
        Console.WriteLine("-------------------------");
      }
    }
    static void PesquisarModeloMarcaCor(List<Carro> carros)
    {
      Console.WriteLine("1 - Pesquisar por Modelo");
      Console.WriteLine("-----------------------");
      Console.WriteLine("2 - Pesquisar por Marca");
      Console.WriteLine("-----------------------");
      Console.WriteLine("3 - Pesquisar por Cor");
      Console.WriteLine("-----------------------");
      string opcao = validaString(Console.ReadLine());
      switch (Int32.Parse(opcao))
      {
        case 1:
          Console.WriteLine("Digite o modelo que deseja pesquisar");
          Console.WriteLine("-----------------------");
          string modelo = Console.ReadLine();
          ListarCarros(carros.FindAll(carro => carro.Modelo.Contains(modelo)));
          break;
        case 2:
          Console.WriteLine("Digite a marca que deseja pesquisar");
          Console.WriteLine("-----------------------");
          string marca = Console.ReadLine();
          ListarCarros(carros.FindAll(carro => carro.Marca.Contains(marca)));
          break;
        case 3:
          Console.WriteLine("Digite a cor que deseja pesquisar");
          Console.WriteLine("-----------------------");
          string cor = Console.ReadLine();
          ListarCarros(carros.FindAll(carro => carro.Cor.Contains(cor)));
          break;
      }
    }
    static void PesquisarPorKmRodado(List<Carro> carros)
    {
      Console.WriteLine("Digite o KM para fazer a busca");
      Console.WriteLine("-----------------------");
      string kmRodadoValidado = validaString(Console.ReadLine());
      Carro result = carros.Find(carro => carro.KmRodados <= Int32.Parse(kmRodadoValidado));
      if (result != null) ListarCarros(carros.FindAll(carro => carro.KmRodados <= Int32.Parse(kmRodadoValidado)));
      Console.WriteLine("Nenhum carro com essa quilometragem encontrado!!");
    }
    static void PesquisarPorStatus(List<Carro> carros)
    {
      Console.WriteLine("1 - Filtrar por vendidos");
      Console.WriteLine("-----------------------");
      Console.WriteLine("2 - Filtrar em estoque");
      Console.WriteLine("-----------------------");
      string opcao = validaString(Console.ReadLine());

      switch (Int32.Parse(opcao))
      {
        case 1:
          Carro vendido = carros.Find(carro => carro.Status == true);
          if (vendido != null)
          {
            ListarCarros(carros.FindAll(carro => carro.Status == true));
          }
          else
          {
            Console.WriteLine("Nenhum carro vendido");
            Console.WriteLine("-----------------------");
          }
          break;
        case 2:
          Carro estoque = carros.Find(carro => carro.Status == false);
          if (estoque != null)
          {
            ListarCarros(carros.FindAll(carro => carro.Status == false));
          }
          else
          {
            Console.WriteLine("Nenhum carro em estoque");
            Console.WriteLine("-----------------------");
          }
          break;
      }
    }
    static void venderCarro(List<Carro> carros)
    {
      Carro estoqueCarro = carros.Find(carro => carro.Status == false);
      if (estoqueCarro != null)
      {
        Console.WriteLine("Digite o ID do carro que deseja vender.");
        Console.WriteLine("---------------------------------------");
        ListarCarros(carros);
        string id = validaString(Console.ReadLine());

        Carro carroSelecionado = carros.Find(carro => carro.Id == Int32.Parse(id));

        if (carroSelecionado != null)
        {
          Console.WriteLine("Digite o nome do comprador do carro.");
          string nome = Console.ReadLine();
          Console.WriteLine("Digite o CPF do comprador");
          string cpf = validaString(Console.ReadLine());
          Cliente comprador = new Cliente(nome, cpf);
          carroSelecionado.Status = true;
          carroSelecionado.Cliente = comprador;
          Console.WriteLine("Carro vendido com sucesso!!");
        }
      }
      else
      {
        Console.WriteLine("Nenhum carro em estoque para venda!!");
        Console.WriteLine("----------------------");
      }
    }

    static void adicionarManutencao(List<Carro> carros)
    {
      Carro carroManutencaoStatus = carros.Find(carro => carro.Status == false);

      if (carroManutencaoStatus != null)
      {
        ListarCarros(carros);
        Console.WriteLine("Digite o ID do carro que deseja adicionar manutenção");
        string idCarro = validaString(Console.ReadLine());

        Console.WriteLine("Digite o nome da oficina");
        string oficina = Console.ReadLine();
        Console.WriteLine("Digite a data da manutenção");
        string data = Console.ReadLine();
        List<string> pecasTrocadas = new List<string>();

        bool sair = false;
        while (!sair)
        {
          if (pecasTrocadas.Count == 0)
          {
            Console.WriteLine("Digite o nome da peça trocada");
            string peca = Console.ReadLine();
            pecasTrocadas.Add(peca);
          }

          Console.WriteLine("Digite 1 para adicionar outra peça");
          Console.WriteLine("Digite 2 para finalizar");
          string opcaoPeca = validaString(Console.ReadLine());

          if (Int32.Parse(opcaoPeca) == 1)
          {
            Console.WriteLine("Digite o nome da peça trocada");
            string peca = Console.ReadLine();
            pecasTrocadas.Add(peca);
          }
          else
          {
            Console.WriteLine("Manutenção adicionada");
            sair = true;
          }
          Carro carroManutencao = carros.Find(carro => carro.Id == Int32.Parse(idCarro));
          Manutencao novaManutencao = new Manutencao(oficina, data, pecasTrocadas);
          carroManutencao.Manutencao = novaManutencao;
        }
      }
      else
      {
        Console.WriteLine("Nenhum carro em estoque para adicionar manutenção!!");
        Console.WriteLine("---------------------------------------------------");
      }
    }

    static string validaString(string text)
    {
      string inputText = text;
      int result;

      while (!int.TryParse(inputText, out result))
      {
        Console.WriteLine("Digite somente números.");
        Console.WriteLine("-----------------------");
        inputText = Console.ReadLine();
      }

      return result.ToString();
    }
  }
}

