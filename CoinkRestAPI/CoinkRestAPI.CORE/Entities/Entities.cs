using System.ComponentModel.DataAnnotations;

namespace CoinkRestAPI.CORE.Entities
{
    /// <summary>
    /// Clase que representa a un usuario en el sistema.
    /// </summary>
    public class User 
    {
        /// <summary>
        /// ID del usuario en la base de datos.
        /// </summary>
        [Required]
        public string id { get; set; }

        /// <summary>
        /// Número de documento del usuario.
        /// </summary>
        [Required]
        public string user_id { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// Número de teléfono del usuario.
        /// </summary>
        [Required]
        public string phone { get; set; }

        /// <summary>
        /// Dirección del usuario.
        /// </summary>
        [Required]
        public string address { get; set; }

        /// <summary>
        /// ID del país del usuario.
        /// </summary>
        [Required]
        public string country_id { get; set; }

        /// <summary>
        /// ID del departamento del usuario.
        /// </summary>
        [Required]
        public int state_id { get; set; }

        /// <summary>
        /// ID del municipio del usuario.
        /// </summary>
        [Required]
        public int city_id { get; set; }
    }

    /// <summary>
    /// Clase que representa un país.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ID del país.
        /// </summary>
        [Required]
        public string id { get; set; }

        /// <summary>
        /// Nombre del país.
        /// </summary>
        [Required]
        public string name { get; set; }
    }

    /// <summary>
    /// Clase que representa un departamento o estado.
    /// </summary>
    public class State 
    {
        /// <summary>
        /// ID del departamento.
        /// </summary>
        [Required]
        public int id { get; set; }

        /// <summary>
        /// Nombre del departamento.
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// ID del país al que pertenece el departamento.
        /// </summary>
        [Required]
        public string country_id { get; set; }
    }

    /// <summary>
    /// Clase que representa un municipio o ciudad.
    /// </summary>
    public class City 
    {
        /// <summary>
        /// ID del municipio.
        /// </summary>
        [Required]
        public int id { get; set; }

        /// <summary>
        /// Nombre del municipio.
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// ID del departamento al que pertenece el municipio.
        /// </summary>
        [Required]
        public int state_id { get; set; }
    }
}