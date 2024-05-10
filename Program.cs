// See https://aka.ms/new-console-template for more information

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Two arrays are called similar if one can be obtained from another by swapping at most one pair of elements in one of the arrays.
//
//Given two arrays a and b, check whether they are similar.
//
//Example
//
//For a = [1, 2, 3] and b = [1, 2, 3], the output should be
//solution(a, b) = true.
//
//The arrays are equal, no need to swap any elements.
//
//For a = [1, 2, 3] and b = [2, 1, 3], the output should be
//solution(a, b) = true.
//
//We can obtain b from a by swapping 2 and 1 in b.
//
//For a = [1, 2, 2] and b = [2, 1, 1], the output should be
//solution(a, b) = false.
//
//Any swap of any two elements either in a or in b won't make a and b equal.
//
//Input/Output
//
//[execution time limit] 0.5 seconds(cs)
//
//[memory limit] 1 GB
//
//[input] array.integer a
//
//Array of integers.
//
//Guaranteed constraints:
//3 ≤ a.length ≤ 105,
//1 ≤ a[i] ≤ 1000.
//
//[input] array.integer b
//
//Array of integers of the same length as a.
//
//Guaranteed constraints:
//b.length = a.length,
//1 ≤ b[i] ≤ 1000.
//
//[output] boolean
//
//true if a and b are similar, false otherwise.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("Laboratorio Vetores: 001");
laboratorio.Programa.Execute();

namespace laboratorio
{
    public static class Programa
    {
        public static void Execute()
        {
            Console.WriteLine("Desafio de Similaridade de Arrays");
            Console.WriteLine("Informar valores separados por vírgula (,).");
            int[] varrayA = ObterArrayDoUsuario("Primeiro Array: ");
            int[] varrayB = ObterArrayDoUsuario("Segundo Array: ");

            (bool vigualdade, var vtempo_igualadde) = VerificarIgualdade(varrayA, varrayB);
            (bool vsimilaridade, var vtempo_similaridade) = VerificarSimilaridade(varrayA, varrayB);


            Console.WriteLine($"Os arrays são iguais? {vigualdade}. Tempo de processamento: {vtempo_igualadde}s.");
            Console.WriteLine($"Os arrays são similares? {vsimilaridade}. Tempo de processamento: {vtempo_similaridade}s.");

        }

        /// <summary>
        /// Obtem o vetor do usuário.
        /// </summary>
        /// <param name="mensagem">MEnsagem de exibição da solicitação.</param>
        /// <returns></returns>
        static int[] ObterArrayDoUsuario(string mensagem)
        {
            Console.Write(mensagem);
            string[] input = Console.ReadLine().Split(',');

            int[] array = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = int.Parse(input[i]);
            }

            return array;
        }



        /// <summary>
        /// Função para verificar a similaridade dos vetores.
        /// </summary>
        /// <param name="arrayA">Vetor A.</param>
        /// <param name="arrayB">Vetor B.</param>
        /// <returns></returns>
        private static (bool, string) VerificarSimilaridade(int[] arrayA, int[] arrayB)
        {
            var vtempoi = DateTime.Now;
            var vretorno_tamanho = VerificaTamanhoArray(arrayA, arrayB);
            if (!vretorno_tamanho)
            {
                return RetornoComTempo(false, vtempoi);
            }

            (var varray_ordenado_a, var v_array_ordenado_b) = OrdenarArrays(arrayA, arrayB);

            int? firstDiffIndexA = null;
            int? firstDiffIndexB = null;

            for (int i = 0; i < varray_ordenado_a.Length; i++)
            {
                if (varray_ordenado_a[i] != v_array_ordenado_b[i])
                {
                    if (firstDiffIndexA == null)
                    {
                        firstDiffIndexA = i;
                        firstDiffIndexB = i;
                    }
                    else
                    {
                        // Uma segunda diferença foi encontrada, os vetores não podem ser iguais, mas ainda podem der similares.
                        return RetornoComTempo(false, vtempoi);
                    }
                }
            }

            if (firstDiffIndexA == null)
            {
                // Nenhuma diferença encontrada, vetores são iguais
                return RetornoComTempo(true, vtempoi);
            }

            // Simular a troca de elementos em a e comparar com b para verificar similaridade
            varray_ordenado_a[firstDiffIndexA.Value] = v_array_ordenado_b[firstDiffIndexB!.Value];
            for (int i = 0; i < varray_ordenado_a.Length; i++)
            {
                if (varray_ordenado_a[i] != v_array_ordenado_b[i])
                {
                    return RetornoComTempo(false, vtempoi);
                }
            }

            return RetornoComTempo(true, vtempoi);
        }

