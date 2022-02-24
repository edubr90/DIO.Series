using System;
using System.Collections;
using System.Collections.Generic;
using DIO.Series.Entities;

namespace DIO.Series.Classes
{
    public static class TextSystem
    {
        public static string GetInitialText()
        {
            var result = string.Empty;

            result += "DIO Séries a seu dispor";
            result += Environment.NewLine;
            
            result += "Informe a opção desejada";
            result += Environment.NewLine;
            result += Environment.NewLine;

            result += "1 - Listar séries";
            result += Environment.NewLine;

            result += "2 - inserir nova série";
            result += Environment.NewLine;

            result += "3 - Atualizar série";
            result += Environment.NewLine;

            result += "4 - Excluir série";
            result += Environment.NewLine;
            
            result += "5 - Visualizar série";
            result += Environment.NewLine;

            result += "C - Limpar Tela";
            result += Environment.NewLine;

            result += "X - Sair do sistema";
            Console.WriteLine();

            return result;

        }

        public static string GetExitText()
        {
            var result = string.Empty;
            result += "Obrigado por utilizar nossos serviços. Até logo";
            result += Environment.NewLine;
            result += "Pressione qualquer tecla para sair";

            return result;
        }

        public static string GetInvalidOptionText()
        {
            var result = string.Empty;
            result += "Opção inválida, Por favor tente novamente";
            return result;
        }

        public static string NotFoundSeriesText()
        {
            return "Nenhuma série foi encontrada.";
        }

        public static string GetRestartOptionText()
        {
            var result = string.Empty;
            result += "Operação finalizada com sucesso!";
            result += Environment.NewLine;
            result += "Deseja realizar outra operação? (S/N)";
            return result;
        }

        public static class SerieFieldsText
        {
            public static string GetCreateGenderText()
            {
                return "Digite o genero desejado:";
            }
            
            public static string GetCreateTitleText()
            {
                return "Digite o título da série";
            }

            public static string GetCreateDescriptionText()
            {
                return "Digite a descrição da série";
            }

            public static string GetCreateYearText()
            {
                return "Digite o ano da série";
            }

            public static string GetSerieIdText()
            {
                return "Selecione o ID da série";
            }

            public static string GetSequentialItemsWithDescriptionText(Dictionary<int, string> items)
            {
                var result = string.Empty;

                foreach(var item in items)
                {
                    result += $"{item.Key} - {item.Value}";
                    result += Environment.NewLine;
                }

                return result;
            }

            public static string GetSerieNotFountExceptionText()
            {
                return $"A série não foi encontrada no cadastro.";
            }
        }


    }
}