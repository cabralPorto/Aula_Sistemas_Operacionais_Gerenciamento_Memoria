namespace Aula_SO_Algoritimo // Declaração do namespace Aula_SO_Algoritimo
{
    public static class BestFit // Declaração da classe BestFit
    {
        public static bool Allocate(List<Partition> partitions, Process process, out int position)
        {
            position = -1; // Inicializa a posição como -1
            int bestFitIndex = -1; // Inicializa o índice do melhor ajuste como -1
            int bestFitDifference = int.MaxValue; // Inicializa a diferença do melhor ajuste como o valor máximo de um inteiro

            for (int i = 0; i < partitions.Count; i++) // Loop para percorrer as partições
            {
                if (!partitions[i].IsOccupied && partitions[i].Size >= process.Size) // Verifica se a partição não está ocupada e possui tamanho suficiente para o processo
                {
                    int difference = partitions[i].Size - process.Size; // Calcula a diferença entre o tamanho da partição e o tamanho do processo
                    if (difference < bestFitDifference) // Verifica se a diferença é menor do que a melhor diferença encontrada até agora
                    {
                        bestFitDifference = difference; // Atualiza a melhor diferença
                        bestFitIndex = i; // Atualiza o índice do melhor ajuste
                    }
                }
            }

            if (bestFitIndex != -1) // Se foi encontrado um melhor ajuste válido
            {
                partitions[bestFitIndex].IsOccupied = true; // Marca a partição como ocupada
                position = bestFitIndex; // Atribui a posição do melhor ajuste à variável position
                return true; // Retorna verdadeiro para indicar que a alocação foi bem-sucedida
            }

            return false; // Retorna falso para indicar que a alocação falhou
        }
    }
}
