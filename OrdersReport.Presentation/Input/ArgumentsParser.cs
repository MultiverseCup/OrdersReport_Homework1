using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersReport.Presentation.Input
{
    public sealed class ArgumentsParser : IArgumentsParser
    {
        private const string Usage =
            "Использование: OrdersReport <console|file> <id клиента> [id клиента ...]";

        public AppArguments Parse(string[] args)
        {
            if (args.Length == 0)
            {
                throw new InvalidArgumentsException($"Не указан режим вывода. {Usage}");
            }

            var mode = args[0].Trim().ToLowerInvariant() switch
            {
                "console" => ReportMode.Console,
                "file" => ReportMode.File,
                _ => throw new InvalidArgumentsException(
                    $"Неизвестный режим \"{args[0]}\". Допустимые значения: console, file. {Usage}")
            };

            var parts = args
                .Skip(1)
                .SelectMany(a => a.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            if (parts.Count == 0)
            {
                throw new InvalidArgumentsException($"Не переданы id клиентов. {Usage}");
            }

            var ids = new List<long>();
            foreach (var part in parts)
            {
                if (!long.TryParse(part, out var id))
                {
                    throw new InvalidArgumentsException(
                        $"Некорректный id клиента: \"{part}\". Id должен быть целым числом.");
                }

                ids.Add(id);
            }

            return new AppArguments(mode, ids.Distinct().ToList());
        }
    }
}
