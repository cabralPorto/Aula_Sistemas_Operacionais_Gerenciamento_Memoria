namespace Aula_SO_Algoritimo // Declaração do namespace Aula_SO_Algoritimo
{
    public static class FirstFit // Declaração da classe FirstFit
    {
        public static bool Allocate(List<Partition> partitions, Process process, out int position)
        {
            position = -1; // Inicializa a posição como -1

            for (int i = 0; i < partitions.Count; i++) // Loop para percorrer as partições
            {
                if (!partitions[i].IsOccupied && partitions[i].Size >= process.Size) // Verifica se a partição não está ocupada e possui tamanho suficiente para o processo
                {
                    partitions[i].IsOccupied = true; // Marca a partição como ocupada
                    position = i; // Atribui a posição da partição à variável position
                    return true; // Retorna verdadeiro para indicar que a alocação foi bem-sucedida
                }
            }

            return false; // Retorna falso para indicar que a alocação falhou
        }
    }
}
