namespace Aula_SO_Algoritimo // Declaração do namespace Aula_SO_Algoritimo
{
    class Program // Declaração da classe Program
    {
        static void Main(string[] args) // Método Main, ponto de entrada do programa
        {
            bool shouldExit = false; // Variável para controlar a saída do programa
            while (!shouldExit) // Loop enquanto shouldExit for falso
            {
                Console.WriteLine("Escolha o algoritmo de alocação: "); // Exibe uma mensagem de seleção do algoritmo
                Console.WriteLine("1. First Fit"); // Exibe as opções disponíveis
                Console.WriteLine("2. Best Fit");
                Console.WriteLine("3. Worst Fit");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: "); // Solicita ao usuário para inserir a opção escolhida
                string option = Console.ReadLine(); // Lê a opção escolhida pelo usuário

                switch (option) // Avalia a opção escolhida
                {
                    case "1": // Caso a opção seja "1"
                        ExecuteAlgorithm("First Fit"); // Chama o método ExecuteAlgorithm passando o nome do algoritmo
                        break; // Sai do switch
                    case "2": // Caso a opção seja "2"
                        ExecuteAlgorithm("Best Fit"); // Chama o método ExecuteAlgorithm passando o nome do algoritmo
                        break; // Sai do switch
                    case "3": // Caso a opção seja "3"
                        ExecuteAlgorithm("Worst Fit"); // Chama o método ExecuteAlgorithm passando o nome do algoritmo
                        break; // Sai do switch
                    case "0": // Caso a opção seja "0"
                        shouldExit = true; // Define shouldExit como true para sair do loop
                        break; // Sai do switch
                    default: // Caso a opção seja inválida
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida."); // Exibe uma mensagem de opção inválida
                        break; // Sai do switch
                }

                Console.WriteLine(); // Exibe uma linha em branco
            }
        }

        static void ExecuteAlgorithm(string algorithmName) // Método para executar o algoritmo de alocação
        {
            Console.WriteLine($"Você escolheu o algoritmo {algorithmName}."); // Exibe o nome do algoritmo escolhido

            Console.WriteLine("Digite os tamanhos das partições separados por vírgula:"); // Solicita ao usuário os tamanhos das partições
            var partitionSizes = Console.ReadLine().Split(',').Select(int.Parse).ToList(); // Lê os tamanhos das partições informados pelo usuário e os armazena em uma lista
            var partitions = new List<Partition>(); // Cria uma nova lista de objetos Partition para armazenar as partições

            for (int i = 0; i < partitionSizes.Count; i++) // Loop para criar as partições
            {
                partitions.Add(new Partition() { Size = partitionSizes[i], IsOccupied = false }); // Cria uma nova partição e adiciona à lista de partições
            }

            Console.WriteLine("Digite os valores dos processos:"); // Solicita ao usuário os tamanhos dos processos
            var processSizes = Console.ReadLine().Split(',').Select(int.Parse).ToList(); // Lê os tamanhos dos processos informados pelo usuário e os armazena em uma lista
            var processes = new List<Process>(); // Cria uma nova lista de objetos Process para armazenar os processos

            for (int i = 0; i < processSizes.Count; i++) // Loop para criar os processos
            {
                processes.Add(new Process() { Size = processSizes[i] }); // Cria um novo processo e adiciona à lista de processos, definindo seu tamanho
            }

            foreach (var process in processes) // Loop para percorrer cada processo da lista de processos
            {
                bool allocationResult = false; // Variável para armazenar o resultado da alocação
                int position = -1; // Variável para armazenar a posição onde o processo foi alocado

                if (algorithmName == "First Fit") // Se o algoritmo escolhido for o First Fit
                {
                    allocationResult = FirstFit.Allocate(partitions, process, out position); // Chama o método Allocate do FirstFit, passando as partições, o processo e a posição por referência
                }
                else if (algorithmName == "Best Fit") // Se o algoritmo escolhido for o Best Fit
                {
                    allocationResult = BestFit.Allocate(partitions, process, out position); // Chama o método Allocate do BestFit, passando as partições, o processo e a posição por referência
                }
                else if (algorithmName == "Worst Fit") // Se o algoritmo escolhido for o Worst Fit
                {
                    allocationResult = WorstFit.Allocate(partitions, process, out position); // Chama o método Allocate do WorstFit, passando as partições, o processo e a posição por referência
                }

                if (allocationResult) // Se a alocação foi bem-sucedida
                {
                    Console.WriteLine($"Processo com tamanho {process.Size} alocado com sucesso na posição {position}. Tamanho da partição: {partitions[position].Size}"); // Exibe uma mensagem informando o sucesso da alocação, mostrando o tamanho do processo, a posição onde foi alocado e o tamanho da partição correspondente
                }
                else // Se a alocação falhou
                {
                    Console.WriteLine($"Falha ao alocar o processo com tamanho {process.Size}"); // Exibe uma mensagem informando a falha na alocação, mostrando o tamanho do processo
                }
            }
        }
    }
}