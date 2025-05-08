﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gerenciamento_de_Livro_Biblioteca.API.Converters
{
    public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcDateTimeConverter() : base(
            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {

        }
    }
}