        /// <summary>
        /// Função para verificar a igualdade dos vetores.
        /// </summary>
        /// <param name="arrayA">Vetor A.</param>
        /// <param name="arrayB">Vetor B.</param>
        /// <returns></returns>
        private static (bool, string) VerificarIgualdade(int[] arrayA, int[] arrayB)
        {
            var vtempoi = DateTime.Now;
            var vretorno_tamanho = VerificaTamanhoArray(arrayA, arrayB);
            if (!vretorno_tamanho)
            {
                return RetornoComTempo(false, vtempoi);
            }

            (var varray_ordenado_a, var v_array_ordenado_b) = OrdenarArrays(arrayA, arrayB);

            bool vfirstDiffIndex = false;

            for (int i = 0; i < varray_ordenado_a.Length; i++)
            {
                if (!vfirstDiffIndex && varray_ordenado_a[i] != v_array_ordenado_b[i])
                {
                    vfirstDiffIndex = true;
                }
            }

            return RetornoComTempo(!vfirstDiffIndex, vtempoi);
        }

        /// <summary>
        /// Veriica se os vetores estão com o mesmo tamanho. 
        /// </summary>
        /// <param name="arrayA">Vetor A.</param>
        /// <param name="arrayB">Vetor B.</param>
        /// <returns></returns>
        static bool VerificaTamanhoArray(int[] arrayA, int[] arrayB)
        {
            var vtamanho_minimo = 3;
            var vtamanho_maximo = 105;
            var vamplitude_minima = 1;
            var vamplitude_maxima = 1000;

            if (arrayA.Length != arrayB.Length)
            {
                return false;
            }

            if (arrayA.Length < vtamanho_minimo || arrayA.Length > vtamanho_maximo)
            {
                return false;
            }

            for (int i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] < vamplitude_minima || arrayA[i] > vamplitude_maxima)
                {
                    return false;
                }

                if (arrayB[i] < vamplitude_minima || arrayB[i] > vamplitude_maxima)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Ordena os vetores por Bubble Sort.
        /// </summary>
        /// <param name="arrayA">Array A.</param>
        /// <param name="arrayB">Array B.</param>
        private static (int[], int[]) OrdenarArrays(int[] arrayA, int[] arrayB)
        {
            var (va, vb) = CriarNovasInstanciasDeArrays(arrayA, arrayB);  

            var vlimite = va.Length - 1;

            for (int x = 0; x <= vlimite; x++)
            {
                for (int i = 0; i < vlimite - x; i++)
                {
                    if (va[i] > va[i + 1])
                    {
                        (va[i + 1], va[i]) = (va[i], va[i + 1]);
                    }

                    if (vb[i] > vb[i + 1])
                    {
                        (vb[i + 1], vb[i]) = (vb[i], vb[i + 1]);
                    }
                }
            }

            return (va, vb);
        }

        /// <summary>
        /// Normaliza o retorno com a duração do processo.
        /// </summary>
        /// <param name="retorno">retorno gerado pelo processo.</param>
        /// <param name="tempoInicial">A marcação de tempo no início do processo.</param>
        /// <returns></returns>
        static (bool, string) RetornoComTempo(bool retorno, DateTime tempoInicial)
        {
            DateTime vtempoFinal = DateTime.Now;

            var vduracao = vtempoFinal - tempoInicial;

            var vduracao_segundos = vduracao.TotalSeconds;

            return (retorno, vduracao_segundos.ToString("F4"));
        }

        /// <summary>
        /// Ordena os vetores por Bubble Sort.
        /// </summary>
        /// <param name="arrayA">Array A.</param>
        /// <param name="arrayB">Array B.</param>
        private static (int[], int[]) CriarNovasInstanciasDeArrays(int[] arrayA, int[] arrayB)
        {
            var vnew_a = new int[arrayA.Length];
            var vnew_b = new int[arrayB.Length];

            var vlimite = vnew_a.Length - 1;

            for (int x = 0; x <= vlimite; x++)
            {
                vnew_a[x] = arrayA[x];
                vnew_b[x] = arrayB[x];
            }

            return (vnew_a, vnew_b);
        }
    }

}