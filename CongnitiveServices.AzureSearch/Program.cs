using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;


namespace CongnitiveServices.AzureSearch
{
    public class IndexLetras
    {
        [Key]
        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string Id { get; set; }

        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string NomeBanda { get; set; }

        [IsRetrievable(true)]
        [IsSortable]
        [IsFilterable]
        public string Album { get; set; }

        [IsSortable]
        [IsFilterable]
        [IsRetrievable(true)]
        [IsSearchable]
        public string Letra { get; set; }




    }



    class Program
    {
        static void Main(string[] args)
        {

            SearchServiceClient searchServiceClient = 
                new SearchServiceClient("teste-azuresearch-dois", 
                new SearchCredentials("4A91F9970AB73ADB4106D6BC56FD0EE2"));

            var index = searchServiceClient.Indexes.GetClient("index-bandas");
            //Gerando um item para ser gravado no índice
            var batch = IndexBatch.Upload<IndexLetras>(new List<IndexLetras>
            {
                new IndexLetras
                {
                    Id = "rm331132",
                    Album = "Raimundos Lyrics",
                    #region "Letra"
                    Letra = @"Que mulher ruim
                                Jogou minhas coisas fora
                                Disse que em sua cama
                                Eu não deito mais não
                                A casa é minha
                                Você que vá embora
                                Já pra saia da sua mãe
                                E deixa meu colchão

                                Ela é pró na arte
                                De pentelhar e aziar
                                É campeã do mundo
                                A raiva era tanta
                                Que eu nem reparei
                                Que a Lua diminuía

                                A doida tá me beijando há horas
                                Disse que se for sem eu
                                Não quer viver mais não
                                Me diz, Deus, o que é que eu faço agora ?

                                Se me olhando desse jeito
                                Ela me tem na mão, meu filho aguenta
                                Quem mandou você gostar
                                Dessa mulher de fases ?

                                Complicada e perfeitinha
                                Você me apareceu
                                Era tudo que eu queria
                                Estrela da sorte
                                Quando a noite ela surgia
                                Meu bem você cresceu
                                Meu namoro é na folhinha
                                Mulher de fases!

                                Põe fermento, põe as bombas
                                Qualquer coisa que aumente
                                A deixe bem maior que o Sol
                                Pouca gente sabe que na noite
                                O frio é quente e arde e eu acendi

                                Até sem luz dá pra te enxergar
                                O lençol fazendo congo - blue
                                É pena, eu sei a manhã já vai miar
                                Se aguente, que lá vem chumbo quente

                                Complicada e perfeitinha
                                Você me apareceu
                                Era tudo que eu queria
                                Estrela da sorte
                                Quando a noite ela surgia
                                Meu bem você cresceu
                                Meu namoro é na folhinha
                                Mulher de fases!

                                Complicada e perfeitinha
                                Você me apareceu
                                Era tudo que eu queria
                                Estrela da sorte
                                Quando a noite ela surgia
                                Meu bem você cresceu
                                Meu namoro é na folhinha
                                Mulher de fases!",
#endregion
                    NomeBanda = "Raimundos"
                }

            });

            //Gravando no indice do Azure 
            //index.Documents.Index(batch);

            Console.WriteLine("Digite um termo para a busca");
            var term = Console.ReadLine();
            var result = index.Documents.Search<IndexLetras>(term, new SearchParameters { IncludeTotalResultCount = true });

            Console.WriteLine($"{result.Count} resultados encontrados");
            foreach (var item in result.Results)
            {
                Console.WriteLine($"{item.Document.Id} - {item.Document.NomeBanda}");
            }

            Console.Read();
        }
    }
}
