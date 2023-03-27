using System.ComponentModel.Design;
using OrdemDeServicos;

internal class Program
{
    private static void Main(string[] args)
    {
        List<OrdemDeServico> orcamento = new List<OrdemDeServico>();

        int opc;

        do
        {
            opc = Menu();
            switch (opc)
            {
                case 0:
                    graver_orcamentos(orcamento);
                    break;
                case 1:
                    orcamento.Add(Cadastrar_Orcamento());
                    break;
                case 2:
                    imprimir_orcamentos(orcamento);
                    break;
            }

        } while (opc != 0);
        Carregar_Dados(orcamento);
    }


    private static void Carregar_Dados(List<OrdemDeServico> orcamento)
    {
        string arquivo = @"orcamentos.csv";
        StreamReader sr = new StreamReader(arquivo);

        do
        {
            string[] campos = sr.ReadLine().Split(";");
            int id = int.Parse(campos[0]);
            string descricao = campos[1];
            double valor = double.Parse(campos[2]);
            List<string> p = new List<string>();

            orcamento.Add(new OrdemDeServico(id, descricao, valor, p));
        } while (!sr.EndOfStream);
        sr.Close();
    }

    private static void graver_orcamentos(List<OrdemDeServico> orcamento)
    {
        string arquivo = @"orcamentos.csv";
        StreamWriter sw = new StreamWriter(arquivo);
        for (int i = 0; i < orcamento.Count; i++)
        {
            sw.WriteLine(orcamento[i].ToString());
        }
        sw.Close();
    }

    private static void imprimir_orcamentos(List<OrdemDeServico> orcamento)
    {
        Console.WriteLine("Os orçamentos que estão aguardando autorização são: ");
        for (int i = 0; i < orcamento.Count; i++)
        {
            Console.WriteLine(orcamento[i].ToUser());
        }
    }

    public static OrdemDeServico Cadastrar_Orcamento()
    {
        Console.WriteLine("Criando novo orçamento: ");
        Console.WriteLine("Informe o numero da OS: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe a descrição da OS: ");
        string descricao = Console.ReadLine();
        char c;
        List<string> p = new List<string>();
        do
        {
            Console.WriteLine("Informe a peça a ser usada: ");
            string s = Console.ReadLine();
            p.Add(s);
            Console.WriteLine("Deseja incluir outra peça? ");
            c = char.Parse(Console.ReadLine());
        } while (c != 'n');

        Console.WriteLine("Informe o valor da OS: ");
        double valor = double.Parse(Console.ReadLine());
        return new OrdemDeServico(id, descricao, valor, p);
    }


    private static int Menu()
    {
        int opc;
        Console.WriteLine("Informe a opção desejada: ");
        Console.WriteLine("1 - Criar novo orçamento: ");
        Console.WriteLine("2 - Mostrar orçamentos:  ");
        Console.WriteLine("0 - Sair: ");
        opc = int.Parse(Console.ReadLine());

        return opc;
    }
}