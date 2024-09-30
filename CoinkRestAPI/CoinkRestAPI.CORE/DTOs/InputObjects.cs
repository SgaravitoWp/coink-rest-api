using System.ComponentModel.DataAnnotations;

namespace CoinkRestAPI.CORE.DTOs
{
    /// <summary>
    /// Clase que valida una petición GET de departamentos.
    /// </summary>
    public class StateGet
    {
        /// <summary>
        /// ID del país requerido.
        /// </summary>
        [Required(ErrorMessage = "Country ID is required.")]
        public string country_id { get; set; }
    }

    /// <summary>
    /// Clase que valida una petición GET de municipios.
    /// </summary>
    public class CityGet
    {
        /// <summary>
        /// ID del departamento requerido.
        /// </summary>
        [Required(ErrorMessage = "State ID is required.")]
        public int state_id { get; set; }
    }

    /// <summary>
    /// Clase que valida una petición POST para crear un usuario.
    /// </summary>
    public class UserPost
    {
        /// <summary>
        /// ID del usuario requerido, debe contener entre 6 y 12 dígitos.
        /// </summary>
        [Required(ErrorMessage = "The user ID is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "The user ID can only contain digits.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "The user ID must be between 6 and 12 digits long.")]
        public string user_id { get; set; }

        /// <summary>
        /// Nombre del usuario requerido, con una longitud máxima de 100 caracteres.
        /// </summary>
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        public string name { get; set; }

        /// <summary>
        /// Número de teléfono requerido, debe contener entre 10 y 15 dígitos.
        /// </summary>
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "The phone number can only contain digits.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "The phone number must be between 10 and 15 digits.")]
        public string phone { get; set; }

        /// <summary>
        /// Dirección requerida, con una longitud máxima de 255 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "The address cannot exceed 255 characters.")]
        public string address { get; set; }

        /// <summary>
        /// ID del país requerido, debe tener exactamente 3 caracteres.
        /// </summary>
        [Required(ErrorMessage = "Country ID is required.")]
        [StringLength(3, MinimumLength = 2 ,ErrorMessage = "The country ID must be 2 or 3 characters long.")]
        public string country_id { get; set; }

        /// <summary>
        /// ID del departamento requerido.
        /// </summary>
        [Required(ErrorMessage = "State ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The State ID is required and different from 0")]

        public int state_id { get; set; }

        /// <summary>
        /// ID del municipio requerido.
        /// </summary>
        [Required(ErrorMessage = "City ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The City ID is required and different from 0")]
        public int city_id { get; set; }
    }
}