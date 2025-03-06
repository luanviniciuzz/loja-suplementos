using System.Diagnostics;
using System.Text.Json;

namespace LojaSuplementos.Utils.EncontrarVogal
{
    public class ConsultarString
    {
        public string EncontrarVogal(string cadeiaDeString)
        {
            string input = cadeiaDeString;

            Stopwatch tempo = new Stopwatch();
            tempo.Start();

            char[] vogais = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char resultado = '\0';

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (!vogais.Contains(input[i]) && vogais.Contains(input[i + 1]) && vogais.Contains(input[i - 1]))
                {
                    char vogalAtual = input[i + 1];

                    if (input.Count(c => c == vogalAtual) == 1)
                    {
                        resultado = vogalAtual;
                        break;
                    }
                }
            }

            tempo.Stop();

            var output = new
            {
                stringOriginal = input,
                vogal = resultado == '\0' ? "Nenhuma" : resultado.ToString(),
                tempoTotal = $"{tempo.ElapsedMilliseconds}ms"
            };

            return JsonSerializer.Serialize(output);
        }
    }
}
