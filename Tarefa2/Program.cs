string valorDigitado;
int valorNo;
List<int> ValoresInseridos = new List<int>();
List<int> Esquerdas = new List<int>();
List<int> Direitas = new List<int>();

do
{
    Console.WriteLine("Digite um numero para o Nó abaixo. Para seguir para a próxima etapa, aperte enter sem inserir um valor.");
    valorDigitado = Console.ReadLine();

    //Verifica se o valor inserido é um numeral, e caso seja adiciona o valor a variavel de valores.
    if (int.TryParse(valorDigitado, out valorNo))
    {
        ValoresInseridos.Add(valorNo);
    }
    else if (!string.IsNullOrEmpty(valorDigitado))
    {
        Console.WriteLine("Valor não numeral inserido!");
    }
}
while (!string.IsNullOrEmpty(valorDigitado));

ConstruirArvore(ValoresInseridos.ToArray());

void ConstruirArvore(int[] nums)
{
    //Verifica qual o valor é a raiz da árvore.
    int indexMaximo = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] > nums[indexMaximo])
        {
            indexMaximo = i;
        }
    }

    int raiz = nums[indexMaximo];
    //Faz a separação dos valores a esquerda e a direita do valor raiz.
    Inserir(raiz, nums);

    //Exibe os valores na tela
    string arrayEntrada = "";
    nums.ToList().ForEach(p => arrayEntrada += ", " + p.ToString());
    Console.WriteLine("Array de entrada: "+ arrayEntrada[2..]);    
    Console.WriteLine("Raiz: " + raiz);
    string galhosEsquerda = "";
    Esquerdas.OrderByDescending(e => ((uint)e)).ToList().ForEach(p => galhosEsquerda += ", " + p.ToString());
    Console.WriteLine("Galhos a Esquerda: " + galhosEsquerda[2..]);   
    string galhosDireita = "";
    Direitas.OrderByDescending(e => ((uint)e)).ToList().ForEach(p => galhosDireita += ", " + p.ToString());
    Console.WriteLine("Galhos a Direita: " + galhosDireita[2..]);
}
void Inserir(int Raiz, int[] nums)
{
    bool direita = false;
    foreach (var item in nums)
    {
        //testa se o valor é menor que a raiz e tambem testa se o loop já passou pelo valor raiz. Caso tenha passado, passa do galho da esquerda para o da direita.
        if (item < Raiz && direita == false)
        {
            Esquerdas.Add(item);
        }
        else
        {
            direita = true;
            if (item != Raiz)
            {
                Direitas.Add(item);
            }
        }
    }
}