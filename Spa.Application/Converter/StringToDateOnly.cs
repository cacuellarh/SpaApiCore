

namespace Spa.Application.Converter
{
    public static class ConvertStringToDateOnly
    {
        public static DateOnly Convert(string date) 
        {
            if (!DateOnly.TryParse(date, out DateOnly dateParsed))
                throw new InvalidCastException($"Error al convertir ${date} a formato de fecha");

            return dateParsed;  
        }
    }
}
