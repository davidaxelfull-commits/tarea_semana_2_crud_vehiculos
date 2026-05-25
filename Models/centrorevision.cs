namespace Clase_2.Models
{
    public class CentroRevision
    {
        // centro_revision
        /*
            id
            nombre

            relación con provincia
        */

        // referencias
        public int Id { get; set; }

        public string Nombre { get; set; }

        // relacion
        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }
    }
}