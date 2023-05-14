using Aula_SO_Algoritimo; // Importa o namespace que contém as classes Partition e Process

public static class WorstFit // Declaração da classe WorstFit
{
    public static bool Allocate(List<Partition> partitions, Process process, out int position)
    {
        position = -1; // Inicializa a posição como -1
        int worstFitIndex = -1; // Inicializa o índice do pior ajuste como -1
        int worstFitDifference = -1; // Inicializa a diferença do pior ajuste como -1

        for (int i = 0; i < partitions.Count; i++) // Loop para percorrer as partições
        {
            if (!partitions[i].IsOccupied && partitions[i].Size >= process.Size) // Verifica se a partição não está ocupada e possui tamanho suficiente para o processo
            {
                int difference = partitions[i].Size - process.Size; // Calcula a diferença entre o tamanho da partição e o tamanho do processo
                if (difference > worstFitDifference) // Verifica se a diferença é maior do que a pior diferença encontrada até agora
                {
                    worstFitDifference = difference; // Atualiza a pior diferença
                    worstFitIndex = i; // Atualiza o índice do pior ajuste
                }
            }
        }

        if (worstFitIndex != -1) // Se foi encontrado um pior ajuste válido
        {
            partitions[worstFitIndex].IsOccupied = true; // Marca a partição como ocupada
            position = worstFitIndex; // Atribui a posição do pior ajuste à variável position
            return true; // Retorna verdadeiro para indicar que a alocação foi bem-sucedida
        }

        return false; // Retorna falso para indicar que a alocação falhou
    }
}
