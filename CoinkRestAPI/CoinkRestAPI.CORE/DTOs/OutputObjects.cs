using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoinkRestAPI.CORE.DTOs
{
    /// <summary>
    /// Clase que representa una respuesta de error.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Tipo de error (opcional).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? type { get; set; }

        /// <summary>
        /// Indica si la operación fue exitosa (opcional).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? success { get; set; }

        /// <summary>
        /// Título del error (obligatorio).
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// Errores detallados (opcional).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string[]>? errors { get; set; }

        /// <summary>
        /// ID de seguimiento (opcional).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? traceId { get; set; }

        /// <summary>
        /// Estado HTTP de la respuesta (obligatorio).
        /// </summary>
        [Required]
        public int status { get; set; }
    }

    /// <summary>
    /// Clase genérica que representa una respuesta exitosa.
    /// </summary>
    /// <typeparam name="T">Tipo de datos contenidos en la respuesta.</typeparam>
    public class SuccessResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa (obligatorio).
        /// </summary>
        [Required]
        public bool success { get; set; }

        /// <summary>
        /// Mensaje de éxito (obligatorio).
        /// </summary>
        [Required]
        public string message { get; set; }

        /// <summary>
        /// Datos de la respuesta (obligatorio).
        /// </summary>
        [Required]
        public IEnumerable<T> data { get; set; }

        /// <summary>
        /// Código de estado HTTP de la respuesta (obligatorio).
        /// </summary>
        [Required]
        public int status_code { get; set; }
    }
}